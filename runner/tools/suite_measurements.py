"""Applicability observations and strict replay of their registered execution contexts."""
from __future__ import annotations

import hashlib
import json
from pathlib import Path

from suite_common import digest, inside, mutated_source, sha, standard_root, write_json
from suite_config import resolve_level
from suite_engine import CONTROL_OUTCOMES, Context, control_level, departure_rows, load_controls
from suite_evidence import CONTRACT_EXCLUSIONS, verify_record


def witness_for(test, context, departures):
    raw = context.source_path(test).read_bytes()
    declared = test["version_witness"]
    witness = inside(standard_root(test["suite_id"]) / "clauses" / test["path"].split("/")[1], declared) if declared else None
    declared_hash = sha(witness) if witness else ""
    if test["test_id"] in departures:
        if witness is None:
            raise ValueError("A departure needs a declared positive construct witness: " + test["test_id"])
        return "departure-witness", witness.read_bytes(), declared_hash
    if test["expected"] == "run":
        return "original", raw, declared_hash
    if test["origin"] == "generated":
        return "feature-free-rejection", raw, declared_hash
    return "repair", witness.read_bytes() if witness else mutated_source(test, raw), declared_hash


def interval(observations, levels, header):
    center = levels.index(header)
    if not observations[header]["applicable"]:
        raise ValueError("The header Version has no applicable positive witness")
    lower = upper = center
    while lower and observations[levels[lower - 1]]["applicable"]:
        lower -= 1
    while upper + 1 < len(levels) and observations[levels[upper + 1]]["applicable"]:
        upper += 1
    other = [v for index, v in enumerate(levels) if not lower <= index <= upper and observations[v]["applicable"]]
    return lower, upper, other


def predecessor(observation, level, basis):
    if observation is None:
        return {"level": "", "behavior": "none", "diagnostic_codes": []}
    positive = basis in {"repair", "departure-witness"}
    status = observation["witness_status"] if positive else observation["original_status"]
    refuses = status in {"unexpected-reject", "compiler-error", "infrastructure", "unsupported"}
    if basis == "feature-free-rejection":
        refuses = status == "pass"
    return {"level": level, "behavior": "refuses" if refuses else "meaning-change",
            "diagnostic_codes": observation["witness_diagnostic_codes"] if positive else observation["diagnostic_codes"]}


