"""Pinned fixture compilation, byte-preserving evidence and resumable verdicts."""
from __future__ import annotations

import json
import hashlib
import os
import re
import subprocess
import sys
import time
import uuid
from pathlib import Path

from suite_common import ROOT, MANIFEST_FIELDS, canonical, digest, fixture_info, inside, raw_sources, read_tsv, sha, standard_root, utc, write_bytes, write_json, write_text
from suite_config import expand, level_tuple, load_config, resolve_level
from suite_diagnostics import compilation_verdict, parse_diagnostics, runtime_verdict, source_checks
from suite_targets import Target

CATEGORIES = ["pass", "unsupported", "unexpected-reject", "unexpected-accept", "runtime-fail", "diagnostic-fail",
              "compiler-error", "infrastructure", "not-applicable"]
UNSUPPORTED_REASONS = ["feature-refusal", "level", "requirement", "target-capability"]
CONTROL_OUTCOMES = {
    "positive": ("pass", 0, 0), "failed-check": ("runtime-fail", 0, 0),
    "early-return": ("runtime-fail", 0, 0), "short-count": ("runtime-fail", 0, 0),
    "unhandled-exception": ("runtime-fail", 0, "nonzero"), "hang": ("runtime-fail", 0, "timeout"),
    "nonzero-exit": ("runtime-fail", 0, 7), "run-does-not-compile": ("unexpected-reject", "rejection", ""),
    "reject-compiles": ("unexpected-accept", 0, ""),
}
DEPARTURE_FIELDS = ["test_id", "kind", "rule_ids", "source_id", "locator", "quote_json", "source_sha256", "compiler_id",
                    "compiler_commit", "target_id", "levels_json", "observation_json", "status", "conforms_since", "notes"]


def controlled_env(output):
    env = os.environ.copy()
    for name, relative in {"TEMP": "tmp", "TMP": "tmp", "TMPDIR": "tmp", "DOTNET_CLI_HOME": "dotnet-home", "NUGET_PACKAGES": "nuget"}.items():
        path = output / ".environment" / relative
        path.mkdir(parents=True, exist_ok=True)
        env[name] = str(path)
    env.update(DOTNET_CLI_TELEMETRY_OPTOUT="1", DOTNET_SKIP_FIRST_TIME_EXPERIENCE="1", DOTNET_NOLOGO="1",
        DOTNET_MULTILEVEL_LOOKUP="0", DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_DISABLE="1", DOTNET_CLI_UI_LANGUAGE="en-US", VSLANG="1033")
    return env


def execute(argv, timeout, cwd, env):
    start = time.perf_counter()
    try:
        p = subprocess.run(argv, cwd=cwd, capture_output=True, encoding="utf-8", errors="replace",
                           timeout=timeout, shell=False, env=env)
        code, stdout, stderr = p.returncode, p.stdout, p.stderr
    except subprocess.TimeoutExpired as error:
        decode = lambda value: value.decode("utf-8", "replace") if isinstance(value, bytes) else value or ""
        code, stdout, stderr = "timeout", decode(error.stdout), decode(error.stderr)
    except OSError as error:
        code, stdout, stderr = "launch-error", "", str(error)
    normalize = lambda value: value.replace("\r\n", "\n").replace("\r", "\n")
    return code, normalize(stdout), normalize(stderr), time.perf_counter() - start


