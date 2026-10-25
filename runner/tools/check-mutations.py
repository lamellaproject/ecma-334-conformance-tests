"""Prove handwritten tests' causal changes using fresh controls and recorded evidence."""
from __future__ import annotations

import argparse
import json
import re
import sys
import time
from collections import Counter
from concurrent.futures import ThreadPoolExecutor
from pathlib import Path

from suite_common import ROOT, installed_suites, load_manifest, main_guard, mutated_source, sha, utc, write_json, write_tsv
from suite_engine import Context, departure_rows, run_controls


def warning_present(record):
    return any(d["stage"] == "program" and d["severity"] == "warning" for d in record["diagnostics"])


def classify(test, original, mutant, confirmed):
    if confirmed:
        return "inconclusive-departure", "A confirmed departure cannot prove sensitivity with this compiler."
    if original["status"] == "unsupported":
        return "inconclusive-unsupported", original["unsupported_reason"]
    if original["status"] != "pass":
        return "inconclusive-original", original["status"] + ":" + original["reason"]
    if mutant["status"] in {"unsupported", "infrastructure", "compiler-error"}:
        return "inconclusive-mutant", mutant["status"] + ":" + mutant["reason"]
    if test["diagnostic"] == "warning":
        accepted = mutant["compile_exit"] == 0 and mutant["status"] == "pass"
        changed = warning_present(original) != warning_present(mutant)
        return ("killed", "warning-cause-changed") if accepted and changed else ("survived", "warning-cause-not-proved")
    if test["expected"] == "reject":
        return ("repaired", "compiled") if mutant["status"] == "pass" else ("survived", "repair-did-not-compile")
    if mutant["status"] in {"unexpected-reject", "runtime-fail", "diagnostic-fail"}:
        if mutant["reason"] == "uncoded-rejection":
            return "inconclusive-mutant", "uncoded-rejection"
        return "killed", mutant["status"] + ":" + mutant["reason"]
    return "survived", mutant["status"]


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--compiler", type=Path, required=True)
    parser.add_argument("--target", type=Path, default=ROOT / "configs/targets/dotnet.json")
    parser.add_argument("--results", type=Path, required=True)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--select")
    parser.add_argument("--warnings-only", action="store_true")
    parser.add_argument("--jobs", type=int, default=1)
    parser.add_argument("--resume", action="store_true")
    parser.add_argument("--compile-timeout", type=float, default=60)
    parser.add_argument("--run-timeout", type=float, default=20)
    args = parser.parse_args()
    if not 1 <= args.jobs <= 12:
        parser.error("jobs must be 1..12")
    tests = [r for suite_id in args.suite or installed_suites() for r in load_manifest(suite_id=suite_id)]
    if args.select:
        pattern = re.compile(args.select)
        tests = [r for r in tests if pattern.search(r["test_id"])]
    generated = sum(t["origin"] == "generated" for t in tests)
    tests = [t for t in tests if t["origin"] == "handwritten" and (not args.warnings_only or t["diagnostic"])]
    if not tests:
        parser.error("No handwritten tests selected")
    start, started = time.perf_counter(), utc()
    context = Context(args.compiler, args.target, args.results, args.compile_timeout, args.run_timeout)
    provenance = {**context.provenance(), "mutation_tool_sha256": sha(Path(__file__))}
    controls = run_controls(context, args.jobs)
    rows = []

    def publish():
        counts = dict(sorted(Counter(r["status"] for r in rows).items()))
        summary = {"schema_version": 1, "provenance": provenance, "started_utc": started, "ended_utc": utc(),
                   "elapsed_seconds": time.perf_counter() - start, "controls": controls, "void": not controls["valid"],
                   "complete": controls["valid"] and len(rows) == len(tests), "selected_tests": len(tests),
                   "generated_unmutated": generated, "tests": len(rows), "status_counts": counts, "rows": rows}
        write_json(context.output / "summary.json", summary)
        write_tsv(context.output / "results.tsv", rows, ["suite_id", "test_id", "source_sha256", "fixture_sha256",
                  "status", "reason", "original_status", "mutant_status", "original_warning", "mutant_warning",
                  "mutant_source_sha256", "original_result", "mutant_result", "original_result_sha256", "mutant_result_sha256"])
        return summary

    publish()
    if not controls["valid"]:
        print("VOID: mutation controls failed", flush=True)
        return 3
    departures = {suite_id: departure_rows(suite_id) for suite_id in {t["suite_id"] for t in tests}}

    def pair(test):
        original = context.saved(test, completed=True) if args.resume else None
        if original is None:
            original = context.run(test)
        raw = mutated_source(test, context.source_path(test).read_bytes())
        mutant_test = dict(test)
        mode = "mutation"
        if test["expected"] == "reject" or test["diagnostic"] == "warning":
            # A reject's causal witness must compile; warning changes must preserve compilation.
            mutant_test["expected"] = "run"
            mode = "compile-only"
        mutant = context.saved(mutant_test, mode=mode, completed=True, executed_bytes=raw) if args.resume else None
        if mutant is None:
            mutant = context.run(mutant_test, mode=mode, executed_bytes=raw)
        departure = departures[test["suite_id"]].get(test["test_id"])
        confirmed = departure is not None and departure["status"] == "confirmed"
        status, reason = classify(test, original, mutant, confirmed)
        return {"suite_id": test["suite_id"], "test_id": test["test_id"], "source_sha256": test["source_sha256"],
                "fixture_sha256": test["fixture_sha256"], "status": status, "reason": reason,
                "original_status": original["status"], "mutant_status": mutant["status"],
                "original_warning": warning_present(original), "mutant_warning": warning_present(mutant),
                "mutant_source_sha256": mutant["executed_source_sha256"],
                "original_result": original["result_path"], "mutant_result": mutant["result_path"],
                "original_result_sha256": sha(original["result_path"]), "mutant_result_sha256": sha(mutant["result_path"])}

    with ThreadPoolExecutor(max_workers=args.jobs) as pool:
        for offset in range(0, len(tests), args.jobs):
            rows.extend(pool.map(pair, tests[offset:offset + args.jobs]))
            summary = publish()
            if offset % (args.jobs * 10) == 0:
                print(json.dumps({k: summary[k] for k in ["tests", "selected_tests", "status_counts", "elapsed_seconds"]}), flush=True)
    summary = publish()
    print(json.dumps({k: summary[k] for k in ["tests", "complete", "status_counts", "elapsed_seconds"]}), flush=True)
    return 1 if any(r["status"] not in {"killed", "repaired", "inconclusive-departure", "inconclusive-unsupported"} for r in rows) else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