class ObservationRegistry:
    """Only explicitly bound metadata may supply a historical observation context."""

    def __init__(self, compiler, target_paths):
        self.compiler, self.target_paths = compiler, target_paths
        self.bindings, self.contexts = {}, {}

    def add(self, output, metadata_path, kind, expected=None):
        output, metadata_path = Path(output).resolve(), Path(metadata_path).resolve()
        data = json.loads(metadata_path.read_text())
        binding = {"output": str(output), "metadata_path": str(metadata_path), "metadata_sha256": sha(metadata_path),
                   "kind": kind, "provenance": data["provenance"]}
        if expected is not None and binding != expected:
            raise ValueError("A registered execution metadata binding changed")
        target_id = binding["provenance"]["execution_target"]
        if target_id not in self.target_paths:
            raise ValueError("An observation uses an unconfigured measurement target")
        context = Context.from_evidence(self.compiler, self.target_paths[target_id], output, binding["provenance"])
        existing = self.bindings.get(str(output))
        if existing is not None and existing != binding:
            raise ValueError("An observation directory has conflicting provenance")
        self.bindings[str(output)], self.contexts[str(output)] = binding, context
        return context, data

    def live(self, context, kind):
        path = context.output / "observation-context.json"
        if path.exists():
            saved = json.loads(path.read_text())
            if saved["provenance"]["identity_sha256"] != context.identity_sha256 or saved["kind"] != kind:
                raise ValueError("The execution directory belongs to another identity or purpose")
        else:
            write_json(path, {"kind": kind, "provenance": context.provenance()})
        self.add(context.output, path, kind)

    def restore(self, bindings):
        for binding in bindings:
            self.add(binding["output"], binding["metadata_path"], binding["kind"], binding)

    def get(self, output):
        try:
            return self.contexts[str(Path(output).resolve())]
        except KeyError as error:
            raise ValueError("An evidence link has no registered execution context") from error

    def exported(self):
        return [self.bindings[key] for key in sorted(self.bindings)]

    def header(self, context, data):
        """Resolve a header inventory to explicitly registered leaf observations."""
        if (not data["complete"] or data.get("void", False) or data.get("errors", [])
                or data["version_mode"] != "header-Version"):
            raise ValueError("Header observations must be complete, nonvoid and use each header Version")
        self.controls(context, data["controls"])
        if "observation_contexts" not in data:
            if "record_origins" in data:
                raise ValueError("Header origins have no registered execution contexts")
            return context
        leaves = {}
        for binding in data["observation_contexts"]:
            if binding["kind"] != "header" or binding["output"] == str(context.output) or binding["output"] in leaves:
                raise ValueError("Header leaf contexts must be distinct, explicit and nonrecursive")
            leaf, metadata = self.add(binding["output"], binding["metadata_path"], "header", binding)
            if ("observation_contexts" in metadata or not metadata["complete"] or metadata.get("void", False)
                    or metadata.get("errors", []) or metadata["version_mode"] != "header-Version"
                    or leaf.target_config["id"] != context.target_config["id"]):
                raise ValueError("A header leaf is not a complete matching-target execution")
            self.controls(leaf, metadata["controls"])
            leaves[str(leaf.output)] = (leaf, {"|".join(pair) for pair in metadata["selected_test_ids"]})
        selected = {"|".join(pair) for pair in data["selected_test_ids"]}
        if len(selected) != data["tests"] or set(data["record_origins"]) != selected:
            raise ValueError("Header origins must cover the complete selected inventory exactly once")
        result = {}
        for key, output in data["record_origins"].items():
            if output not in leaves or key not in leaves[output][1]:
                raise ValueError("A header observation has no selected registered origin")
            result[key] = leaves[output][0]
        return result

    def controls(self, context, summary):
        rows = {r["test_id"]: r for r in summary["rows"]}
        tests = load_controls()
        if (not summary["valid"] or len(rows) != len(summary["rows"])
                or set(rows) != {t["test_id"] for t in tests}):
            raise ValueError("Control inventory or validity differs")
        for test in tests:
            row = rows[test["test_id"]]
            record = json.loads(Path(row["result"]).read_text())
            verify_record(context, test, record, control_level(context.config, test))
            wanted, compile_exit, run_exit = CONTROL_OUTCOMES[test["test_id"].removeprefix("control--")]
            compile_ok = record["compile_exit"] in context.config["rejection_exit_codes"] if compile_exit == "rejection" else record["compile_exit"] == compile_exit
            run_ok = type(record["run_exit"]) is int and record["run_exit"] != 0 if run_exit == "nonzero" else record["run_exit"] == run_exit
            if not row["valid"] or record["status"] != wanted or not compile_ok or not run_ok:
                raise ValueError("A control cannot establish the recorded deliberately broken outcome")