def load_controls():
    rows = []
    for path in sorted((ROOT / "runner/controls").glob("*.cs")):
        raw = path.read_bytes()
        if not raw.isascii() or b"\r" in raw or b"\t" in raw or not raw.endswith(b"\n") or not raw.startswith(b"/*\n"):
            raise ValueError("Invalid control source: " + str(path))
        pairs = [line.partition(": ") for line in raw[3:].split(b"\n*/\n", 1)[0].decode().split("\n")]
        metadata = {key: value for key, _, value in pairs}
        name, expected = metadata.get("Control"), metadata.get("Expected")
        wanted = ["Control", "Purpose", "Version", "Expected"] + (["Stdout"] if expected == "run" else [])
        if [key for key, _, _ in pairs] != wanted or any(not sep for _, sep, _ in pairs) or name not in CONTROL_OUTCOMES:
            raise ValueError("Malformed control metadata")
        if path.stem != name or expected not in {"run", "reject"} or not metadata["Purpose"] or metadata["Version"] != "7.3":
            raise ValueError("Invalid control identity")
        row = {key: "" for key in MANIFEST_FIELDS}
        row.update(suite_id="controls", test_id="control--" + name, path=path.relative_to(ROOT).as_posix(), authority="harness control",
            version=metadata["Version"], expected=expected, stdout_json=json.dumps(metadata.get("Stdout", "") + "\n" if expected == "run" else ""),
            origin="control", source_sha256=sha(path), requirements_json="[]", fixture_json="{}", source_diagnostic_json="[]", fixture_sha256=digest({}),
            version_status="not-required")
        rows.append(row)
    if {r["test_id"].removeprefix("control--") for r in rows} != set(CONTROL_OUTCOMES):
        raise ValueError("Missing required controls")
    return rows


def control_level(config, test):
    """Keep the control's declared level, or use the highest supported lower level."""
    original = resolve_level(config, test["version"])
    if original is not None:
        return original
    candidates = [name for name in config["language"]["explicit"]
                  if level_tuple(name) <= level_tuple(test["version"])]
    if not candidates:
        raise ValueError("No supported control language level")
    return resolve_level(config, max(candidates, key=level_tuple))


def departure_rows(suite_id):
    result = {}
    if suite_id == "controls":
        return result
    for path in sorted((standard_root(suite_id) / "clauses").glob("*/departures.tsv")):
        for row in read_tsv(path, DEPARTURE_FIELDS):
            if row["test_id"] in result:
                raise ValueError("Duplicate departure: " + row["test_id"])
            if row["kind"] not in {"compiler", "hosted-runtime"} or row["status"] not in {"confirmed", "pending"}:
                raise ValueError("Invalid departure kind/status")
            result[row["test_id"]] = row
    return result


