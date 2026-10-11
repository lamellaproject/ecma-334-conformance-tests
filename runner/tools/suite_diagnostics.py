"""Typed diagnostics and the compiler-neutral checks they can satisfy."""
from __future__ import annotations

import re
from pathlib import Path

from suite_common import csharp_lines


def parse_diagnostics(stdout, stderr, config, stage="program"):
    patterns = [re.compile(p, re.IGNORECASE) for p in config["patterns"]]
    result = []
    for stream, value in [("stdout", stdout), ("stderr", stderr)]:
        for text in value.split("\n"):
            match = next((m for pattern in patterns if (m := pattern.search(text))), None)
            if not match:
                continue
            fields = match.groupdict()
            result.append({"stage": stage, "stream": stream, "severity": fields["severity"].lower(),
                "code": fields.get("code") or "", "file": fields.get("file") or "",
                "line": int(fields["line"]) if fields.get("line") else None,
                "column": int(fields["column"]) if fields.get("column") else None,
                "message": fields.get("message") or "", "text": text})
    pattern = config.get("information_pattern")
    information = set(re.findall(pattern, stdout + "\n" + stderr)) if pattern else set()
    return result, sorted(information | {d["code"] for d in result if d["code"]})


def compilation_verdict(exit_code, diagnostics, artifact_exists, compiler):
    """Return an internal accepted/rejected verdict or a fixed failure category/reason."""
    codes = {d["code"] for d in diagnostics if d["code"]}
    policy = compiler["diagnostics"]
    if codes & set(policy["command_line_codes"]):
        return "infrastructure", "command-line"
    if exit_code not in [0, *compiler["rejection_exit_codes"]]:
        return "compiler-error", str(exit_code)
    if exit_code != 0:
        if codes & set(policy["feature_refusal_codes"]):
            return "unsupported", "feature-refusal"
        if not any(d["severity"] == "error" and d["code"] for d in diagnostics):
            return "unexpected-reject", "uncoded-rejection"
        return "rejected", ""
    if any(d["severity"] == "error" for d in diagnostics):
        return "compiler-error", "contradictory-verdict"
    if not artifact_exists:
        return "compiler-error", "missing-artifact"
    return "accepted", ""


def source_checks(observations, diagnostics, raw, physical_file):
    lines = csharp_lines(raw)
    failures = []
    for observation in observations:
        physical = lines.index(observation["source"]) + 1 if lines.count(observation["source"]) == 1 else None
        expected_line = physical if observation["line"] == "physical" else observation["line"]
        expected_file = str(physical_file) if observation["file"] == "physical" else observation["file"]
        # A compiler may print a full input path or its basename; logical #line filenames stay exact.
        def filename_matches(actual):
            printed, wanted = actual.replace("\\", "/"), expected_file.replace("\\", "/")
            if printed == wanted:
                return True
            if observation["file"] == "physical":
                return Path(printed).name == Path(wanted).name
            # csc renders a relative #line filename relative to the input unit's directory.
            logical = Path(wanted)
            expected_path = logical if logical.is_absolute() else Path(physical_file).parent / logical
            candidate = Path(printed)
            candidate = candidate if candidate.is_absolute() else Path(physical_file).parent.parent / candidate
            return candidate.resolve() == expected_path.resolve()
        matching = [d for d in diagnostics if d["stage"] == "program" and d["severity"] == observation["severity"]
                    and d["line"] == expected_line and filename_matches(d["file"])
                    and observation.get("contains", "") in d["message"]]
        if expected_line is None or not matching:
            failures.append("source-diagnostic:" + observation["case_id"])
    return failures


def runtime_verdict(result, expected_stdout):
    if result["exit"] == "launch-error":
        return "infrastructure", "target-launch"
    if result["exit"] == "timeout":
        return "runtime-fail", "timeout"
    if result["exit"] != 0:
        text = result["stdout"] + "\n" + result["stderr"]
        return "runtime-fail", "unhandled-exception" if re.search(r"Unhandled exception|Stack overflow", text, re.IGNORECASE) else "nonzero-exit"
    if result["stdout"] != expected_stdout:
        return "runtime-fail", "wrong-output"
    return "pass", ""
