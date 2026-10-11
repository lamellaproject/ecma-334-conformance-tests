"""Derive manifests from source headers; header-Version runs can precede bounds computation."""
import argparse
import sys
from collections import Counter
from pathlib import Path

from suite_common import emit_audit, installed_suites, main_guard, read_manifest, standard_root, write_manifest
from suite_versions import joined_tests


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--check", action="store_true")
    parser.add_argument("--report", type=Path)
    args = parser.parse_args()
    observations = []
    for suite_id in args.suite or installed_suites():
        rows = joined_tests(suite_id)
        path = standard_root(suite_id) / "manifest.tsv"
        if args.check:
            if read_manifest(path) != rows:
                raise ValueError("Manifest is stale: " + suite_id)
        else:
            write_manifest(path, rows)
        observations.append({"suite_id": suite_id, "tests": len(rows),
                             "version_status": dict(Counter(r["version_status"] for r in rows))})
    data = {"manifest_checked": args.check, "suites": observations, "errors": []}
    if args.report:
        emit_audit(args.report, data)
    else:
        import json
        print(json.dumps(data))
    return 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