class Context:
    def __init__(self, compiler_path, target_path, output, compile_timeout=60, run_timeout=20, *, evidence_provenance=None):
        self.evidence_only = evidence_provenance is not None
        self.config_path, self.target_path = canonical(compiler_path), canonical(target_path)
        self.config, self.compiler_assets, compiler_identity = load_config(self.config_path, "compiler")
        self.target_config, self.target_assets, target_identity = load_config(self.target_path, "target")
        self.artifact_extension = self.target_config["build"].get("artifact_extension", self.config["artifact_extension"])
        if min(compile_timeout, run_timeout) <= 0:
            raise ValueError("Timeouts must be positive")
        self.output = canonical(output)
        if self.evidence_only:
            if not self.output.is_dir():
                raise ValueError("Recorded evidence directory is missing")
        else:
            self.output.mkdir(parents=True, exist_ok=True)
        self.compile_timeout, self.run_timeout = compile_timeout, run_timeout
        self.env = {} if self.evidence_only else controlled_env(self.output)
        self.target = Target(self.target_config, self.target_assets, self.output, self.execute)
        self.identity = {"compiler_identity": compiler_identity, "target_identity": target_identity, "compile_timeout": compile_timeout,
                         "run_timeout": run_timeout, "suite_files": {p.relative_to(ROOT).as_posix(): sha(p) for p in [
            ROOT / "runner/run-suite.py", *[ROOT / "runner/tools" / name for name in ["suite_common.py", "suite_config.py",
            "suite_diagnostics.py", "suite_targets.py", "suite_engine.py", "suite_versions.py", "suite_evidence.py", "suite_editions.py"]],
            *sorted((ROOT / "runner/controls").glob("*.cs"))] if p.is_file()}}
        if self.target_config["adapter"] == "netframework":
            self.identity["suite_files"]["runner/tools/suite_netframework.py"] = sha(ROOT / "runner/tools/suite_netframework.py")
        self.identity_sha256 = digest(self.identity)
        self.replay_identity = None
        self.observation_provenance = evidence_provenance
        if self.evidence_only:
            # Implementation hashes identify the original execution. The current
            # verifier independently checks every source, command and verdict.
            try:
                recorded = {key: evidence_provenance[key] for key in self.identity}
                if (digest(recorded) != evidence_provenance["identity_sha256"]
                        or any(recorded[key] != self.identity[key] for key in
                               ["compiler_identity", "target_identity", "compile_timeout", "run_timeout"])
                        or set(recorded["suite_files"]) != set(self.identity["suite_files"])
                        or any(not isinstance(value, str) or not re.fullmatch(r"[0-9a-f]{64}", value)
                               for value in recorded["suite_files"].values())):
                    raise ValueError("Recorded execution assets, limits or identity differ")
            except (KeyError, TypeError) as error:
                raise ValueError("Recorded execution provenance is malformed") from error
            self.replay_identity = self.identity
            self.identity, self.identity_sha256 = recorded, evidence_provenance["identity_sha256"]
        self._departures = {}

    @classmethod
    def from_evidence(cls, compiler_path, target_path, output, provenance):
        """Replay immutable observations with their identity; never execute or replace them."""
        return cls(compiler_path, target_path, output, provenance["compile_timeout"], provenance["run_timeout"],
                   evidence_provenance=provenance)

    def execute(self, argv, timeout, cwd):
        if self.evidence_only:
            raise ValueError("Evidence contexts cannot execute commands")
        return execute(argv, timeout, cwd, self.env)

    def provenance(self):
        try:
            commit = subprocess.check_output(["git", "-C", str(ROOT), "rev-parse", "HEAD"], stderr=subprocess.DEVNULL, text=True).strip()
        except (OSError, subprocess.SubprocessError):
            commit = None
        result = {"command": [sys.executable, *sys.argv], "suite_commit": commit, "compiler_commit": self.config["commit"],
                "compiler_version": self.config["version"], "target": self.target_config["description"],
                "execution_target": self.target_config["id"], "identity_sha256": self.identity_sha256, **self.identity}
        if self.evidence_only:
            result.update(observed_suite_commit=self.observation_provenance.get("suite_commit"),
                          observed_command=self.observation_provenance.get("command"), replay_identity=self.replay_identity)
        return result

    def source_path(self, test):
        return inside(ROOT, test["path"]) if test["suite_id"] == "controls" else inside(standard_root(test["suite_id"]), test["path"])

    def case_directory(self, test, level=None, mode="test"):
        if not re.fullmatch(r"[A-Za-z0-9_.-]+", test["test_id"]) or not re.fullmatch(r"[A-Za-z0-9_.-]+", mode):
            raise ValueError("Unsafe result identity")
        label = (level or resolve_level(self.config, test["version"]) or {"level": "unsupported-" + test["version"]})["level"]
        if not re.fullmatch(r"[A-Za-z0-9_.-]+", label):
            raise ValueError("Unsafe result level")
        # Full public IDs remain in every record; a compact stable key keeps
        # generated IDs and fresh attempt paths within Windows path limits.
        key = digest([test["suite_id"], test["test_id"]])[:32]
        return self.output / "cases" / key / label / mode

    def fingerprint(self, test, level=None, mode="test", executed_bytes=None):
        # Generated version metadata may be added after a header-Version run without changing its source verdict.
        contract = {k: v for k, v in test.items() if k not in {"since", "until", "version_status", "versions_row_sha256"}}
        return digest({"identity": self.identity_sha256, "test": contract, "level": level or resolve_level(self.config, test["version"]),
                       "mode": mode, "executed_sha256": hashlib.sha256(executed_bytes).hexdigest() if executed_bytes is not None else test["source_sha256"]})

    def command(self, units, output, level, kind, requirements, references, entry_point):
        args = self.config["arguments"]
        reference_args = []
        for path, alias in references:
            template = args["alias_reference"] if alias else args["reference"]
            if template is None:
                raise ValueError("Unsupported reference operation escaped preflight")
            reference_args.extend(expand(template, {"path": str(path), "alias": alias or ""}))
        return expand(self.config["command"], {**self.compiler_assets, "level": level["argument"], "output": str(output)},
            {"sources": [str(p) for p in units], "references": reference_args,
             "requirements": [v for name in requirements for v in self.config["requirements"][name]],
             "kind": args["kinds"][kind], "entry_point": expand(args["entry_point"], {"name": entry_point}) if entry_point else []})

    def preflight(self, test, level, fixture, mode):
        if level is None:
            return "unsupported", "level", [test["version"]]
        requirements = json.loads(test["requirements_json"])
        missing = [name for name in requirements if name not in self.config["requirements"]]
        if missing:
            return "unsupported", "requirement", missing
        if mode != "compile-only":
            missing = sorted(set(fixture.get("target_requires", [])) - set(self.target_config["capabilities"]))
            if missing:
                return "unsupported", "target-capability", missing
        stages = [*fixture.get("libraries", []), fixture.get("program", {})]
        for index, stage in enumerate(stages):
            kind = "library" if index < len(stages) - 1 else "exe"
            if self.config["arguments"]["kinds"][kind] is None or kind not in self.target_config["build"]["kinds"]:
                return "unsupported", "requirement", ["compilation-kind:" + kind]
            if stage.get("entry_point") and self.config["arguments"]["entry_point"] is None:
                return "unsupported", "requirement", ["entry-point"]
            if any(r.get("alias") for r in stage.get("references", [])) and self.config["arguments"]["alias_reference"] is None:
                return "unsupported", "requirement", ["extern-alias"]
            for reference in stage.get("references", []):
                if "asset" in reference and reference["asset"] not in self.target_config["references"]:
                    return "unsupported", "target-capability", ["reference:" + reference["asset"]]
        return "", "", []

    def compile(self, test, level=None, mode="test", executed_bytes=None, skip_status=None):
        if self.evidence_only:
            raise ValueError("Evidence contexts cannot compile or replace observations")
        level = level or resolve_level(self.config, test["version"])
        source_path = self.source_path(test)
        if sha(source_path) != test["source_sha256"]:
            raise ValueError("Source changed since manifest validation: " + test["test_id"])
        raw = source_path.read_bytes() if executed_bytes is None else executed_bytes
        directory = self.case_directory(test, level, mode)
        attempt = directory / ("attempt-" + uuid.uuid4().hex)
        attempt.mkdir(parents=True, exist_ok=True)
        fixture = json.loads(test["fixture_json"])
        if test["suite_id"] != "controls" and fixture_info(fixture, test["suite_id"], test["path"].split("/")[1],
                test["path"] in raw_sources(test["suite_id"]), json.loads(test["source_diagnostic_json"])) != test["fixture_sha256"]:
            raise ValueError("Fixture changed since manifest validation: " + test["test_id"])
        status, reason, missing = self.preflight(test, level, fixture, mode)
        if skip_status:
            status, reason, missing = skip_status, "outside-applicability", []
        record = {**test, "schema_version": 2, "level": level["level"] if level else test["version"], "level_argument": level["argument"] if level else "",
            "mode": mode, "status": status, "reason": reason, "unsupported_reason": reason if status == "unsupported" else "",
            "missing_capabilities": missing, "compile_exit": "", "diagnostic_codes": "", "error_diagnostic_codes": "",
            "uncoded_error_diagnostics": False, "run_exit": "", "compile_command_json": "[]", "run_command_json": "[]",
            "expected_stdout_json": test["stdout_json"], "stdout_json": '""', "stderr_json": '""', "failed_cases_json": "[]",
            "failed_checks": [], "diagnostics": [], "stages": [], "compile_seconds": 0.0, "run_seconds": 0.0,
            "compiler_id": self.config["id"], "compiler_commit": self.config["commit"], "target": self.target_config["description"],
            "execution_target": self.target_config["id"], "identity_sha256": self.identity_sha256,
            "fingerprint": self.fingerprint(test, level, mode, executed_bytes), "executed_source_sha256": "",
            "evidence_sha256": {}, "artifacts": {}, "artifact_sha256": None, "artifact_directory": str(attempt),
            "result_path": str(directory / "result.json"), "departure": False, "departure_kind": ""}
        record["executed_source_sha256"] = hashlib.sha256(raw).hexdigest()
        pending = {"record": record, "request": None}
        if status:
            return pending
        requirements = json.loads(test["requirements_json"])
        outputs, information, all_diagnostics = {}, set(), []
        stages = [*fixture.get("libraries", []), fixture.get("program", {})]
        first_program = None
        for index, stage in enumerate(stages):
            is_library = index < len(stages) - 1
            stage_name = stage["name"] if is_library else "program"
            output = attempt / "artifacts" / (stage_name + (self.config["artifact_extension"] if is_library else self.artifact_extension))
            output.parent.mkdir(parents=True, exist_ok=True)
            units = []
            for unit_index, unit in enumerate(stage.get("units", [{"source": "self"}])):
                unit_raw = raw if unit["source"] == "self" else inside(source_path.parents[2], unit["source"]).read_bytes()
                defines = b"".join(("#define " + name + "\n").encode("ascii") for name in unit.get("defines", []))
                unit_path = attempt / "sources" / (stage_name + "-unit-" + str(unit_index) + ".cs")
                write_bytes(unit_path, defines + unit_raw)
                units.append(unit_path)
            if not is_library:
                first_program = units[0]
            references = [(Path(self.target_assets[asset]), None) for asset in self.target_config["references"].values()]
            for reference in stage.get("references", []):
                path = outputs[reference["library"]] if "library" in reference else Path(self.target_assets[self.target_config["references"][reference["asset"]]])
                pair = (path, reference.get("alias"))
                if pair not in references:
                    references.append(pair)
            command = self.command(units, output, level, "library" if is_library else "exe", requirements, references, stage.get("entry_point"))
            code, stdout, stderr, seconds = self.execute(command, self.compile_timeout, attempt)
            diagnostics, codes = parse_diagnostics(stdout, stderr, self.config["diagnostics"], stage_name)
            information.update(codes)
            all_diagnostics.extend(diagnostics)
            for name, value in [(stage_name + ".compile.stdout.txt", stdout), (stage_name + ".compile.stderr.txt", stderr)]:
                write_text(attempt / name, value)
            verdict, detail = compilation_verdict(code, diagnostics, output.is_file(), self.config)
            record["stages"].append({"name": stage_name, "command": command, "exit": code, "verdict": verdict,
                                      "reason": detail, "seconds": seconds, "artifact": str(output) if output.is_file() else None})
            record["compile_seconds"] += seconds
            record["compile_exit"] = code
            record["compile_command_json"] = json.dumps(command)
            if verdict not in {"accepted", "rejected"}:
                record.update(status=verdict, reason=detail, unsupported_reason=detail if verdict == "unsupported" else "")
                break
            if is_library:
                if verdict == "rejected":
                    record.update(status="not-applicable" if mode == "version-gating" else "unexpected-reject",
                                  reason="fixture-prerequisite:" + stage_name)
                    break
                outputs[stage_name] = output
                continue
            if mode == "compile-only":
                record.update(status="pass" if verdict == "accepted" else "unexpected-reject", reason="" if verdict == "accepted" else "compile-only")
            elif test["expected"] == "reject" or mode == "version-gating":
                record.update(status="pass" if verdict == "rejected" else "unexpected-accept", reason="" if verdict == "rejected" else "required-rejection")
            elif verdict == "rejected":
                record.update(status="unexpected-reject", reason="required-compilation")
            else:
                record["status"] = "pass"
                runtimeconfig = self.target.prepare(output)
                artifacts = {str(path): sha(path) for path in [output, *outputs.values()]}
                if runtimeconfig:
                    artifacts[str(runtimeconfig)] = sha(runtimeconfig)
                pending["request"] = {"id": digest([test["suite_id"], test["test_id"], record["level"], mode]), "entry": str(output),
                    "arguments": fixture.get("arguments", []), "artifacts": artifacts,
                    "timeout_seconds": min(self.run_timeout, 1) if test["test_id"] == "control--hang" else self.run_timeout}
        record["diagnostics"] = all_diagnostics
        record["diagnostic_codes"] = ";".join(sorted(information))
        record["error_diagnostic_codes"] = ";".join(sorted({d["code"] for d in all_diagnostics if d["severity"] == "error" and d["code"]}))
        record["uncoded_error_diagnostics"] = any(d["severity"] == "error" and not d["code"] for d in all_diagnostics)
        if record["status"] == "pass" and mode not in {"compile-only", "version-gating"}:
            program_diagnostics = [d for d in all_diagnostics if d["stage"] == "program"]
            warnings = [d for d in program_diagnostics if d["severity"] == "warning"]
            if test["diagnostic"] and ((test["diagnostic"] == "warning") != bool(warnings)):
                record["failed_checks"].append("warning-" + test["diagnostic"])
            if first_program:
                record["failed_checks"].extend(source_checks(json.loads(test["source_diagnostic_json"]), program_diagnostics,
                                                             first_program.read_bytes(), first_program))
            if record["failed_checks"]:
                record.update(status="diagnostic-fail", reason=";".join(record["failed_checks"]))
                pending["request"] = None
        return pending

    def mark_departure(self, record):
        if record["suite_id"] not in self._departures:
            self._departures[record["suite_id"]] = departure_rows(record["suite_id"])
        row = self._departures[record["suite_id"]].get(record["test_id"])
        if not row or row["status"] != "confirmed" or record["status"] not in {"unexpected-reject", "unexpected-accept", "runtime-fail", "diagnostic-fail"}:
            return
        if record["mode"] != "test" or row["source_sha256"] != record["source_sha256"] or row["compiler_id"] != self.config["id"] or row["compiler_commit"] != self.config["commit"] or row["target_id"] != self.target_config["id"]:
            return
        if record["level"] not in json.loads(row["levels_json"]):
            return
        if row["conforms_since"] and level_tuple(record["level"]) >= level_tuple(row["conforms_since"]):
            return
        record["departure"], record["departure_kind"] = True, row["kind"]

    def finish(self, pending, runtime=None):
        if self.evidence_only:
            raise ValueError("Evidence contexts cannot replace observations")
        record = pending["record"]
        directory = Path(record["artifact_directory"])
        stdout, stderr = "", ""
        if runtime is not None:
            stdout, stderr = runtime["stdout"], runtime["stderr"]
            record.update(run_exit=runtime["exit"], stdout_json=json.dumps(stdout), stderr_json=json.dumps(stderr),
                          run_seconds=runtime["elapsed_seconds"], run_command_json=json.dumps(runtime["command"]))
            status, reason = runtime_verdict(runtime, json.loads(record["expected_stdout_json"]))
            record.update(status=status, reason=reason)
        write_text(directory / "run.stdout.txt", stdout)
        write_text(directory / "run.stderr.txt", stderr)
        record["failed_cases_json"] = json.dumps(re.findall(r"^FAIL (.+)$", stdout, re.MULTILINE))
        record["artifacts"] = {str(p): sha(p) for p in sorted((directory / "artifacts").glob("*")) if p.is_file()}
        program = directory / "artifacts" / ("program" + self.artifact_extension)
        record["artifact_sha256"] = sha(program) if program.is_file() else None
        record["evidence_sha256"] = {p.relative_to(directory).as_posix(): sha(p) for p in sorted(directory.rglob("*")) if p.is_file()}
        self.mark_departure(record)
        record["completed_utc"] = utc()
        write_json(directory / "result.json", record)
        write_json(record["result_path"], record)
        return record

    def run_batch(self, prepared, jobs=1):
        if self.evidence_only:
            raise ValueError("Evidence contexts cannot run or replace observations")
        requests = [p["request"] for p in prepared if p["request"] is not None]
        runtime = {r["id"]: r for r in self.target.run_batch(requests, jobs)}
        return [self.finish(p, runtime.get(p["request"]["id"]) if p["request"] is not None else None) for p in prepared]

    def run(self, test, level=None, mode="test", executed_bytes=None):
        return self.run_batch([self.compile(test, level, mode, executed_bytes)])[0]

    def saved(self, test, level=None, mode="test", completed=False, executed_bytes=None):
        path = self.case_directory(test, level, mode) / "result.json"
        if not path.is_file():
            return None
        try:
            if sha(self.source_path(test)) != test["source_sha256"]:
                return None
            if test["suite_id"] != "controls" and fixture_info(json.loads(test["fixture_json"]), test["suite_id"], test["path"].split("/")[1],
                    test["path"] in raw_sources(test["suite_id"]), json.loads(test["source_diagnostic_json"])) != test["fixture_sha256"]:
                return None
            record = json.loads(path.read_text(encoding="utf-8"))
            if record["fingerprint"] != self.fingerprint(test, level, mode, executed_bytes) or (not completed and record["status"] != "pass"):
                return None
            if record["compile_exit"] in {"timeout", "launch-error"} or record["run_exit"] in {"timeout", "launch-error"}:
                return None
            directory = canonical(record["artifact_directory"])
            if not directory.is_relative_to(self.output) or Path(record["result_path"]).resolve() != path.resolve():
                return None
            if not record["evidence_sha256"] or any(sha(inside(directory, name)) != expected for name, expected in record["evidence_sha256"].items()):
                return None
            if any(sha(path) != expected for path, expected in record["artifacts"].items()):
                return None
            if json.loads(record["stdout_json"]) != (directory / "run.stdout.txt").read_text(encoding="utf-8"):
                return None
            # The copy inside the attempt hashes the complete derived verdict, including stages and checks.
            if json.loads((directory / "result.json").read_text(encoding="utf-8")) != record:
                return None
            from suite_evidence import verify_record
            verify_record(self, test, record, level or resolve_level(self.config, test["version"]), mode, executed_bytes,
                          "not-applicable" if mode == "not-applicable" else None)
            record["departure"], record["departure_kind"] = False, ""
            self.mark_departure(record)
            return record
        except (OSError, ValueError, KeyError, TypeError):
            return None


