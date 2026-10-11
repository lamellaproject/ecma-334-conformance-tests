"""Enforce the tracked-file size cap and room for threefold growth."""
import argparse
import subprocess
import sys
from pathlib import Path

from suite_common import ROOT, emit_audit, inside, main_guard

LIMIT = 20 * 1024 * 1024


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    names = subprocess.check_output(["git", "-C", str(ROOT), "ls-files", "-z"]).decode("utf-8").split("\0")
    files, errors = [], []
    for relative in sorted(set(names) - {""}):
        size = inside(ROOT, relative).stat().st_size
        files.append({"path": relative, "bytes": size})
        if size > LIMIT:
            errors.append(relative + ": exceeds tracked-file cap")
        elif size * 3 > LIMIT:
            errors.append(relative + ": lacks threefold growth headroom")
    emit_audit(args.report, {"limit_bytes": LIMIT, "growth_factor": 3, "files_checked": len(files),
        "largest": max(files, key=lambda row: row["bytes"]), "rows": files, "errors": errors, "error_count": len(errors)})
    return 1 if errors else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
