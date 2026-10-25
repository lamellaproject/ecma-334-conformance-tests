"""Check registered edition conflict tables against the complete source inventory."""
import argparse
from pathlib import Path
import sys

from suite_common import emit_audit, installed_suites, main_guard, scan_tests
from suite_editions import edition_audit


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    errors, checks = [], {}
    for suite_id in args.suite or installed_suites():
        result = edition_audit(suite_id, scan_tests(suite_id))
        checks[suite_id] = result
        errors.extend(suite_id + ": " + error for error in result["errors"])
    emit_audit(args.report, {"checks": checks, "errors": errors, "error_count": len(errors)})
    return 1 if errors else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
