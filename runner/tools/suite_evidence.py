"""Verify saved inputs and replay verdicts from immutable compiler and runtime observations."""
from __future__ import annotations

import hashlib
import json
import re
from pathlib import Path

from suite_common import canonical, fixture_info, inside, raw_sources, sha
from suite_diagnostics import compilation_verdict, parse_diagnostics, runtime_verdict, source_checks

CONTRACT_EXCLUSIONS = {"since", "until", "version_status", "versions_row_sha256"}


def verify_record(context, test, record, level, mode="test", executed_bytes=None, skip_status=None):
    """Raise on changed evidence, an invalid command, or a verdict unsupported by its observations."""
    source = context.source_path(test)
    if sha(source) != test["source_sha256"]:
        raise ValueError("Evidence source is stale")
    raw = source.read_bytes() if executed_bytes is None else executed_bytes
    fixture = json.loads(test["fixture_json"])
    if test["suite_id"] != "controls" and fixture_info(fixture, test["suite_id"], test["path"].split("/")[1],
            test["path"] in raw_sources(test["suite_id"]), json.loads(test["source_diagnostic_json"])) != test["fixture_sha256"]:
        raise ValueError("Evidence fixture is stale")
    if (record["identity_sha256"] != context.identity_sha256
            or record["fingerprint"] != context.fingerprint(test, level, mode, executed_bytes)
            or record["executed_source_sha256"] != hashlib.sha256(raw).hexdigest()
            or record["expected_stdout_json"] != test["stdout_json"]
            or any(record.get(k) != v for k, v in test.items() if k not in CONTRACT_EXCLUSIONS | {"stdout_json"})
            or record["mode"] != mode or record["level"] != (level["level"] if level else test["version"])):
        raise ValueError("Evidence identity/contract is stale")
    directory = canonical(record["artifact_directory"])
    result_path = context.case_directory(test, level, mode) / "result.json"
    if not directory.is_relative_to(result_path.parent) or canonical(record["result_path"]) != result_path:
        raise ValueError("Evidence directory is outside its case")
    if json.loads((directory / "result.json").read_text(encoding="utf-8")) != record:
        raise ValueError("Saved result differs from its immutable attempt copy")
    actual = {p.relative_to(directory).as_posix(): sha(p) for p in directory.rglob("*") if p.is_file() and p != directory / "result.json"}
    if not actual or actual != record["evidence_sha256"]:
        raise ValueError("Evidence files changed or their inventory is incomplete")
    artifacts = {str(p): sha(p) for p in sorted((directory / "artifacts").glob("*")) if p.is_file()}
    program = directory / "artifacts" / ("program" + context.artifact_extension)
    if artifacts != record["artifacts"] or record["artifact_sha256"] != (sha(program) if program.is_file() else None):
        raise ValueError("Artifact inventory differs")
    status, reason, missing = context.preflight(test, level, fixture, mode)
    if skip_status:
        status, reason, missing = skip_status, "outside-applicability", []
    if missing != record["missing_capabilities"]:
        raise ValueError("Preflight capability result differs")
    stages = [*fixture.get("libraries", []), fixture.get("program", {})]
    outputs, diagnostics, codes, failed_checks = {}, [], set(), []
    first_program, need_runtime, last_command, last_exit = None, False, [], ""
    if status and record["stages"]:
        raise ValueError("Preflight outcome must not execute a stage")
    if not status:
        for index, stage in enumerate(stages):
            is_library = index < len(stages) - 1
            name = stage["name"] if is_library else "program"
            if index >= len(record["stages"]):
                raise ValueError("Missing compile stage")
            observation = record["stages"][index]
            output = directory / "artifacts" / (name + (context.config["artifact_extension"] if is_library else context.artifact_extension))
            units = []
            for unit_index, unit in enumerate(stage.get("units", [{"source": "self"}])):
                unit_raw = raw if unit["source"] == "self" else inside(source.parents[2], unit["source"]).read_bytes()
                defines = b"".join(("#define " + symbol + "\n").encode("ascii") for symbol in unit.get("defines", []))
                unit_path = directory / "sources" / (name + "-unit-" + str(unit_index) + ".cs")
                if unit_path.read_bytes() != defines + unit_raw:
                    raise ValueError("Executed compilation unit differs from the declared source")
                units.append(unit_path)
            if not is_library:
                first_program = units[0]
            references = [(Path(context.target_assets[asset]), None) for asset in context.target_config["references"].values()]
            for reference in stage.get("references", []):
                path = outputs[reference["library"]] if "library" in reference else Path(context.target_assets[context.target_config["references"][reference["asset"]]])
                pair = path, reference.get("alias")
                if pair not in references:
                    references.append(pair)
            command = context.command(units, output, level, "library" if is_library else "exe",
                                      json.loads(test["requirements_json"]), references, stage.get("entry_point"))
            streams = [(directory / (name + ".compile." + stream + ".txt")).read_text(encoding="utf-8") for stream in ("stdout", "stderr")]
            parsed, information = parse_diagnostics(*streams, context.config["diagnostics"], name)
            diagnostics.extend(parsed)
            codes.update(information)
            verdict, detail = compilation_verdict(observation["exit"], parsed, output.is_file(), context.config)
            if (observation["name"] != name or observation["command"] != command
                    or observation["verdict"] != verdict or observation["reason"] != detail
                    or observation["artifact"] != (str(output) if output.is_file() else None)):
                raise ValueError("Compile stage cannot be replayed from its command and observations")
            last_command, last_exit = command, observation["exit"]
            if verdict not in {"accepted", "rejected"}:
                status, reason = verdict, detail
            elif is_library and verdict == "rejected":
                status, reason = "unexpected-reject", "fixture-prerequisite:" + name
            elif is_library:
                outputs[name] = output
                continue
            elif mode == "compile-only":
                status, reason = ("pass", "") if verdict == "accepted" else ("unexpected-reject", "compile-only")
            elif test["expected"] == "reject" or mode == "version-gating":
                status, reason = ("pass", "") if verdict == "rejected" else ("unexpected-accept", "required-rejection")
            elif verdict == "rejected":
                status, reason = "unexpected-reject", "required-compilation"
            else:
                status, reason, need_runtime = "pass", "", True
            if len(record["stages"]) != index + 1:
                raise ValueError("Unexpected compile stages after the final verdict")
            break
    if status == "pass" and mode not in {"compile-only", "version-gating"}:
        program_diagnostics = [d for d in diagnostics if d["stage"] == "program"]
        warnings = any(d["severity"] == "warning" for d in program_diagnostics)
        if test["diagnostic"] and ((test["diagnostic"] == "warning") != warnings):
            failed_checks.append("warning-" + test["diagnostic"])
        if first_program:
            failed_checks.extend(source_checks(json.loads(test["source_diagnostic_json"]), program_diagnostics,
                                               first_program.read_bytes(), first_program))
        if failed_checks:
            status, reason, need_runtime = "diagnostic-fail", ";".join(failed_checks), False
    stdout, stderr = [(directory / ("run." + stream + ".txt")).read_text(encoding="utf-8") for stream in ("stdout", "stderr")]
    if json.loads(record["stdout_json"]) != stdout or json.loads(record["stderr_json"]) != stderr:
        raise ValueError("Runtime streams differ from their evidence")
    if need_runtime:
        if record["run_exit"] == "":
            raise ValueError("Required runtime observation is missing")
        if context.target_config["adapter"] in {"dotnet", "netframework"}:
            command = context.target.command({"entry": str(program), "arguments": fixture.get("arguments", [])})
            if json.loads(record["run_command_json"]) != command:
                raise ValueError("Runtime command differs from its target configuration")
        status, reason = runtime_verdict({"exit": record["run_exit"], "stdout": stdout, "stderr": stderr}, json.loads(test["stdout_json"]))
    elif record["run_exit"] != "" or json.loads(record["run_command_json"]) or stdout or stderr:
        raise ValueError("Unexpected runtime execution")
    expected = {"status": status, "reason": reason, "unsupported_reason": reason if status == "unsupported" else "",
                "diagnostics": diagnostics, "diagnostic_codes": ";".join(sorted(codes)),
                "error_diagnostic_codes": ";".join(sorted({d["code"] for d in diagnostics if d["severity"] == "error" and d["code"]})),
                "uncoded_error_diagnostics": any(d["severity"] == "error" and not d["code"] for d in diagnostics),
                "compile_exit": last_exit, "failed_checks": failed_checks,
                "failed_cases_json": json.dumps(re.findall(r"^FAIL (.+)$", stdout, re.MULTILINE))}
    if any(record[k] != v for k, v in expected.items()) or json.loads(record["compile_command_json"]) != last_command:
        raise ValueError("Saved classification differs from replayed observations")
    return record
