"""Validate ownership, text-block inventories, test coverage and registered source quotations."""
import argparse
import sys
from pathlib import Path

from suite_audits import ledger_audit
from suite_common import emit_audit, installed_suites, main_guard


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--source-map", type=Path, help="Explicit external source paths; all assets must match registered hashes")
    parser.add_argument("--require-confirmed", action="store_true")
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    rows = [ledger_audit(s, args.source_map, args.require_confirmed) for s in args.suite or installed_suites()]
    errors = [e for row in rows for e in row["errors"]]
    emit_audit(args.report, {"suites": rows, "suites_checked": len(rows), "error_count": len(errors), "errors": errors})
    return 1 if errors else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
