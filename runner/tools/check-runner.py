"""Check language selection and exhaustive measurement without executing a compiler."""
import argparse
import copy
import importlib.util
import io
import json
import re
from pathlib import Path
import subprocess
import sys
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from suite_common import ROOT, emit_audit, sha, write_json
from suite_config import asset_entries, host_rid, read_config, resolve_level, select_levels, validate_compiler
import suite_editions
from suite_editions import edition_definition, edition_inventory, registered_editions, validate_conflicts, version_inventory
from suite_engine import Context, load_controls
from suite_evidence import verify_record
from suite_measurements import Measurement
from suite_version_schedule import mismatches
from suite_versions import measurement_identity, validate_metadata


def load_runner():
    spec = importlib.util.spec_from_file_location("runner_check_subject", ROOT / "runner/run-suite.py")
    runner = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(runner)
    return runner


class RunnerChecks(unittest.TestCase):
    config = json.loads((ROOT / "configs/compilers/csc.json").read_bytes())

    def labels(self, selectors, config=None):
        return [row["level"] for row in select_levels(config or self.config, selectors)[1]]

    def test_lists_aliases_and_repeated_flags(self):
        self.assertEqual(self.labels(["ISO-1,2", "7.0,latest,2"]), ["1", "2", "7", "15"])

    def test_inclusive_ranges(self):
        self.assertEqual(self.labels(["5..7.3"]), ["5", "6", "7", "7.1", "7.2", "7.3"])
        self.assertEqual(self.labels(["7.3..7.3"]), ["7.3"])
        self.assertEqual(self.labels(["latest..preview"]), ["15", "15-preview"])

    def test_range_follows_configuration_order(self):
        sparse = copy.deepcopy(self.config)
        sparse["language"]["explicit"] = {"7.3": "7.3", "5": "5", "7.1": "7.1"}
        self.assertEqual(self.labels(["7.3..7.1"], sparse), ["7.3", "5", "7.1"])

    def test_all_and_per_test_modes(self):
        self.assertEqual(self.labels(["ALL"]), [*self.config["language"]["explicit"], "15-preview"])
        for name in ["earliest-per-test", "declared-per-test"]:
            self.assertEqual(select_levels(self.config, [name]), (name, []))

    def test_platform_pins_are_complete_and_fail_closed(self):
        expected = {("win32", "AMD64"): "win-x64", ("linux", "x86_64"): "linux-x64",
                    ("darwin", "arm64"): "osx-arm64", ("linux", "aarch64"): "linux-arm64"}
        for (system, machine), rid in expected.items():
            with patch("suite_config.sys.platform", system), patch("suite_config.platform.machine", return_value=machine):
                self.assertEqual(host_rid(), rid)
                entries = asset_entries(self.config)
                self.assertEqual(entries["dotnet"]["path"], "dotnet.exe" if system == "win32" else "dotnet")
        with patch("suite_config.platform.machine", return_value="unknown"):
            with self.assertRaisesRegex(ValueError, "No pinned"):
                asset_entries(self.config)
        for path in ["configs/targets/net481.json", "configs/targets/dotnet.json"]:
            read_config(ROOT / path, "target", check_host=False)
        for name in ["csc-framework", "mcs"]:
            path = ROOT / ("configs/compilers/" + name + ".json")
            with patch("suite_config.sys.platform", "linux"):
                with self.assertRaisesRegex(ValueError, "does not support"):
                    read_config(path, "compiler")
        broken = copy.deepcopy(self.config)
        broken["files"]["csc"]["variants"].pop("linux-arm64")
        with self.assertRaisesRegex(ValueError, "same host RIDs"):
            validate_compiler(broken, check_host=False)
        broken = copy.deepcopy(self.config)
        broken["files"]["csc"]["variants"]["osx-arm64"]["sha256"] = "bad"
        with self.assertRaisesRegex(ValueError, "SHA-256"):
            validate_compiler(broken, check_host=False)

    def test_shared_identity_binds_every_platform_pin(self):
        def context(rid, config):
            return SimpleNamespace(config=config, target_path=ROOT / "configs/targets/dotnet.json", target_config={"id": "dotnet"},
                compile_timeout=60, run_timeout=20, identity={"suite_files": {},
                    "compiler_identity": {"rid": rid, "assets": {"local": rid}},
                    "target_identity": {"rid": rid, "assets": {"local": rid}}})
        windows = measurement_identity(context("win-x64", self.config), "ecma-334")
        for rid in ["linux-x64", "osx-arm64", "linux-arm64"]:
            self.assertEqual(windows, measurement_identity(context(rid, self.config), "ecma-334"))
        changed = copy.deepcopy(self.config)
        changed["files"]["csc"]["variants"]["linux-arm64"]["sha256"] = "0" * 64
        self.assertNotEqual(windows, measurement_identity(context("win-x64", changed), "ecma-334"))
        self.assertEqual(windows["targets"]["net481"]["platforms"], ["win32"])
        self.assertIn("runtime_requirement", windows["targets"]["net481"])

    def test_framework_row_keeps_actual_serviced_runtime(self):
        runtime = {"kind": "netframework", "architecture": "x64", "release": 533320, "version": "4.8.1",
                   "assets": {name: {"sha256": "1" * 64, "version": "4.8.1", "path": "local"}
                              for name in ["mscorlib.dll", "clr.dll", "clrjit.dll"]}}
        measurement = Measurement.__new__(Measurement)
        measurement.context = SimpleNamespace(config=self.config, target_config={"id": "net481"},
                                             identity={"target_identity": {"runtime": runtime}})
        measurement.levels, measurement.identity = ["1"], {}
        test = {"version": "1", "test_id": "framework", "source_sha256": "0" * 64, "fixture_sha256": "fixture"}
        observation = {"applicable": True, "original_status": "pass", "witness_status": "pass",
                       "diagnostic_codes": [], "witness_diagnostic_codes": [],
                       "witness_evidence_sha256": "2" * 64, "original_evidence_sha256": "2" * 64}
        result = measurement.build(test, "original", b"source", "", "exhaustive", {"1": observation}, {})
        row = result["row"]
        self.assertEqual(row["measurement_runtime"]["assets"]["clr.dll"], {"sha256": "1" * 64, "version": "4.8.1"})
        metadata = {"schema_version": 3, "identity": {"targets": {"net481": {}}}, "levels": ["1"],
                    "rows": {test["source_sha256"]: {test["test_id"]: row}}, "sample": {}, "provenance": {}}
        validate_metadata(metadata)
        row.pop("measurement_runtime")
        with self.assertRaises(ValueError):
            validate_metadata(metadata)

    def test_invalid_and_unsupported_selectors(self):
        for selectors in [[], [""], ["5,"], ["7.3..5"], ["5.."], ["1..2..3"],
                          ["all,5"], ["earliest-per-test,5"], ["declared-per-test", "all"], ["16"]]:
            with self.subTest(selectors=selectors), self.assertRaises(ValueError):
                select_levels(self.config, selectors)
        older = copy.deepcopy(self.config)
        older["language"]["explicit"].pop("5")
        with self.assertRaisesRegex(ValueError, "unsupported"):
            select_levels(older, ["5"])

    def test_missing_selection_does_no_work(self):
        output = self.scratch / "must-not-exist"
        result = subprocess.run([sys.executable, "-B", str(ROOT / "runner/run-suite.py"),
                                 "--compiler", str(self.scratch / "absent.json"), "--results", str(output)],
                                capture_output=True, text=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        for choice in ["START..END", "all", "earliest-per-test", "declared-per-test"]:
            self.assertIn(choice, result.stderr)
        self.assertFalse(output.exists())

    def test_retired_deadline_is_refused_before_work(self):
        output = self.scratch / "no-deadline-results"
        result = subprocess.run([sys.executable, "-B", str(ROOT / "runner/tools/compute-versions.py"),
                                 "--results", str(output), "--exhaustive-deadline", "2000-01-01T00:00:00Z"],
                                capture_output=True, text=True, timeout=30)
        self.assertEqual(result.returncode, 2)
        self.assertIn("unrecognized arguments", result.stderr)
        self.assertFalse(output.exists())

    def test_earliest_plans_use_current_bounds_once(self):
        spec = importlib.util.spec_from_file_location("runner_check_subject", ROOT / "runner/run-suite.py")
        runner = importlib.util.module_from_spec(spec)
        spec.loader.exec_module(runner)
        tests = [{"test_id": "one", "version": "7.3"}, {"test_id": "two", "version": "15"}]
        with patch.object(runner, "version_row", side_effect=[({"since": "2"}, "current"),
                                                             ({"since": "15-preview"}, "current")]):
            plans = runner.language_plans(tests, self.config, "earliest-per-test", [])
        self.assertEqual([(test["test_id"], level["level"], mode) for test, level, mode in plans],
                         [("one", "2", "test"), ("two", "15-preview", "test")])
        with patch.object(runner, "version_row", return_value=({"since": "2"}, "stale")):
            with self.assertRaisesRegex(ValueError, "Current bounds"):
                runner.language_plans(tests, self.config, "earliest-per-test", [])
        older = copy.deepcopy(self.config)
        older["language"]["explicit"].pop("2")
        with patch.object(runner, "version_row", return_value=({"since": "2"}, "current")):
            with self.assertRaisesRegex(ValueError, "unsupported"):
                runner.language_plans(tests, older, "earliest-per-test", [])

    def test_exhaustive_measurement_preserves_disconnected_levels(self):
        levels = ["1", "2", "3", "4", "5"]
        calls = []
        source = self.scratch / "source.cs"
        source.write_bytes(b"class Program {}\n")
        test = {"test_id": "check", "suite_id": "checks", "version": "3", "expected": "run",
                "version_witness": "", "fixture_sha256": "fixture", "source_sha256": sha(source)}
        def run(current, resolution, mode, raw):
            label = resolution["level"]
            calls.append(label)
            path = self.scratch / (label + ".json")
            record = {"status": "pass" if label in {"1", "3", "4"} else "unexpected-reject",
                      "reason": "", "run_exit": 0, "error_diagnostic_codes": "", "result_path": str(path)}
            write_json(path, record)
            return record
        context = SimpleNamespace(config=self.config, output=self.scratch / "measurements", identity_sha256="identity",
                                  target_config={"id": "dotnet"}, source_path=lambda test: source, run=run)
        measurement = Measurement.__new__(Measurement)
        measurement.context, measurement.levels = context, levels
        measurement.identity, measurement.departures, measurement.fresh = {}, {}, True
        measurement.resolutions = {level: resolve_level(self.config, level) for level in levels}
        result = measurement.measure(test, "exhaustive")
        row = result["row"]
        self.assertEqual(sorted(calls), levels)
        self.assertEqual((row["since"], row["until"], row["other_passing_levels"]), ("3", "4", ["1"]))
        self.assertEqual(set(row["observations"]), set(levels))
        metadata = {"schema_version": 3, "identity": {"targets": {"dotnet": {}}}, "levels": levels,
                    "rows": {sha(source): {"check": copy.deepcopy(row)}}, "sample": {}, "provenance": {}}
        validate_metadata(metadata)
        metadata["rows"][sha(source)]["check"]["method"] = "monotonic-search"
        with self.assertRaisesRegex(ValueError, "method"):
            validate_metadata(metadata)
        with self.assertRaises(ValueError):
            measurement.measure(test, "retired-search")
        incomplete = dict(row["observations"])
        incomplete.pop("5")
        with self.assertRaisesRegex(ValueError, "omit"):
            measurement.build(test, "original", b"source", "", "exhaustive", incomplete, {})
        independent = copy.deepcopy(result)
        self.assertEqual(mismatches({"check": result}, [test], [independent]), [])
        independent["row"]["observations"]["1"]["diagnostic_codes"] = ["different"]
        self.assertEqual(mismatches({"check": result}, [test], [independent])[0]["field"], "observations")


    def test_library_refusal_gating_and_ordinary_evidence(self):
        source = self.scratch / "library-refusal.cs"
        source.write_bytes(b"class Input {}\n")
        test = dict(next(row for row in load_controls() if row["test_id"] == "control--positive"))
        test.update(test_id="control--library-refusal", expected="reject", stdout_json='""',
                    source_sha256=sha(source), diagnostic="", fixture_json=json.dumps({
                        "libraries": [{"name": "Later", "units": [{"source": "self"}]}], "program": {}}))
        level = resolve_level(self.config, "7.3")
        for mode, library_rejected, expected in [
                ("version-gating", True, "not-applicable"), ("test", True, "unexpected-reject"),
                ("compile-only", True, "unexpected-reject"), ("version-gating", False, "pass"),
                ("test", False, "pass"), ("compile-only", False, "unexpected-reject")]:
            with self.subTest(mode=mode, library_rejected=library_rejected):
                context = Context.__new__(Context)
                context.evidence_only, context.config = False, self.config
                context.output = self.scratch / ("library-refusal-" + mode)
                context.target_config = {"id": "dotnet", "description": "synthetic target", "references": {}}
                context.target_assets, context._departures = {}, {}
                context.artifact_extension, context.identity_sha256 = ".dll", "f" * 64
                context.compile_timeout = 60
                context.source_path = lambda test: source
                context.preflight = lambda *args: ("", "", [])
                context.command = lambda units, output, *args: ["compiler", str(output), *map(str, units)]
                def execute(command, *args):
                    if not library_rejected and Path(command[1]).stem == "Later":
                        Path(command[1]).write_bytes(b"synthetic library")
                        return 0, "", "", 0.0
                    return 1, "input.cs(1,1): error CS8370: Feature unavailable.\n", "", 0.0
                context.execute = execute
                pending = context.compile(test, level, mode)
                self.assertIsNone(pending["request"])
                record = context.finish(pending)
                self.assertEqual((record["schema_version"], record["status"], record["reason"]),
                                 (2, expected, "fixture-prerequisite:Later" if library_rejected else
                                  "compile-only" if mode == "compile-only" else ""))
                self.assertEqual([stage["name"] for stage in record["stages"]],
                                 ["Later"] if library_rejected else ["Later", "program"])
                verify_record(context, test, record, level, mode)
                forged = dict(record, status="unexpected-reject" if expected == "pass" else "pass")
                write_json(Path(record["artifact_directory"]) / "result.json", forged)
                with self.assertRaisesRegex(ValueError, "Saved classification differs"):
                    verify_record(context, test, forged, level, mode)


class EditionChecks(unittest.TestCase):
    config = RunnerChecks.config

    def setUp(self):
        self.tests = [{"suite_id": "ecma-334", "test_id": name, "authority": authority,
                       "version_status": "current", "version": "1", "origin": "handwritten"}
                      for name, authority in [("own", "ECMA-334 1st ed 10.1"), ("own-2", "ECMA-334 1st ed 10.1"),
                          *[(name, "ECMA-334 7th ed 7.3") for name in
                            ["replaced", "left-out", "continuity", "late", "disconnected"]],
                          ("feature", "csc pinned (C# 8)")]]
        self.table = {"schema_version": 1, "edition": 1, "base_edition": 7,
                      "conflicts": [{"action": "replace", "test_id": "replaced", "replacement_test_id": "own",
                                     "authority": "ECMA-334 1st ed 10.1, p. 69 (PDF p. 83), lines 24-25"},
                                    {"action": "leave-out", "test_id": "left-out",
                                     "authority": "ECMA-334 1st ed 14.4.1, p. 133 (PDF p. 147), line 4"}]}
        self.definition = {"edition": 1, "source_id": "ecma-334-ed1", "language_version": "ISO-1",
                           "level": resolve_level(self.config, "ISO-1"), "table": self.table,
                           "conflict_table": {"path": "ecma-334/edition-conflicts/1.json", "sha256": "3" * 64}}
        self.rows = {test["test_id"]: {"since": "1", "until": "7.3"} for test in self.tests}
        for name in ["own", "own-2", "late", "feature", "disconnected"]:
            self.rows[name] = {"since": "2", "until": "7.3", "below_since": {"behavior": "refuses"}}
        self.rows["disconnected"]["other_passing_levels"] = ["1"]
        self.runner = load_runner()

    def args(self, **changes):
        values = dict(edition=1, langversion=None, select=".*", origin=None, pilot_versions=None)
        return SimpleNamespace(**(values | changes))

    def bounds(self, test):
        return self.rows[test["test_id"]], "current"

    def test_conflict_schema_ids_roles_and_duplicate_actions(self):
        validate_conflicts(self.table, "ecma-334", self.tests)
        multiple = copy.deepcopy(self.table)
        multiple["conflicts"].append({**multiple["conflicts"][0], "replacement_test_id": "own-2"})
        validate_conflicts(multiple, "ecma-334", self.tests)
        mutations = [lambda table: table.update(schema_version=True),
                     lambda table: table.update(edition=7), lambda table: table.update(edition=2),
                     lambda table: table.update(base_edition=1), lambda table: table.update(extra="unknown"),
                     lambda table: table["conflicts"][0].update(test_id="missing"),
                     lambda table: table["conflicts"][0].update(replacement_test_id="missing"),
                     lambda table: table["conflicts"][0].update(test_id="own-2"),
                     lambda table: table["conflicts"][0].update(replacement_test_id="continuity"),
                     lambda table: table["conflicts"][0].update(authority="ECMA-334 1st ed 10.1"),
                     lambda table: table["conflicts"][0].update(authority="ECMA-334 1st ed 10.2, p. 69 (PDF p. 83)"),
                     lambda table: table["conflicts"][0].pop("replacement_test_id"),
                     lambda table: table["conflicts"][1].update(replacement_test_id="own"),
                     lambda table: table["conflicts"].append(copy.deepcopy(table["conflicts"][0])),
                     lambda table: table["conflicts"].append({**table["conflicts"][1], "test_id": "replaced"}),
                     lambda table: table["conflicts"][0].update(action="unknown")]
        for index, change in enumerate(mutations):
            table = copy.deepcopy(self.table)
            change(table)
            with self.subTest(mutation=index), self.assertRaises(ValueError):
                validate_conflicts(table, "ecma-334", self.tests)

    def test_edition_selection_own_continuity_conflicts_and_no_gating(self):
        with patch("suite_versions.version_row", side_effect=self.bounds):
            tests, plans, selection, levels, details = self.prepare_edition()
        self.assertEqual([test["test_id"] for test in tests], ["own", "own-2", "continuity"])
        self.assertEqual([(level["level"], mode) for _, level, mode in plans], [("1", "test")] * 3)
        self.assertEqual((selection, [level["level"] for level in levels]), ("edition", ["1"]))
        reasons = details["edition_selection"]["ecma-334"]
        self.assertEqual(reasons["own_test_ids"], ["own", "own-2"])
        self.assertEqual(reasons["continuity_test_ids"], ["continuity"])
        self.assertEqual(reasons["replaced_test_ids"], ["replaced"])
        self.assertEqual(reasons["left_out_test_ids"], ["left-out"])
        self.assertEqual(reasons["outside_interval_test_ids"], ["late", "disconnected", "feature"])
        self.assertEqual(len(details["candidate_test_ids"]), len(self.tests))

    def prepare_edition(self, tests=None, args=None):
        with patch.object(self.runner, "edition_definition", return_value=self.definition):
            return self.runner.prepare_run(tests or self.tests, ["ecma-334"], self.config, args or self.args())

    def test_continuity_obeys_upper_interval_edge_and_other_editions(self):
        self.definition["level"] = resolve_level(self.config, "2")
        self.rows["continuity"]["until"] = "1"
        other = {**self.tests[0], "test_id": "other-edition", "authority": "ECMA-334 2nd ed 10.1"}
        self.rows["other-edition"] = {"since": "1", "until": "2"}
        editions = registered_editions("ecma-334")
        editions[2] = {**editions[1], "authority_prefix": "ECMA-334 2nd ed"}
        with patch("suite_editions.registered_editions", return_value=editions), \
                patch("suite_versions.version_row", side_effect=self.bounds):
            tests = self.prepare_edition([*self.tests, other])[0]
            self.assertIn("other-edition", [test["test_id"] for test in tests])
            self.assertNotIn("continuity", [test["test_id"] for test in tests])
            self.assertNotIn("other-edition", [test["test_id"] for test in version_inventory([other, *self.tests])])

    def test_version_modes_exclude_older_authorities_and_declared_keeps_all(self):
        self.tests[0]["version_status"] = "stale"
        self.tests[1]["version_status"] = "missing"
        for selectors in [["1"], ["1..2"], ["all"], ["earliest-per-test"], ["declared-per-test"]]:
            with self.subTest(selectors=selectors), patch("suite_versions.version_row", side_effect=self.bounds), \
                    patch.object(self.runner, "version_row", side_effect=self.bounds):
                tests = self.runner.prepare_run(self.tests, ["ecma-334"], self.config,
                                                self.args(edition=None, langversion=selectors))[0]
            expected = self.tests if selectors == ["declared-per-test"] else self.tests[2:]
            self.assertEqual([test["test_id"] for test in tests], [test["test_id"] for test in expected])

    def test_edition_and_version_stale_candidates_fail_closed(self):
        for name in ["own", "replaced", "left-out", "continuity", "late"]:
            for status in ["stale", "missing"]:
                tests = copy.deepcopy(self.tests)
                next(test for test in tests if test["test_id"] == name)["version_status"] = status
                with self.subTest(name=name, status=status), self.assertRaisesRegex(ValueError, "current version metadata"):
                    self.prepare_edition(tests)
        self.tests[2]["version_status"] = "stale"
        with self.assertRaisesRegex(ValueError, "current version metadata"):
            self.runner.prepare_run(self.tests, ["ecma-334"], self.config, self.args(edition=None, langversion=["1"]))

    def test_pilot_binds_candidates_before_either_mode_filters(self):
        stale = [{**test, "version_status": "stale"} for test in self.tests]
        for args in [self.args(pilot_versions=Path("pilot.json")),
                     self.args(edition=None, langversion=["1"], pilot_versions=Path("pilot.json"))]:
            with self.subTest(edition=args.edition), patch.object(self.runner, "edition_definition", return_value=self.definition), \
                    patch.object(self.runner, "use_pilot_versions", return_value=self.tests) as pilot, \
                    patch("suite_versions.version_row", side_effect=self.bounds):
                result = self.runner.prepare_run(stale, ["ecma-334"], self.config, args)
                pilot.assert_called_once_with(args.pilot_versions, stale)
                self.assertLess(len(result[0]), len(stale))
        for args in [self.args(select=None, pilot_versions=Path("pilot.json")),
                     self.args(edition=None, langversion=["declared-per-test"], pilot_versions=Path("pilot.json"))]:
            with patch.object(self.runner, "use_pilot_versions") as pilot, \
                    patch.object(self.runner, "edition_definition", return_value=self.definition), \
                    self.assertRaisesRegex(ValueError, "requires --select"):
                self.runner.prepare_run(self.tests, ["ecma-334"], self.config, args)
            pilot.assert_not_called()

    def test_unregistered_latest_and_unsupported_editions(self):
        for number in [0, 2, 7, 99]:
            with self.subTest(edition=number), self.assertRaisesRegex(ValueError, "registered non-latest"):
                edition_definition("ecma-334", number, self.config, self.tests)
        older = copy.deepcopy(self.config)
        older["language"]["explicit"].pop("1")
        with self.assertRaisesRegex(ValueError, "does not support edition"):
            edition_definition("ecma-334", 1, older, self.tests)

    def test_conflict_file_inventory_and_duplicate_json_keys(self):
        directory = self.scratch / "edition-files"
        tables = directory / "edition-conflicts"
        tables.mkdir(parents=True)
        path = tables / "1.json"
        with patch.object(suite_editions, "standard_root", return_value=directory):
            write_json(path, self.table)
            self.assertEqual(suite_editions.edition_audit("ecma-334", self.tests)["errors"], [])
            path.write_text('{"schema_version": 1, "schema_version": 1}\n', encoding="ascii")
            with self.assertRaisesRegex(ValueError, "Duplicate JSON key"):
                suite_editions.load_conflicts("ecma-334", 1, self.tests)
            write_json(path, self.table)
            write_json(tables / "2.json", self.table)
            with self.assertRaisesRegex(ValueError, "file name disagrees"):
                suite_editions.load_conflicts("ecma-334", 2, self.tests)
            path.unlink()
            audit = suite_editions.edition_audit("ecma-334", self.tests)
            self.assertTrue(audit["errors"])
            self.assertIn("missing=['1.json']; extra=['2.json']", audit["errors"][0])

    def test_cli_refuses_mixed_or_malformed_selectors_before_work(self):
        output = self.scratch / "invalid-edition-output"
        for flags in [["--edition", "1", "--langversion", "1"],
                      ["--langversion", "all", "--edition", "1"], ["--edition", "zero"],
                      ["--edition", "0"], ["--edition", "-1"]]:
            result = subprocess.run([sys.executable, "-B", str(ROOT / "runner/run-suite.py"),
                                     "--compiler", str(self.scratch / "absent.json"), "--results", str(output), *flags],
                                    capture_output=True, text=True, timeout=30)
            with self.subTest(flags=flags):
                self.assertEqual(result.returncode, 2)
                self.assertIn("error:", result.stderr)
                self.assertFalse(output.exists())

    def test_cli_preserves_usage_exit_for_empty_selection_and_invalid_pilot(self):
        output = self.scratch / "usage-error-output"
        for selector, flags in [("1", ["--select", "no-matching-test"]), ("1", ["--pilot-versions", "unused.json"]),
                                ("declared-per-test", ["--pilot-versions", "unused.json", "--select", ".*"])]:
            argv = ["run-suite.py", "--compiler", "unused.json", "--results", str(output),
                    "--langversion", selector, "--suite", "ecma-334", *flags]
            with self.subTest(flags=flags), patch.object(sys, "argv", argv), \
                    patch.object(self.runner, "load_config", return_value=(self.config, {}, {})), \
                    patch.object(self.runner, "load_manifest", return_value=self.tests), \
                    patch.object(self.runner, "Context") as compiler, patch("sys.stderr", new=io.StringIO()), \
                    self.assertRaises(SystemExit) as error:
                self.runner.main()
            self.assertEqual(error.exception.code, 2)
            compiler.assert_not_called()
            self.assertFalse(output.exists())

    def test_edition_run_records_selection_and_level_in_both_summaries(self):
        output = self.scratch / "edition-output"
        own = {**self.tests[0], "path": "clauses/07-basic-concepts/tests/example.cs"}
        def compile_test(test, level, mode, raw, status):
            return {**test, "level": level["level"], "mode": mode, "status": "pass", "departure": False}
        context = SimpleNamespace(output=output, provenance=lambda: {}, compile=compile_test,
                                  run_batch=lambda prepared, jobs: prepared)
        argv = ["run-suite.py", "--compiler", "unused.json", "--results", str(output), "--edition", "1", "--suite", "ecma-334"]
        with patch.object(sys, "argv", argv), patch.object(self.runner, "load_config", return_value=(self.config, {}, {})), \
                patch.object(self.runner, "load_manifest", return_value=[own]), \
                patch.object(self.runner, "edition_definition", return_value=self.definition), \
                patch.object(self.runner, "Context", return_value=context), \
                patch.object(self.runner, "run_controls", return_value={"valid": True, "errors": []}), \
                patch("sys.stdout", new=io.StringIO()):
            self.assertEqual(self.runner.main(), 0)
        run = json.loads((output / "run.json").read_bytes())
        summary = json.loads((output / "summary.json").read_bytes())
        for data in [run, summary]:
            self.assertEqual((data["edition"], data["version_mode"], data["levels"][0]["level"]), (1, "edition", "1"))
        self.assertEqual(run["selected_test_ids"], [["ecma-334", "own"]])
        self.assertEqual(run["edition_selection"]["ecma-334"]["own_test_ids"], ["own"])
        self.assertEqual(run["provenance"]["edition_tables"]["ecma-334"], self.definition["conflict_table"])
        self.assertIn("edition 1 at language level 1", (output / "summary.md").read_text())


class PublishingChecks(unittest.TestCase):
    def setUp(self):
        spec = importlib.util.spec_from_file_location("publishing_check_subject", ROOT / "runner/tools/check-publishing.py")
        self.publishing = importlib.util.module_from_spec(spec)
        spec.loader.exec_module(self.publishing)

    def test_external_pattern_parsing_preserves_regex_and_fails_closed(self):
        path = self.scratch / "patterns.txt"
        path.write_bytes(b"# optional policy\n\n  # comment\n\\bprivate[ -]token\\b\n")
        patterns = self.publishing.forbidden_patterns(path)
        self.assertEqual(len(patterns), 1)
        self.assertEqual(patterns[0][0], 4)
        self.assertIsNotNone(patterns[0][1].search("PRIVATE-TOKEN"))
        self.assertIsNone(patterns[0][1].search("unprivate-token"))
        self.assertEqual(self.publishing.forbidden_patterns(None), [])
        path.write_bytes(b"valid\n[\n")
        with self.assertRaisesRegex(ValueError, "Invalid extra forbidden pattern at line 2"):
            self.publishing.forbidden_patterns(path)

    def test_external_patterns_cover_raw_sources_notices_and_nested_files(self):
        directory = self.scratch / "public-files"
        documents = ["README.md", "LICENSE-MIT", "LICENSE-APACHE", "NOTICE", ".gitattributes",
                     "docs/ARCHITECTURE.md", "docs/CONVENTIONS.md", "docs/CONTRIBUTING.md", "docs/RESULTS.md"]
        for relative in documents:
            path = directory / relative
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_bytes((ROOT / relative).read_bytes())
        raw_relative = "clauses/06-lexical-structure/tests/raw.cs"
        raw_path = directory / "ecma-334" / raw_relative
        raw_path.parent.mkdir(parents=True)
        raw_path.write_bytes(b"\xffPRIVATE-ToKEN\r\n")
        nested = directory / "configs/example.txt"
        nested.parent.mkdir()
        nested.write_bytes(b"private token\n")
        patterns = [(1, re.compile(r"\bprivate[ -]token\b", re.IGNORECASE)),
                    (2, re.compile("Ecma International", re.IGNORECASE))]
        with patch.object(self.publishing, "ROOT", directory), \
                patch.object(self.publishing, "raw_sources", return_value={raw_relative}):
            self.assertEqual(self.publishing.text_audit(["ecma-334"])["errors"], [])
            result = self.publishing.text_audit(["ecma-334"], patterns)
        for relative in ["ecma-334/" + raw_relative, "configs/example.txt", "NOTICE"]:
            self.assertTrue(any(error.startswith(relative + ": extra forbidden text") for error in result["errors"]))
        self.assertTrue(all("extra forbidden text" in error for error in result["errors"]))


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    args.report.parent.mkdir(parents=True, exist_ok=True)
    with tempfile.TemporaryDirectory(prefix="runner-check-", dir=args.report.parent.resolve()) as scratch:
        RunnerChecks.scratch = Path(scratch)
        EditionChecks.scratch = Path(scratch)
        PublishingChecks.scratch = Path(scratch)
        output = io.StringIO()
        checks = unittest.TestSuite(unittest.defaultTestLoader.loadTestsFromTestCase(case)
                                   for case in [RunnerChecks, EditionChecks, PublishingChecks])
        result = unittest.TextTestRunner(stream=output, verbosity=2).run(checks)
    errors = [detail for _, detail in [*result.errors, *result.failures]]
    emit_audit(args.report, {"checks": result.testsRun, "errors": errors, "valid": result.wasSuccessful(),
                             "details": output.getvalue()})
    return 0 if result.wasSuccessful() else 1


if __name__ == "__main__":
    sys.exit(main())
