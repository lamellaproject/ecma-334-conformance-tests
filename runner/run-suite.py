"""Compile and run standards tests with pinned compiler and batch-target configurations."""
from __future__ import annotations

import argparse
import json
import re
import sys
import time
from collections import Counter
from concurrent.futures import ThreadPoolExecutor
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent / "tools"))
from suite_common import ROOT, installed_suites, load_manifest, main_guard, sha, standard_root, utc, write_json, write_text, write_tsv
from suite_config import resolve_level
from suite_engine import CATEGORIES, UNSUPPORTED_REASONS, Context, run_controls
from suite_versions import applicability, gating_source


def result_key(test, level, mode):
    return (test["suite_id"], test["test_id"], level["level"] if level else test["version"], mode)


def summarize(records, provenance):
    groups = {}
    for record in records:
        key = (record["suite_id"], record["level"], record["path"].split("/")[1])
        group = groups.setdefault(key, {"suite": key[0], "level": key[1], "clause": key[2], "all": 0,
            "categories": {category: 0 for category in CATEGORIES},
            "unsupported_reasons": {reason: 0 for reason in UNSUPPORTED_REASONS}, "departures": 0})
        group["all"] += 1
        group["categories"][record["status"]] += 1
        if record["status"] == "unsupported":
            group["unsupported_reasons"][record["unsupported_reason"]] += 1
        group["departures"] += int(record["departure"])
    for group in groups.values():
        counts = group["categories"]
        group["applicable"] = group["all"] - counts["unsupported"] - counts["not-applicable"] - counts["infrastructure"]
    scope = {}
    for suite_id in sorted({r["suite_id"] for r in records}):
        path = standard_root(suite_id) / "ledger-scope.json"
        detail = json.loads(path.read_text(encoding="utf-8"))
        scope[suite_id] = {clause: value["status"] for clause, value in detail["clauses"].items()}
    return {"schema_version": 1, "provenance": provenance, "groups": [groups[key] for key in sorted(groups)],
            "clause_scope": scope,
            "in_progress_clauses": {suite_id: [clause for clause, status in clauses.items() if status != "available"]
                                    for suite_id, clauses in scope.items()},
            "status_counts": {category: sum(g["categories"][category] for g in groups.values()) for category in CATEGORIES},
            "unsupported_reasons": {reason: sum(g["unsupported_reasons"][reason] for g in groups.values()) for reason in UNSUPPORTED_REASONS},
            "infrastructure_present": any(r["status"] == "infrastructure" for r in records)}


def summary_markdown(summary):
    columns = ["Suite", "Level", "Clause", "All", "Applicable", *CATEGORIES, "Departures", *UNSUPPORTED_REASONS]
    lines = ["Results by language level and clause", "", "| " + " | ".join(columns) + " |",
             "| " + " | ".join("---" for _ in columns) + " |"]
    for group in summary["groups"]:
        values = [group[k] for k in ["suite", "level", "clause", "all", "applicable"]]
        values += [group["categories"][k] for k in CATEGORIES]
        values += [group["departures"], *[group["unsupported_reasons"][k] for k in UNSUPPORTED_REASONS]]
        lines.append("| " + " | ".join(str(v) for v in values) + " |")
    if summary["infrastructure_present"]:
        lines += ["", "This run has infrastructure failures; its invocation needs repair before it counts."]
    for suite_id, clauses in summary["in_progress_clauses"].items():
        if clauses:
            lines += ["", suite_id + " clauses in progress: " + ", ".join(clauses) + "."]
    lines += ["", "Provenance: see run.json for the command, suite/compiler commits and pinned target assets."]
    return "\n".join(lines) + "\n"


