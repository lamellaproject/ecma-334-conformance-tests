"""Validate current source-keyed bounds and the independent all-level sample."""
import argparse
import json
import re
import sys
from collections import Counter
from pathlib import Path

from suite_common import ROOT, emit_audit, installed_suites, load_manifest, main_guard
from suite_config import level_tuple, load_config, read_config, resolve_level
from suite_versions import use_pilot_versions, version_file, version_row


def version_audit(suite_id, selected_tests=None, minimum_sample=200):
    tests = load_manifest(suite_id=suite_id, require_versions=True) if selected_tests is None else selected_tests
    compiler, _, _ = load_config(ROOT / "configs/compilers/csc.json", "compiler")
    load_config(ROOT / "configs/targets/dotnet.json", "target")
    if sys.platform == "win32":
        load_config(ROOT / "configs/targets/net481.json", "target")
    else:
        read_config(ROOT / "configs/targets/net481.json", "target", check_host=False)
    metadata = version_file(suite_id)
    if metadata is None:
        raise ValueError("Current version metadata is missing: " + suite_id)
    sample = metadata["sample"]
    if (not sample.get("complete") or not sample.get("independent") or sample.get("tests", 0) < minimum_sample
            or sample.get("levels") != metadata["levels"] or sample.get("mismatches") or len(set(sample.get("test_ids", []))) != sample["tests"]):
        raise ValueError("Version metadata lacks a complete independent all-level sample")
    errors, rows, since, bases, methods = [], [], Counter(), Counter(), Counter()
    for test in tests:
        row, status = version_row(test)
        if status != "current":
            errors.append(test["test_id"] + ": bounds are " + status)
            continue
        header = resolve_level(compiler, test["version"])["level"]
        if (level_tuple(header) < level_tuple(row["since"])
                or (row.get("until") and level_tuple(header) > level_tuple(row["until"]))) and row["basis"] != "departure-witness":
            errors.append(test["test_id"] + ": header Version is outside its measured interval")
        if header not in row["observations"]:
            errors.append(test["test_id"] + ": header Version has no observation")
        since[row["since"]] += 1
        bases[row["basis"]] += 1
        methods[row["method"]] += 1
        if row.get("until") or row["other_passing_levels"]:
            rows.append({"test_id": test["test_id"], "since": row["since"], "until": row.get("until", ""),
                         "other_passing_levels": row["other_passing_levels"]})
    current = {(t["source_sha256"], t["test_id"]) for t in tests}
    recorded = {(source, test_id) for source, values in metadata["rows"].items() for test_id in values}
    if recorded != current:
        errors.append("Version row inventory differs from the current source inventory")
    return {"suite_id": suite_id, "tests": len(tests), "since_distribution": dict(since), "bases": dict(bases),
            "methods": dict(methods), "finite_or_disconnected_intervals": rows, "sample": sample, "errors": errors}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--select", help="Exact selection used by an external pilot")
    parser.add_argument("--pilot-versions", type=Path, help="Check an external pilot without installing public bounds")
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    suites = args.suite or installed_suites()
    if args.pilot_versions:
        if args.select is None or len(suites) != 1:
            parser.error("--pilot-versions requires --select and one standard")
        tests = [test for test in load_manifest(suite_id=suites[0]) if re.search(args.select, test["test_id"])]
        selected = use_pilot_versions(args.pilot_versions, tests)
        rows = [version_audit(suites[0], selected, min(200, len(selected)))]
    else:
        if args.select is not None:
            parser.error("--select requires --pilot-versions")
        rows = [version_audit(suite_id) for suite_id in suites]
    errors = [e for row in rows for e in row["errors"]]
    emit_audit(args.report, {"suites": rows, "errors": errors, "error_count": len(errors)})
    return 1 if errors else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
