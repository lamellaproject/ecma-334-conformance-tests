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
from suite_config import load_config
from suite_editions import header_plans
from suite_engine import Context, run_controls


def warning_present(record):
    return any(d["stage"] == "program" and d["severity"] == "warning" for d in record["diagnostics"])


def classify(test, original, mutant, confirmed):
    if (confirmed and original.get("departure")
            and original["status"] in {"unexpected-reject", "unexpected-accept", "runtime-fail", "diagnostic-fail"}):
        return "inconclusive-departure", "A confirmed departure cannot prove sensitivity with this compiler."
    if original["status"] == "unsupported":
        return "inconclusive-unsupported", original["unsupported_reason"]
    if original["status"] != "pass":
        return "inconclusive-original", original["status"] + ":" + original["reason"]
    if original["reason"] == "permitted-rejection":
        return "inconclusive-original", "permitted-rejection"
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
    inventory = [r for suite_id in args.suite or installed_suites() for r in load_manifest(suite_id=suite_id)]
    tests = inventory
    if args.select:
        pattern = re.compile(args.select)
        tests = [r for r in tests if pattern.search(r["test_id"])]
    config, _, _ = load_config(args.compiler, "compiler")
    plans, membership = header_plans(tests, config, inventory)
    generated = sum(test["origin"] == "generated" for test, _, _ in plans)
    plans = [plan for plan in plans if plan[0]["origin"] == "handwritten"
             and (not args.warnings_only or plan[0]["diagnostic"])]
    if not plans:
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
                   "complete": controls["valid"] and len(rows) == len(plans), "selected_tests": len(plans),
                   "generated_unmutated": generated, "tests": len(rows), "status_counts": counts, "rows": rows,
                   "language_edition_selection": membership}
        write_json(context.output / "summary.json", summary)
        write_tsv(context.output / "results.tsv", rows, ["suite_id", "test_id", "source_sha256", "fixture_sha256",
                  "status", "reason", "original_status", "mutant_status", "original_warning", "mutant_warning",
                  "mutant_source_sha256", "original_result", "mutant_result", "original_result_sha256", "mutant_result_sha256",
                  "edition_membership_json"])
        return summary

    publish()
    if not controls["valid"]:
        print("VOID: mutation controls failed", flush=True)
        return 3
    def pair(plan):
        test, level, plan_mode = plan
        if plan_mode == "superseded":
            original = context.saved(test, level, plan_mode) if args.resume else None
            if original is None:
                original = context.superseded(test, level)
            return {"suite_id": test["suite_id"], "test_id": test["test_id"], "source_sha256": test["source_sha256"],
                    "fixture_sha256": test["fixture_sha256"], "status": "superseded", "reason": "edition-rule-changed",
                    "original_status": "superseded", "mutant_status": "", "original_result": original["result_path"],
                    "original_result_sha256": sha(original["result_path"]),
                    "edition_membership_json": json.dumps(test["edition_membership"], sort_keys=True)}
        original = context.saved(test, level, completed=True) if args.resume else None
        if original is None:
            original = context.run(test, level)
        raw = mutated_source(test, context.source_path(test).read_bytes())
        mutant_test = dict(test)
        mode = "mutation"
        if test["expected"] == "run-or-reject":
            mutant_test["expected"] = "run"
        elif test["expected"] == "reject" or test["diagnostic"] == "warning":
            # A reject's causal witness must compile; warning changes must preserve compilation.
            mutant_test["expected"] = "run"
            mode = "compile-only"
        mutant = context.saved(mutant_test, level, mode=mode, completed=True, executed_bytes=raw) if args.resume else None
        if mutant is None:
            mutant = context.run(mutant_test, level, mode=mode, executed_bytes=raw)
        confirmed = original["departure"]
        status, reason = classify(test, original, mutant, confirmed)
        return {"suite_id": test["suite_id"], "test_id": test["test_id"], "source_sha256": test["source_sha256"],
                "fixture_sha256": test["fixture_sha256"], "status": status, "reason": reason,
                "original_status": original["status"], "mutant_status": mutant["status"],
                "original_warning": warning_present(original), "mutant_warning": warning_present(mutant),
                "mutant_source_sha256": mutant["executed_source_sha256"],
                "original_result": original["result_path"], "mutant_result": mutant["result_path"],
                "original_result_sha256": sha(original["result_path"]), "mutant_result_sha256": sha(mutant["result_path"]),
                "edition_membership_json": json.dumps(test.get("edition_membership"), sort_keys=True)}

    with ThreadPoolExecutor(max_workers=args.jobs) as pool:
        for offset in range(0, len(plans), args.jobs):
            rows.extend(pool.map(pair, plans[offset:offset + args.jobs]))
            summary = publish()
            if offset % (args.jobs * 10) == 0:
                print(json.dumps({k: summary[k] for k in ["tests", "selected_tests", "status_counts", "elapsed_seconds"]}), flush=True)
    summary = publish()
    print(json.dumps({k: summary[k] for k in ["tests", "complete", "status_counts", "elapsed_seconds"]}), flush=True)
    return 1 if any(r["status"] not in {"killed", "repaired", "inconclusive-departure", "inconclusive-unsupported", "superseded"} for r in rows) else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
