"""Regenerate twice in explicit output directories and verify source bytes and named cases."""
import argparse
import json
import re
import subprocess
import sys
import time
import uuid
from collections import defaultdict
from pathlib import Path

from suite_common import (emit_audit, header_body, installed_suites, load_manifest, main_guard,
                          read_tsv, sha, suite_path)


def check_cases(tests, cells, errors):
    required = {"test_id", "case_id", "rule_ids", "prerequisites"}
    if not cells or list(cells[0]) != ["test_id", "case_id", "rule_ids", "prerequisites", "checks"]:
        raise ValueError("Case maps require test_id, case_id, rule_ids, prerequisites and checks, in that order")
    if len({(c["test_id"], c["case_id"]) for c in cells}) != len(cells):
        errors.append("Case map repeats a case ID within a test")
    if {c["test_id"] for c in cells} != {t["test_id"] for t in tests}:
        errors.append("Case map and generated test inventories differ")
    indexed = defaultdict(list)
    for cell in cells:
        indexed[cell["test_id"]].append(cell)
    for test in tests:
        rows = indexed[test["test_id"]]
        prefix = test["test_id"] + ": "
        if (not rows or len(rows) > 16 or len({r["prerequisites"] for r in rows}) != 1
                or any(not r["prerequisites"] or not r["case_id"] or r["rule_ids"] != test["rule_ids"] for r in rows)):
            errors.append(prefix + "missing/oversized batch or inconsistent prerequisites/rules")
        if test["expected"] == "reject" and len(rows) != 1:
            errors.append(prefix + "rejected cases must be isolated")
        if any("checks" in r and not re.fullmatch(r"0|[1-9][0-9]*", r["checks"]) for r in rows):
            errors.append(prefix + "invalid indexed check count")
            continue
        if test["expected"] == "reject":
            if any(int(r.get("checks", "0")) != 0 for r in rows):
                errors.append(prefix + "reject case declares runtime checks")
            continue
        _, raw_body = header_body(suite_path(test["path"], test["suite_id"]).read_bytes())
        body = raw_body.decode("utf-8")
        named = set(re.findall(r'\bCheck\([^\n]*,\s*"([^"\n]+)"\s*\);', body))
        observations = {o["case_id"] for o in json.loads(test["source_diagnostic_json"])}
        expected_names = {r["case_id"] for r in rows}
        if named | observations != expected_names:
            errors.append(prefix + "named runtime/diagnostic checks differ from indexed cases")
        count = sum(int(r.get("checks", "0" if r["case_id"] in observations else "1")) for r in rows)
        if json.loads(test["stdout_json"]) != f"OK {count}\n":
            errors.append(prefix + "Stdout count differs from indexed runtime checks")


def audit(suites, work_root):
    errors, records, test_count, case_count = [], [], 0, 0
    # Fresh roots retain evidence without relying on the suite's repository placement.
    work_root = Path(work_root).resolve() / ("g-" + uuid.uuid4().hex[:8])
    work_root.mkdir(parents=True)
    for suite_id in suites:
        tests = [t for t in load_manifest(suite_id=suite_id) if t["origin"] == "generated"]
        groups = defaultdict(list)
        for test in tests:
            groups[test["generator"]].append(test)
        test_count += len(tests)
        for index, (name, group) in enumerate(sorted(groups.items())):
            generator = suite_path(name, suite_id)
            case_map = str(Path(name).with_suffix(".cases.tsv")).replace("\\", "/")
            expected = {t["path"] for t in group} | {case_map}
            runs = []
            for repeat in ("a", "b"):
                output = work_root / (str(len(records)) + repeat)
                output.mkdir(parents=True)
                command = [sys.executable, "-B", str(generator), "--output-root", str(output)]
                started = time.monotonic()
                completed = subprocess.run(command, capture_output=True, text=True, timeout=120, shell=False)
                actual = {p.relative_to(output).as_posix() for p in output.rglob("*") if p.is_file()}
                if completed.returncode or actual != expected:
                    errors.append(f"{suite_id}/{name}: exit={completed.returncode}, missing={len(expected - actual)}, extra={len(actual - expected)}")
                changed = [p for p in sorted(expected) if not (output / p).is_file()
                           or sha(output / p) != sha(suite_path(p, suite_id))]
                if changed:
                    errors.append(f"{suite_id}/{name}: {len(changed)} missing/different regenerated files; see changed_files")
                runs.append({"command": command, "exit_code": completed.returncode,
                             "elapsed_seconds": time.monotonic() - started, "stdout": completed.stdout,
                             "stderr": completed.stderr, "output_root": str(output), "changed_files": changed,
                             "missing_files": sorted(expected - actual), "extra_files": sorted(actual - expected)})
            cells = read_tsv(suite_path(case_map, suite_id))
            check_cases(group, cells, errors)
            case_count += len(cells)
            records.append({"suite_id": suite_id, "generator": name, "generator_sha256": sha(generator),
                            "case_map_sha256": sha(suite_path(case_map, suite_id)), "programs": len(group),
                            "cases": len(cells), "regenerations": runs})
    return {"generators": len(records), "generated_tests": test_count, "generated_cases": case_count,
            "work_root": str(work_root), "rows": records, "errors": errors}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--report", type=Path, required=True)
    parser.add_argument("--work-root", type=Path, help="Defaults to a sibling of the report")
    args = parser.parse_args()
    result = audit(args.suite or installed_suites(), args.work_root or args.report.resolve().parent / "generated-work")
    emit_audit(args.report, result)
    return 1 if result["errors"] else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
