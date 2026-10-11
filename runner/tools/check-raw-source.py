"""Verify inventoried exceptional bytes, hashes, header parsing and Git byte preservation."""
import argparse
import sys
from pathlib import Path

from suite_audits import raw_audit
from suite_common import emit_audit, installed_suites, main_guard


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    rows = [raw_audit(s) for s in args.suite or installed_suites()]
    errors = [e for row in rows for e in row["errors"]]
    emit_audit(args.report, {"suites": rows, "suites_checked": len(rows), "error_count": len(errors), "errors": errors})
    return 1 if errors else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