class Measurement:
    def __init__(self, context, tests, levels, identity, header_context=None, fresh=False, *, registry=None, reuse_contexts=()):
        self.context, self.tests, self.levels, self.identity = context, tests, levels, identity
        self.header_context, self.fresh, self.registry = header_context, fresh, registry
        self.reuse_contexts = tuple(reuse_contexts)
        self.departures = departure_rows(tests[0]["suite_id"])
        self.feature_codes = set(context.config["diagnostics"]["version_feature_codes"]) | {"CS8652"}
        self.resolutions = {v: resolve_level(context.config, "preview" if v.endswith("-preview") else v) for v in levels}

    def saved_row_path(self, test):
        return self.context.output / "measurements" / digest([test["suite_id"], test["test_id"]]) / "row.json"

    @staticmethod
    def checked(record):
        if record["status"] in {"compiler-error", "infrastructure", "unsupported"} or record["run_exit"] in {"timeout", "launch-error"}:
            raise ValueError("Measurement cannot establish a source verdict: " + record["status"] + ":" + record["reason"])
        return record

    def contract(self, test):
        return digest({k: v for k, v in test.items() if k not in CONTRACT_EXCLUSIONS})

    def observation(self, basis, original, positive):
        codes = sorted(filter(None, original["error_diagnostic_codes"].split(";")))
        witness_codes = sorted(filter(None, positive["error_diagnostic_codes"].split(";")))
        applicable = positive["status"] == "pass"
        if basis == "repair":
            applicable = applicable and original["status"] == "pass"
        elif basis == "feature-free-rejection":
            applicable = applicable and original["status"] == "pass" and not self.feature_codes.intersection(codes)
        return {"applicable": applicable, "witness_status": positive["status"], "original_status": original["status"],
                "diagnostic_codes": codes, "witness_diagnostic_codes": witness_codes,
                "witness_evidence_sha256": sha(positive["result_path"]), "original_evidence_sha256": sha(original["result_path"])}

    def link(self, record, context, mode):
        return {"result": record["result_path"], "output": str(context.output), "mode": mode,
                "identity_sha256": context.identity_sha256}

    def build(self, test, basis, witness, declared, method, observations, evidence):
        header = resolve_level(self.context.config, test["version"])["level"]
        if method == "exhaustive":
            if set(observations) != set(self.levels):
                raise ValueError("Exhaustive bounds omit a language level")
            lower, upper, other = interval(observations, self.levels, header)
        elif method == "monotonic-search":
            # Reconstruct the exact search and require every requested observation.
            def passing(index):
                try:
                    return observations[self.levels[index]]["applicable"]
                except KeyError as error:
                    raise ValueError("Searched bounds omit a required observation") from error
            center = self.levels.index(header)
            if not passing(center):
                raise ValueError("The header Version has no applicable positive witness")
            low, high = -1, center
            while high - low > 1:
                middle = (low + high) // 2
                if passing(middle):
                    high = middle
                else:
                    low = middle
            lower, upper, other = high, len(self.levels) - 1, []
            if not passing(upper):
                low, high = center, upper
                while high - low > 1:
                    middle = (low + high) // 2
                    if passing(middle):
                        low = middle
                    else:
                        high = middle
                upper = low
            if lower and passing(lower - 1):
                raise ValueError("A searched predecessor still passes")
        else:
            raise ValueError("Unknown bounds method")
        row = {"since": self.levels[lower], "fixture_sha256": test["fixture_sha256"], "declared_witness_sha256": declared,
               "witness_sha256": hashlib.sha256(witness).hexdigest(), "basis": basis, "method": method,
               "measurement_target": self.context.target_config["id"],
               "below_since": predecessor(observations.get(self.levels[lower - 1]) if lower else None,
                                           self.levels[lower - 1] if lower else "", basis),
               "other_passing_levels": other, "observations": observations, "evidence_sha256": digest(evidence)}
        if upper + 1 < len(self.levels):
            row["until"] = self.levels[upper]
        return {"test_id": test["test_id"], "source_sha256": test["source_sha256"], "identity": self.identity,
                "contract": self.contract(test), "row": row, "evidence": evidence}

    def replay(self, test, stored, *, historical=False, independent=False):
        """Reconstruct a row without executing, replacing records, or trusting its booleans."""
        basis, witness, declared = witness_for(test, self.context, self.departures)
        row = stored["row"]
        if (stored["test_id"] != test["test_id"] or stored["source_sha256"] != test["source_sha256"]
                or stored["contract"] != self.contract(test) or (not historical and stored["identity"] != self.identity)
                or row["witness_sha256"] != hashlib.sha256(witness).hexdigest() or row["declared_witness_sha256"] != declared
                or row["basis"] != basis or row["measurement_target"] != self.context.target_config["id"]
                or row["evidence_sha256"] != digest(stored["evidence"])):
            raise ValueError("A stored measurement has changed source, witness or identity bindings")
        observations, evidence = {}, {}
        positive = {**test, "expected": "run"}
        header = resolve_level(self.context.config, test["version"])
        for label, pair in stored["evidence"].items():
            if label not in self.levels or pair["resolution"] not in (self.resolutions[label], header) or pair["resolution"]["level"] != label:
                raise ValueError("A measurement has an unresolved language level")
            records, links = {}, {}
            for kind in ["original", "witness"]:
                link = pair[kind]
                context = self.registry.get(link["output"]) if self.registry else self.context
                if context.target_config["id"] != self.context.target_config["id"]:
                    raise ValueError("A measurement link uses another target")
                if independent and (context.output != self.context.output or self.registry.bindings[str(context.output)]["kind"] != "sample"):
                    raise ValueError("The independent sample reused a bounds/header observation")
                is_positive = kind == "witness" and basis in {"repair", "departure-witness"}
                mode = "compile-only" if is_positive else "test"
                if link["mode"] != mode or link.get("identity_sha256", context.identity_sha256) != context.identity_sha256:
                    raise ValueError("A measurement link has another mode or execution identity")
                record = json.loads(Path(link["result"]).read_text())
                if Path(link["result"]).resolve() != context.case_directory(positive if is_positive else test, pair["resolution"], mode) / "result.json":
                    raise ValueError("A measurement links to another case")
                verify_record(context, positive if is_positive else test, record, pair["resolution"], mode, witness if is_positive else None)
                records[kind] = self.checked(record)
                links[kind] = self.link(record, context, mode)
            if basis not in {"repair", "departure-witness"} and pair["original"] != pair["witness"]:
                raise ValueError("An original measurement has an alternate positive witness")
            observations[label] = self.observation(basis, records["original"], records["witness"])
            evidence[label] = {"resolution": pair["resolution"], **links}
        if observations != row["observations"]:
            raise ValueError("Stored applicability differs from independently replayed observations")
        reconstructed = self.build(test, basis, witness, declared, row["method"], observations, evidence)
        expected = dict(row, evidence_sha256=reconstructed["row"]["evidence_sha256"])
        if reconstructed["row"] != expected:
            raise ValueError("Stored bounds differ from independently reconstructed observations")
        return reconstructed

    def measure(self, test, method, resume=False):
        path = self.saved_row_path(test)
        if resume and path.is_file():
            result = self.replay(test, json.loads(path.read_text()))
            if result["row"]["method"] != method:
                raise ValueError("A resumed row has another measurement method")
            return result
        basis, witness, declared = witness_for(test, self.context, self.departures)
        positive_test = {**test, "expected": "run"}
        header = resolve_level(self.context.config, test["version"])
        observations, evidence = {}, {}

        def get_record(current, resolution, mode, raw=None):
            if not self.fresh:
                contexts = [self.context]
                if self.header_context is not None and resolution["level"] == header["level"] and mode == "test":
                    header_context = (self.header_context.get(test["suite_id"] + "|" + test["test_id"])
                                      if isinstance(self.header_context, dict) else self.header_context)
                    if header_context is not None:
                        contexts.append(header_context)
                if resolution["level"] == header["level"] and mode == "compile-only":
                    contexts.extend(self.reuse_contexts)
                for context in contexts:
                    record = context.saved(current, resolution, mode, completed=True, executed_bytes=raw)
                    if record is not None:
                        return self.checked(record), context
            return self.checked(self.context.run(current, resolution, mode, raw)), self.context

        def observe(index):
            label = self.levels[index]
            if label not in observations:
                resolution = header if label == header["level"] else self.resolutions[label]
                original, original_context = get_record(test, resolution, "test")
                if basis in {"repair", "departure-witness"}:
                    positive, positive_context = get_record(positive_test, resolution, "compile-only", witness)
                    positive_mode = "compile-only"
                else:
                    positive, positive_context, positive_mode = original, original_context, "test"
                observations[label] = self.observation(basis, original, positive)
                evidence[label] = {"resolution": resolution, "original": self.link(original, original_context, "test"),
                                   "witness": self.link(positive, positive_context, positive_mode)}
            return observations[label]["applicable"]

        center = self.levels.index(header["level"])
        if not observe(center):
            write_json(path.with_name("error.json"), {"test_id": test["test_id"], "observations": observations, "evidence": evidence})
            raise ValueError("The header Version has no applicable positive witness: " + test["test_id"])
        if method == "exhaustive":
            for index in range(len(self.levels)):
                observe(index)
        elif method == "monotonic-search":
            low, high = -1, center
            while high - low > 1:
                middle = (low + high) // 2
                if observe(middle):
                    high = middle
                else:
                    low = middle
            lower = high
            upper = len(self.levels) - 1
            if not observe(upper):
                low, high = center, upper
                while high - low > 1:
                    middle = (low + high) // 2
                    if observe(middle):
                        low = middle
                    else:
                        high = middle
                upper = low
            if lower:
                observe(lower - 1)
        result = self.build(test, basis, witness, declared, method, observations, evidence)
        write_json(path, result)
        return result