def main():
    started, start = utc(), time.perf_counter()
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--compiler", type=Path, required=True)
    parser.add_argument("--target", type=Path, default=ROOT / "configs/targets/dotnet.json")
    parser.add_argument("--results", type=Path, required=True)
    parser.add_argument("--suite", action="append", help="Installed standard folder; default is every installed standard")
    parser.add_argument("--langversion", action="append", help="Comma-separated public language names, or all; default uses each header Version")
    parser.add_argument("--jobs", type=int, default=1)
    parser.add_argument("--select", help="Regular expression on test IDs")
    parser.add_argument("--origin", choices=["handwritten", "generated", "post7"])
    parser.add_argument("--resume", action="store_true", help="Reuse verified passes after fresh controls")
    parser.add_argument("--resume-completed", action="store_true", help="Reuse verified completed outcomes after fresh controls")
    parser.add_argument("--max-new", type=int)
    parser.add_argument("--stop-file", type=Path)
    parser.add_argument("--compile-timeout", type=float, default=60)
    parser.add_argument("--run-timeout", type=float, default=20)
    args = parser.parse_args()
    if not 1 <= args.jobs <= 12 or (args.max_new is not None and args.max_new < 1):
        parser.error("jobs must be 1..12; max-new must be positive")
    suites = args.suite or installed_suites()
    if len(suites) != len(set(suites)):
        parser.error("Suite selectors must be distinct")
    tests = [r for suite_id in suites for r in load_manifest(suite_id=suite_id)]
    if args.select:
        selected = re.compile(args.select)
        tests = [r for r in tests if selected.search(r["test_id"])]
    if args.origin:
        tests = [r for r in tests if (r["authority"].startswith("csc") if args.origin == "post7" else r["origin"] == args.origin)]
    if not tests:
        parser.error("No tests selected")
    if args.langversion and any(r["version_status"] != "current" for r in tests):
        raise ValueError("Explicit-level runs require current version metadata for every selected test")
    context = Context(args.compiler, args.target, args.results, args.compile_timeout, args.run_timeout)
    explicit = []
    if args.langversion:
        names = [v for item in args.langversion for v in item.split(",")]
        if "all" in [v.lower() for v in names]:
            if len(names) != 1:
                parser.error("all cannot be combined with other language selectors")
            names = [*context.config["language"]["explicit"]]
            if context.config["language"]["symbolic"]["preview"]:
                names.append("preview")
        for name in names:
            level = resolve_level(context.config, name)
            if level is None:
                raise ValueError("Requested language level is unsupported: " + name)
            if level["level"] not in [r["level"] for r in explicit]:
                explicit.append(level)
            print("Language " + name + " resolves to " + level["level"] + " (" + level["mode"] + ")", flush=True)
    plans = []
    for test in tests:
        for level in explicit or [resolve_level(context.config, test["version"])]:
            mode = applicability(test, level) if explicit else "test"
            plans.append((test, level, mode))
    records, reused, controls = {}, {}, None
    submitted = 0
    manifests = {suite_id: sha(standard_root(suite_id) / "manifest.tsv") for suite_id in suites}
    provenance = context.provenance()

    def publish():
        ordered = [records[result_key(*plan)] for plan in plans if result_key(*plan) in records]
        if ordered:
            flat = [{k: json.dumps(v, sort_keys=True) if isinstance(v, (dict, list)) else v for k, v in row.items()} for row in ordered]
            write_tsv(context.output / "results.tsv", flat, list(flat[0]))
        else:
            write_tsv(context.output / "results.tsv", [], ["suite_id", "test_id", "level", "mode", "status"])
        counts = dict(sorted(Counter(r["status"] for r in ordered).items()))
        metadata = {"schema_version": 1, "provenance": provenance, "started_utc": started, "ended_utc": utc(),
            "elapsed_seconds": time.perf_counter() - start, "jobs": args.jobs, "manifest_sha256": manifests,
            "selected_test_ids": [[r["suite_id"], r["test_id"]] for r in tests], "selected_tests": len(tests),
            "scheduled_tests": len(plans), "tests": len(ordered), "passes": counts.get("pass", 0),
            "unsupported": counts.get("unsupported", 0), "complete": controls is not None and controls["valid"] and len(ordered) == len(plans),
            "void": controls is not None and not controls["valid"], "controls": controls,
            "new_executions": submitted, "resume_verified_results_sha256": reused, "status_counts": counts,
            "version_status_counts": dict(sorted(Counter(r["version_status"] for r in tests).items())),
            "version_mode": "explicit" if explicit else "header-Version", "levels": explicit,
            "departures": sum(r["departure"] for r in ordered)}
        write_json(context.output / "run.json", metadata)
        summary = summarize(ordered, provenance)
        summary.update(complete=metadata["complete"], void=metadata["void"])
        write_json(context.output / "summary.json", summary)
        write_text(context.output / "summary.md", summary_markdown(summary))
        return metadata

    publish()
    controls = run_controls(context, args.jobs)
    publish()
    if not controls["valid"]:
        print("VOID: controls failed: " + ", ".join(controls["errors"]), flush=True)
        return 3
    pending, last_publish = [], time.perf_counter()

    def compile_plan(plan):
        test, level, mode = plan
        raw = gating_source(test) if mode == "version-gating" else None
        return context.compile(test, level, mode, raw, "not-applicable" if mode == "not-applicable" else None)

    def flush(pool):
        nonlocal last_publish
        prepared = list(pool.map(compile_plan, pending))
        results = context.run_batch(prepared, args.jobs)
        for plan, result in zip(pending, results):
            records[result_key(*plan)] = result
        pending.clear()
        if time.perf_counter() - last_publish >= 5:
            metadata = publish()
            print(json.dumps({k: metadata[k] for k in ["tests", "scheduled_tests", "status_counts", "elapsed_seconds"]}), flush=True)
            last_publish = time.perf_counter()

    with ThreadPoolExecutor(max_workers=args.jobs) as pool:
        for plan in plans:
            test, level, mode = plan
            raw = gating_source(test) if mode == "version-gating" else None
            previous = context.saved(test, level, mode, args.resume_completed, raw) if args.resume or args.resume_completed else None
            if previous:
                records[result_key(*plan)] = previous
                reused["|".join(result_key(*plan))] = sha(previous["result_path"])
                continue
            if (args.max_new is not None and submitted >= args.max_new) or (args.stop_file and args.stop_file.exists()):
                continue
            pending.append(plan)
            submitted += 1
            if len(pending) >= args.jobs:
                flush(pool)
        if pending:
            flush(pool)
    metadata = publish()
    print(json.dumps({k: metadata[k] for k in ["tests", "passes", "unsupported", "complete", "new_executions", "departures", "status_counts", "elapsed_seconds"]}), flush=True)
    return 2 if not metadata["complete"] else 1 if any(r["status"] not in {"pass", "unsupported", "not-applicable"} for r in records.values()) else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
