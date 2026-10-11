"""Check portable public text, current manifests/bounds, sources and pinned csc evidence before publishing."""
import argparse
import hashlib
import importlib.util
import os
import re
import sys
from pathlib import Path

from suite_audits import csc_audit, ledger_audit, raw_audit
from suite_common import ROOT, emit_audit, installed_suites, load_manifest, main_guard, raw_sources, sha

NOTICE_BLOCK_SHA256 = "44d669633f3502e5d57ce1c32d5f6a8772e8b617ebf024a0ac50526aaad63a2b"


def text_audit(suite_ids):
    raw = {suite_id + "/" + path for suite_id in suite_ids for path in raw_sources(suite_id)}
    errors, files = [], []
    for base, directories, names in os.walk(ROOT):
        directories[:] = [name for name in directories if name not in (".git", "__pycache__")]
        for name in names:
            path = Path(base) / name
            relative = path.relative_to(ROOT).as_posix()
            data = path.read_bytes()
            files.append({"path": relative, "sha256": sha(path)})
            if relative in raw:
                continue
            if relative == "NOTICE":
                prefix = b"Copyright (c) Lamella LLC and Contributors\n\n"
                if not data.startswith(prefix) or hashlib.sha256(data[len(prefix):]).hexdigest() != NOTICE_BLOCK_SHA256:
                    errors.append("NOTICE: copyright line or verbatim ECMA legal block differs")
                continue
            if not data.isascii() or b"\r" in data or not data.endswith(b"\n"):
                errors.append(relative + ": public text must be ASCII with LF line ends")
                continue
            text = data.decode("ascii")
            if re.search(r"(?<![A-Za-z0-9_])[A-Za-z]:[/\\]|(?<![\w:])/(?:home|Users|tmp|usr|opt|mnt|private)/", text):
                errors.append(relative + ": absolute machine path")
            if re.search(r"Copyright[^\n]*\b[12][0-9]{3}\b[^\n]*Lamella|Copyright[^\n]*Lamella[^\n]*\b[12][0-9]{3}\b", text):
                errors.append(relative + ": suite copyright line states a year")
            if (path.suffix == ".cs" or name.endswith(".cs.part")) and b"\t" in data:
                errors.append(relative + ": tabs in source")
    required = ["README.md", "LICENSE-MIT", "LICENSE-APACHE", "NOTICE", ".gitattributes",
                "docs/ARCHITECTURE.md", "docs/CONVENTIONS.md", "docs/CONTRIBUTING.md", "docs/RESULTS.md"]
    errors.extend("Missing public document: " + path for path in required if not (ROOT / path).is_file())
    for name, line in [("LICENSE-MIT", "Copyright (c) Lamella LLC and Contributors"),
                       ("LICENSE-APACHE", "Copyright (c) Lamella LLC and Contributors")]:
        if sum(row.strip() == line for row in (ROOT / name).read_text(encoding="ascii").split("\n")) != 1:
            errors.append(name + ": incorrect suite copyright line")
    return {"files_checked": len(files), "files": files, "errors": errors}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--suite", action="append")
    parser.add_argument("--compiler", type=Path, default=ROOT / "configs/compilers/csc.json")
    parser.add_argument("--target", type=Path, default=ROOT / "configs/targets/dotnet.json")
    parser.add_argument("--csc-results", type=Path, required=True)
    parser.add_argument("--source-map", type=Path, required=True)
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    suites = args.suite or installed_suites()
    text = text_audit(suites)
    errors, checks = list(text["errors"]), {}
    spec = importlib.util.spec_from_file_location("check_versions", Path(__file__).with_name("check-versions.py"))
    versions = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(versions)
    for suite_id in suites:
        for name, audit in [("ledger", lambda: ledger_audit(suite_id, args.source_map, True)),
                            ("raw-source", lambda: raw_audit(suite_id)),
                            ("versions", lambda: versions.version_audit(suite_id))]:
            key = suite_id + ":" + name
            try:
                result = audit()
                checks[key] = result
                errors.extend(result["errors"])
            except (OSError, ValueError, KeyError, TypeError) as error:
                errors.append(key + ": " + str(error))
    try:
        csc = csc_audit(suites, args.compiler, args.target, args.csc_results)
        checks["csc"] = csc
        errors.extend(csc["errors"])
    except (OSError, ValueError, KeyError, TypeError) as error:
        errors.append("csc: " + str(error))
    emit_audit(args.report, {"files_checked": text["files_checked"], "files": text["files"], "checks": checks,
                             "errors": errors, "error_count": len(errors)})
    return 1 if errors else 0


if __name__ == "__main__":
    sys.exit(main_guard(main))
