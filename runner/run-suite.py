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
from suite_config import load_config, resolve_level, select_levels
from suite_editions import edition_definition, edition_inventory, version_inventory
from suite_engine import CATEGORIES, UNSUPPORTED_REASONS, Context, run_controls
from suite_versions import applicability, gating_source, use_pilot_versions, version_row


class SelectionUsageError(ValueError):
    """A selector combination or an empty selection is a command-line error."""


def result_key(test, level, mode):
    return (test["suite_id"], test["test_id"], level["level"] if level else test["version"], mode)


def language_plans(tests, config, selection, explicit):
    plans = []
    for test in tests:
        levels = explicit
        if selection == "declared-per-test":
            levels = [resolve_level(config, test["version"])]
        elif selection == "earliest-per-test":
            row, status = version_row(test)
            if status != "current":
                raise ValueError("Current bounds required for " + test["test_id"])
            name = "preview" if row["since"].endswith("-preview") else row["since"]
            level = resolve_level(config, name)
            if level is None:
                raise ValueError("Earliest measured level is unsupported for " + test["test_id"] + ": " + name)
            levels = [level]
        for level in levels:
            mode = applicability(test, level) if selection == "explicit" else "test"
            plans.append((test, level, mode))
    return plans


def prepare_run(inventory, suites, config, args):
    definitions, decisions = {}, {}
    if args.edition is not None:
        definitions = {suite_id: edition_definition(suite_id, args.edition, config, inventory) for suite_id in suites}
        selection, explicit = "edition", []
        for definition in definitions.values():
            if definition["level"] not in explicit:
                explicit.append(definition["level"])
    else:
        selection, explicit = select_levels(config, args.langversion)
    candidates = inventory
    if args.select:
        selected = re.compile(args.select)
        candidates = [test for test in candidates if selected.search(test["test_id"])]
    if args.origin:
        candidates = [test for test in candidates if (test["authority"].startswith("csc")
                      if args.origin == "post-ecma" else test["origin"] == args.origin)]
    if not candidates:
        raise SelectionUsageError("No tests selected")
    if args.pilot_versions:
        if args.select is None or selection == "declared-per-test":
            raise SelectionUsageError("--pilot-versions requires --select and a measured language or edition selection")
        candidates = use_pilot_versions(args.pilot_versions, candidates)
    tests = candidates if selection in {"edition", "declared-per-test"} else version_inventory(candidates)
    if selection != "declared-per-test" and any(test["version_status"] != "current" for test in tests):
        raise ValueError("Measured runs require current version metadata for every selected test")
    if selection == "edition":
        tests, decisions = edition_inventory(tests, definitions)
        plans = [(test, definitions[test["suite_id"]]["level"], "test") for test in tests]
    else:
        plans = language_plans(tests, config, selection, explicit)
    if not tests:
        raise SelectionUsageError("No tests selected for this run mode")
    details = {"candidate_test_ids": [[test["suite_id"], test["test_id"]] for test in candidates],
               "edition": args.edition,
               "edition_selection": {suite_id: {**{key: value for key, value in definition.items() if key != "table"},
                                                    **decisions[suite_id]} for suite_id, definition in definitions.items()}}
    return tests, plans, selection, explicit, details


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
    if summary.get("edition") is not None:
        levels = ", ".join(level["level"] for level in summary["levels"])
        lines[:1] = ["Results for edition " + str(summary["edition"]) + " at language level " + levels]
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
    selectors = parser.add_mutually_exclusive_group()
    selectors.add_argument("--langversion", action="append", help="LEVEL[,LEVEL...], START..END, all or earliest-per-test; temporary maintainer mode: declared-per-test")
    selectors.add_argument("--edition", type=int, help="Registered non-latest standard edition at its fixed language level; excludes --langversion")
    parser.add_argument("--jobs", type=int, default=1)
    parser.add_argument("--select", help="Regular expression on test IDs")
    parser.add_argument("--pilot-versions", type=Path, help="External complete pilot bounds for exactly --select; installs no public bounds")
    parser.add_argument("--origin", choices=["handwritten", "generated", "post-ecma"])
    parser.add_argument("--resume", action="store_true", help="Reuse verified passes after fresh controls")
    parser.add_argument("--resume-completed", action="store_true", help="Reuse verified completed outcomes after fresh controls")
    parser.add_argument("--max-new", type=int)
    parser.add_argument("--stop-file", type=Path)
    parser.add_argument("--compile-timeout", type=float, default=60)
    parser.add_argument("--run-timeout", type=float, default=20)
    args = parser.parse_args()
    if not args.langversion and args.edition is None:
        parser.error("Choose --edition N or --langversion LEVEL[,LEVEL...], START..END, all or earliest-per-test; maintainers may temporarily use declared-per-test")
    if args.edition is not None and args.edition < 1:
        parser.error("Edition must be positive")
    if not 1 <= args.jobs <= 12 or (args.max_new is not None and args.max_new < 1):
        parser.error("jobs must be 1..12; max-new must be positive")
    suites = args.suite or installed_suites()
    if len(suites) != len(set(suites)):
        parser.error("Suite selectors must be distinct")
    config, _, _ = load_config(args.compiler, "compiler")
    inventory = [test for suite_id in suites for test in load_manifest(suite_id=suite_id)]
    try:
        tests, plans, selection, explicit, selection_details = prepare_run(inventory, suites, config, args)
    except SelectionUsageError as error:
        parser.error(str(error))
    for level in explicit:
        print("Language " + level["requested"] + " resolves to " + level["level"] + " (" + level["mode"] + ")", flush=True)
    if args.edition is not None:
        print("Standard edition " + str(args.edition), flush=True)
    context = Context(args.compiler, args.target, args.results, args.compile_timeout, args.run_timeout)
    records, reused, controls = {}, {}, None
    submitted = 0
    manifests = {suite_id: sha(standard_root(suite_id) / "manifest.tsv") for suite_id in suites}
    provenance = context.provenance()
    if args.pilot_versions:
        provenance["pilot_versions"] = {"path": str(args.pilot_versions.resolve()), "sha256": sha(args.pilot_versions)}
    if args.edition is not None:
        provenance["edition_tables"] = {suite_id: detail["conflict_table"]
                                        for suite_id, detail in selection_details["edition_selection"].items()}

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
            "version_mode": "header-Version" if selection == "declared-per-test" else selection,
            "language_selectors": args.langversion or [], "levels": explicit, **selection_details,
            "departures": sum(r["departure"] for r in ordered)}
        write_json(context.output / "run.json", metadata)
        summary = summarize(ordered, provenance)
        summary.update(complete=metadata["complete"], void=metadata["void"], edition=args.edition,
                       version_mode=metadata["version_mode"], levels=explicit)
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
