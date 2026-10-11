"""Replay pinned csc evidence and check informational Csc headers at each test's Version."""
import argparse
import sys
from pathlib import Path

from suite_audits import csc_audit
from suite_common import ROOT, emit_audit, installed_suites, main_guard


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--compiler", type=Path, default=ROOT / "configs/compilers/csc.json")
    parser.add_argument("--target", type=Path, default=ROOT / "configs/targets/dotnet.json")
    parser.add_argument("--results", type=Path, required=True)
    parser.add_argument("--select", help="Audit a subset while retaining all of the run's controls")
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    data = csc_audit(args.suite or installed_suites(), args.compiler, args.target, args.results, args.select)
    emit_audit(args.report, {**data, "error_count": len(data["errors"])})
    return 1 if data["errors"] else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