def run_controls(context, jobs):
    from concurrent.futures import ThreadPoolExecutor
    with ThreadPoolExecutor(max_workers=jobs) as pool:
        prepared = list(pool.map(lambda test: context.compile(test, control_level(context.config, test)), load_controls()))
    results = context.run_batch(prepared, jobs)
    rows = []
    for result in results:
        status, compiler_exit, runtime_exit = CONTROL_OUTCOMES[result["test_id"].removeprefix("control--")]
        compile_good = result["compile_exit"] in context.config["rejection_exit_codes"] if compiler_exit == "rejection" else result["compile_exit"] == compiler_exit
        run_good = type(result["run_exit"]) is int and result["run_exit"] != 0 if runtime_exit == "nonzero" else result["run_exit"] == runtime_exit
        rows.append({"test_id": result["test_id"], "valid": result["status"] == status and compile_good and run_good,
                     "status": result["status"], "compile_exit": result["compile_exit"], "run_exit": result["run_exit"],
                     "source_sha256": result["source_sha256"], "result": result["result_path"]})
    summary = {"provenance": context.provenance(), "controls": len(rows), "valid": all(r["valid"] for r in rows),
               "rows": rows, "errors": [r["test_id"] for r in rows if not r["valid"]]}
    write_json(context.output / "controls.json", summary)
    return summary
