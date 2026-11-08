"""Check language selection and exhaustive measurement without executing a compiler."""
import argparse
import copy
import hashlib
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
from unittest.mock import Mock, patch

from suite_common import ROOT, digest, emit_audit, fixture_info, parse_test, sha, source_registry, write_json, write_tsv
from suite_config import asset_entries, host_rid, read_config, resolve_level, select_levels, validate_compiler
import suite_editions
from suite_editions import edition_definition, edition_inventory, iso_edition, registered_editions, validate_conflicts, version_inventory
from suite_engine import Context, DEPARTURE_FIELDS, departure_rows, load_controls
from suite_evidence import verify_record
from suite_measurements import Measurement, predecessor, witness_for
from suite_version_schedule import mismatches
from suite_versions import applicability, gating_source, measurement_identity, validate_metadata


def load_runner():
    spec = importlib.util.spec_from_file_location("runner_check_subject", ROOT / "runner/run-suite.py")
    runner = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(runner)
    return runner


def load_mutations():
    spec = importlib.util.spec_from_file_location("mutation_check_subject", ROOT / "runner/tools/check-mutations.py")
    mutations = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(mutations)
    return mutations


def selection_bounds(config, since, until="7.3", behavior="refuses", other=()):
    """Build consistent per-level observations for a selection fixture."""
    levels = list(config["language"]["explicit"])
    lower, upper = levels.index(since), levels.index(until)
    observations = {}
    for index, level in enumerate(levels):
        passing = lower <= index <= upper or level in other
        status = "pass" if passing else "unexpected-reject" if index < lower and behavior == "refuses" else "runtime-fail"
        codes = ["CS8026"] if status == "unexpected-reject" else []
        observations[level] = {"applicable": passing, "original_status": status, "witness_status": status,
                               "diagnostic_codes": codes, "witness_diagnostic_codes": codes}
    return {"since": since, "until": until, "basis": "original", "observations": observations,
            "below_since": {"level": levels[lower - 1] if lower else "", "behavior": behavior if lower else "none"},
            "other_passing_levels": list(other)}


def edition_page_fixture(quote):
    """An edition with contents, a page offset and one cited body clause."""
    pages = ["1. Scope ........ 1\n10. Types ........ 70\n10.1 Requirement ........ 70\n"] + [""] * 83
    pages[14] = "1. Scope\nThe document has an explicit scope."
    pages[83] = "10. Types\n10.1 Requirement\n" + quote
    return "\f".join(pages)


class SourceLocatorChecks(unittest.TestCase):
    def setUp(self):
        from suite_audits import Sources
        self.sources = Sources(source_registry(), None)
        self.sources.texts["ecma-334-ed4"] = "\f".join([
            "1. Scope .... 1\n2. Rules .... 2\n2.1 First rule .... 2\n"
            "2.2 Second rule .... 3\n2.3 Third rule .... 4\n3. End .... 5\n", "",
            "1. Scope\nThe scope applies.",
            "2. Rules\n2.1 First rule\nFirst requirement applies.\n"
            "2.1.1 Deep rule\nNested requirement applies.\nCross-page",
            "requirement applies.\n2.2 Second rule\nSecond requirement applies.\nShared overflow sentence.",
            "2.3 Third rule\nShared overflow sentence.", "3. End\nThe end applies."])
        self.citation = {"source_id": "ecma-334-ed4", "clause": "2.1", "printed_pages": [2],
                         "pdf_pages": [4], "quote": "First requirement applies."}

    def errors(self, citation, ledger=False):
        errors = []
        if ledger:
            printed = ", ".join(map(str, citation["printed_pages"]))
            pdf = ", ".join(map(str, citation["pdf_pages"]))
            self.sources.quote({"source_id": citation["source_id"], "quote_json": json.dumps(citation["quote"]),
                "locator": citation["clause"] + ", p. " + printed + " (PDF p. " + pdf + ")"}, errors, "test")
        else:
            self.sources.citation(citation, errors, "test")
        return errors

    def test_clause_and_page_bound_each_quotation_form(self):
        for ledger in [False, True]:
            self.assertEqual(self.errors(self.citation, ledger), [])
            for change in [{"clause": "2.99"}, {"clause": "2.2"}, {"printed_pages": [3]},
                           {"printed_pages": [3], "pdf_pages": [5]}, {"pdf_pages": [0]},
                           {"clause": "2.1", "quote": "Second requirement applies.",
                            "printed_pages": [3], "pdf_pages": [5]}]:
                with self.subTest(ledger=ledger, change=change):
                    self.assertTrue(self.errors(self.citation | change, ledger))

    def test_parent_clause_includes_deeper_headings_and_page_continuations(self):
        for ledger in [False, True]:
            for change in [{"clause": "2.1.1", "quote": "Nested requirement applies."},
                           {"quote": "Nested requirement applies."},
                           {"quote": "Cross-page requirement applies.", "printed_pages": [2, 3],
                            "pdf_pages": [4, 5]}]:
                with self.subTest(ledger=ledger, change=change):
                    self.assertEqual(self.errors(self.citation | change, ledger), [])

    def test_identical_sentence_in_another_clause_does_not_validate_a_page(self):
        for ledger in [False, True]:
            citation = self.citation | {"clause": "2.3", "quote": "Shared overflow sentence.",
                                       "printed_pages": [3], "pdf_pages": [5]}
            self.assertTrue(self.errors(citation, ledger))
            self.assertEqual(self.errors(citation | {"printed_pages": [4], "pdf_pages": [6]}, ledger), [])

    def test_replacing_a_source_text_cannot_reuse_its_prior_clause_index(self):
        self.assertEqual(self.errors(self.citation), [])
        self.sources.texts["ecma-334-ed4"] = self.sources.texts["ecma-334-ed4"].replace(
            "First requirement applies.", "A different requirement applies.")
        self.assertTrue(self.errors(self.citation))

    def test_contents_headers_and_operator_titles_resolve_to_body_clauses(self):
        text = self.sources.texts["ecma-334-ed4"].replace(
            "2.2 Second rule .... 3", "ECMA-334 Chapter 2 Rules\n2.2 Second rule .... 3")
        text = text.replace("3. End .... 5", "2.4 + operator .... 4\n3. End .... 5")
        self.sources.texts["ecma-334-ed4"] = text.replace(
            "2.3 Third rule\nShared overflow sentence.",
            "2.3 Third rule\nShared overflow sentence.\n2.4 + operator\nThe operator requirement applies.")
        self.assertEqual(self.errors(self.citation | {"clause": "2.4", "printed_pages": [4],
            "pdf_pages": [6], "quote": "The operator requirement applies."}), [])

    def test_ledger_page_lists_accept_ranges_and_repeated_printed_labels(self):
        for printed in ["2-3", "2; p. 3"]:
            errors = []
            self.sources.quote({"source_id": "ecma-334-ed4", "locator": "2.1, p. " + printed + " (PDF p. 4, 5)",
                "quote_json": '"Cross-page requirement applies."'}, errors, "test")
            self.assertEqual(errors, [])


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

    def test_iso_level_authority_comes_from_the_registry(self):
        registry = copy.deepcopy(source_registry())
        for level, source_id in registry["iso_editions"].items():
            self.assertEqual(iso_edition("ecma-334", level)["id"], source_id)
        self.assertIsNone(iso_edition("ecma-334", "3"))
        registry["iso_editions"]["ISO-1"] = "ecma-334-ed1"
        with patch("suite_editions.source_registry", return_value=registry):
            self.assertEqual(iso_edition("ecma-334", "1")["id"], "ecma-334-ed1")

    def test_iso_level_authority_requires_one_primary_source_at_the_same_level(self):
        original = copy.deepcopy(source_registry())
        directory = self.scratch / "iso-registry"
        directory.mkdir()
        mutations = [lambda data: data["iso_editions"].pop("ISO-1"),
                     lambda data: data["iso_editions"].update(extra="ecma-334-ed2"),
                     lambda data: data["iso_editions"].update({"ISO-1": "missing"}),
                     lambda data: data["iso_editions"].update({"ISO-1": "ecma-334-ed4"}),
                     lambda data: data["iso_editions"].update({"ISO-1": ["ecma-334-ed1", "ecma-334-ed2"]}),
                     lambda data: next(entry for entry in data["editions"] if entry["id"] == "ecma-334-ed2").update(role="secondary")]
        for mutate in mutations:
            data = copy.deepcopy(original)
            mutate(data)
            write_json(directory / "source-registry.json", data)
            with self.subTest(registry=data["iso_editions"]), \
                    patch("suite_common.standard_root", return_value=directory), self.assertRaises(ValueError):
                source_registry.__wrapped__()

    def test_iso_claim_and_cross_reference_editions_share_the_level_authority(self):
        for number, source_id, claim in [(1, "ecma-334-ed2", False), (2, "ecma-334-ed2", True),
                                         (3, "ecma-334-ed4", False), (4, "ecma-334-ed4", True)]:
            with self.subTest(edition=number), patch("suite_editions.load_conflicts", return_value={}):
                definition = edition_definition("ecma-334", number, self.config, [])
                self.assertEqual((definition["level_source_id"], definition["claim_run"]), (source_id, claim))

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
        measurement.superseded = {}
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

    def test_refusal_planning_uses_the_requested_levels_positive_observation(self):
        test = {"test_id": "per-level", "expected": "run", "origin": "handwritten"}
        row = selection_bounds(self.config, "5", behavior="meaning-change")
        row["observations"]["1"].update(original_status="unexpected-reject", diagnostic_codes=["CS1644"])
        with patch("suite_versions.version_row", return_value=(row, "current")):
            self.assertEqual(applicability(test, resolve_level(self.config, "1")), "version-gating")
            for label in ["2", "3", "4"]:
                self.assertEqual(applicability(test, resolve_level(self.config, label)), "not-applicable")
            # A refusing predecessor does not turn earlier accepted programs into refusals.
            row["below_since"]["behavior"] = "refuses"
            row["observations"]["2"].update(original_status="diagnostic-fail")
            self.assertEqual(applicability(test, resolve_level(self.config, "2")), "not-applicable")
            for basis in ["original", "repair", "departure-witness", "feature-free-rejection"]:
                row["basis"] = basis
                for status, codes in [("unexpected-reject", ["CS8026"]), ("unexpected-reject", []),
                                      ("compiler-error", ["CS8026"]), ("infrastructure", ["CS8026"]),
                                      ("unsupported", ["CS8026"]), ("pass", [])]:
                    observation = row["observations"]["1"]
                    observation.update(original_status="pass", diagnostic_codes=[], witness_status="pass", witness_diagnostic_codes=[])
                    positive = basis in {"repair", "departure-witness"}
                    observation["witness_status" if positive else "original_status"] = status
                    observation["witness_diagnostic_codes" if positive else "diagnostic_codes"] = codes
                    expected = "version-gating" if basis != "feature-free-rejection" and status == "unexpected-reject" and codes else "not-applicable"
                    with self.subTest(basis=basis, status=status, codes=codes):
                        self.assertEqual(applicability(test, resolve_level(self.config, "1")), expected)

    def test_predecessor_needs_a_coded_positive_refusal(self):
        for basis in ["original", "repair", "departure-witness", "feature-free-rejection"]:
            for status, codes in [("unexpected-reject", ["CS8026"]), ("unexpected-reject", []),
                                  ("infrastructure", ["CS8026"]), ("unsupported", ["CS8026"]),
                                  ("compiler-error", ["CS8026"]), ("pass", ["CS8026"])]:
                observation = {"original_status": status, "witness_status": status,
                               "diagnostic_codes": codes, "witness_diagnostic_codes": codes}
                expected = "refuses" if basis != "feature-free-rejection" and status == "unexpected-reject" and codes else "meaning-change"
                with self.subTest(basis=basis, status=status, codes=codes):
                    self.assertEqual(predecessor(observation, "1", basis)["behavior"], expected)

    def test_gating_source_is_the_measured_positive_program(self):
        root = self.scratch / "gating-basis"
        source = root / "clauses/check/tests/input.cs"
        witness = root / "clauses/check/version-witnesses/positive.cs.part"
        source.parent.mkdir(parents=True)
        witness.parent.mkdir(parents=True)
        source.write_bytes(b"/*\nExpected: run\n*/\nclass Input { int value = 1; }\n")
        witness.write_bytes(b"class Positive {}\n")
        raw, declared = source.read_bytes(), witness.read_bytes()
        repaired = raw.replace(b"int value = 1;", b"int value = 2;")
        test = {"test_id": "gating-basis", "suite_id": "ecma-334", "path": "clauses/check/tests/input.cs",
                "expected": "run", "origin": "handwritten", "version_witness": "version-witnesses/positive.cs.part",
                "mutation_old": "int value = 1;", "mutation_new": "int value = 2;"}
        for basis, expected in [("original", raw), ("repair", declared), ("departure-witness", declared)]:
            row = {"basis": basis, "witness_sha256": hashlib.sha256(expected).hexdigest()}
            with self.subTest(basis=basis), patch("suite_versions.standard_root", return_value=root), \
                    patch("suite_versions.version_row", return_value=(row, "current")):
                self.assertEqual(gating_source(test), expected)
                row["witness_sha256"] = "0" * 64
                with self.assertRaisesRegex(ValueError, "measured positive"):
                    gating_source(test)
        test.update(expected="reject", version_witness="")
        row = {"basis": "repair", "witness_sha256": hashlib.sha256(repaired).hexdigest()}
        with patch("suite_versions.standard_root", return_value=root), \
                patch("suite_versions.version_row", return_value=(row, "current")):
            self.assertEqual(gating_source(test), repaired)
            test["origin"] = "generated"
            with self.assertRaisesRegex(ValueError, "positive"):
                gating_source(test)
            row["basis"] = "feature-free-rejection"
            with self.assertRaisesRegex(ValueError, "positive"):
                gating_source(test)


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

    def test_alternative_compilation_outcomes_require_counted_output_and_a_witness(self):
        root = self.scratch / "alternative-header"
        folder = root / "clauses/10-conversions/tests/E10-5-4-alternative"
        folder.mkdir(parents=True)
        source = folder / "conversion.cs"
        witness = root / "clauses/10-conversions/version-witnesses/positive.cs.part"
        witness.parent.mkdir(parents=True)
        witness.write_bytes(b"class Positive {}\n")
        header = ("/*\nRules: E10-5-4-alternative\nAuthority: ECMA-334 7th ed 10.5.4\nVersion: 7.3\n"
                  "Expected: run-or-reject\nStdout: OK 1\n"
                  "Version-Witness: version-witnesses/positive.cs.part\n"
                  "Mutate: int value = 1;\nInto: int value = 0;\n*/\nclass Input { int value = 1; }\n")
        registry = source_registry("ecma-334")
        with patch("suite_common.standard_root", return_value=root), patch("suite_common.raw_sources", return_value={}), \
                patch("suite_common.source_registry", return_value=registry):
            source.write_bytes(header.encode("ascii"))
            test = parse_test(source)
            self.assertEqual((test["expected"], json.loads(test["stdout_json"])), ("run-or-reject", "OK 1\n"))
            for old, new, error in [("Stdout: OK 1\n", "", "Stdout"),
                                    ("Version-Witness: version-witnesses/positive.cs.part\n", "", "positive Version-Witness"),
                                    ("Stdout: OK 1\n", "Stdout: OK 1\nDiagnostic: none\n", "Diagnostic requires"),
                                    ("Stdout: OK 1\n", 'Stdout: OK 1\nSource-Diagnostic: [{"case_id":"location","source":"class Input { int value = 1; }","severity":"error","file":"physical","line":"physical"}]\n', "no Source-Diagnostic"),
                                    ("Expected: run-or-reject", "Expected: anything", "Expected must")]:
                with self.subTest(error=error):
                    source.write_bytes(header.replace(old, new).encode("ascii"))
                    with self.assertRaisesRegex(ValueError, error):
                        parse_test(source)

    def test_alternative_outcomes_replay_without_hiding_execution_or_fixture_failures(self):
        source = self.scratch / "alternative-source.cs"
        source.write_bytes(b"class Input { static void Main() {} }\n")
        original = next(row for row in load_controls() if row["test_id"] == "control--positive")
        scenarios = [
            ("accept", "test", False, "OK 1\n", 0, "pass"),
            ("reject", "test", False, "", "", "pass"),
            ("accept", "test", False, "OK 0\n", 0, "runtime-fail"),
            ("accept", "test", False, "OK 1\n", 1, "runtime-fail"),
            ("accept", "test", False, "", "timeout", "runtime-fail"),
            ("reject", "test", True, "", "", "unexpected-reject"),
            ("unsupported", "test", False, "", "", "unsupported"),
            ("uncoded", "test", False, "", "", "unexpected-reject"),
            ("crash", "test", False, "", "", "compiler-error"),
            ("command", "test", False, "", "", "infrastructure"),
            ("accept", "version-gating", False, "", "", "unexpected-accept"),
            ("reject", "version-gating", False, "", "", "pass"),
            ("reject", "compile-only", False, "", "", "unexpected-reject"),
        ]
        for index, (verdict, mode, library, stdout, code, expected) in enumerate(scenarios):
            with self.subTest(verdict=verdict, mode=mode, library=library, stdout=stdout, code=code):
                test = dict(original, test_id="control--alternative", expected="run-or-reject",
                            source_sha256=sha(source), stdout_json=json.dumps("OK 1\n"), diagnostic="")
                if library:
                    test["fixture_json"] = json.dumps({"libraries": [{"name": "Dependency", "units": [{"source": "self"}]}], "program": {}})
                context = Context.__new__(Context)
                context.evidence_only, context.config = False, copy.deepcopy(self.config)
                context.config["diagnostics"]["feature_refusal_codes"] = ["CS9998"]
                context.config["diagnostics"]["command_line_codes"] = ["CS9999"]
                context.output = self.scratch / ("alternative-" + str(index))
                context.target_config = {"id": "dotnet", "description": "synthetic target", "references": {}, "adapter": "dotnet"}
                context.target_assets, context._departures = {}, {}
                context.artifact_extension, context.identity_sha256 = ".dll", "f" * 64
                context.compile_timeout, context.run_timeout = 60, 20
                context.source_path = lambda test: source
                context.preflight = lambda *args: ("", "", [])
                context.command = lambda units, output, *args: ["compiler", str(output), *map(str, units)]
                context.target = SimpleNamespace(prepare=lambda output: None,
                    command=lambda request: ["host", request["entry"]])
                def execute(command, *args):
                    if verdict == "accept":
                        Path(command[1]).write_bytes(b"synthetic program")
                        return 0, "", "", 0.0
                    if verdict == "crash":
                        return 255, "", "", 0.0
                    if verdict == "uncoded":
                        return 1, "unclassified failure\n", "", 0.0
                    diagnostic = {"reject": "CS0457", "unsupported": "CS9998", "command": "CS9999"}[verdict]
                    return 1, "input.cs(1,1): error " + diagnostic + ": Cannot compile.\n", "", 0.0
                context.execute = execute
                level = resolve_level(context.config, "7.3")
                pending = context.compile(test, level, mode)
                runtime = None
                if pending["request"]:
                    runtime = dict(exit=code, stdout=stdout, stderr="", elapsed_seconds=0.0,
                                   command=context.target.command(pending["request"]))
                record = context.finish(pending, runtime)
                self.assertEqual(record["status"], expected)
                if verdict == "reject" and mode == "test" and not library:
                    self.assertEqual((record["reason"], record["run_exit"]), ("permitted-rejection", ""))
                verify_record(context, test, record, level, mode)
                if expected != "pass":
                    forged = dict(record, status="pass", reason="permitted-rejection")
                    write_json(Path(record["artifact_directory"]) / "result.json", forged)
                    with self.assertRaisesRegex(ValueError, "classification differs"):
                        verify_record(context, test, forged, level, mode)

    def test_alternative_outcome_measurement_requires_its_positive_construct(self):
        source = self.scratch / "alternative-measure-source.cs"
        witness = self.scratch / "alternative-measure-witness.cs.part"
        source.write_bytes(b"class Question {}\n")
        witness.write_bytes(b"class Positive {}\n")
        test = {"suite_id": "ecma-334", "test_id": "alternative", "path": "clauses/check/tests/a.cs",
                "expected": "run-or-reject", "version_witness": "positive.cs.part", "origin": "handwritten"}
        context = SimpleNamespace(source_path=lambda test:source)
        with patch("suite_measurements.inside", return_value=witness):
            basis, raw, declared = witness_for(test, context, {})
        self.assertEqual((basis, raw, declared), ("repair", witness.read_bytes(), sha(witness)))
        with self.assertRaisesRegex(ValueError, "positive construct witness"):
            witness_for({**test, "version_witness": ""}, context, {})
        measurement = Measurement.__new__(Measurement)
        original = {"status": "pass", "error_diagnostic_codes": "CS0457", "result_path": str(source)}
        positive = {"status": "unexpected-reject", "error_diagnostic_codes": "CS8026", "result_path": str(witness)}
        self.assertFalse(measurement.observation("repair", original, positive)["applicable"])
        self.assertTrue(measurement.observation("repair", original, {**positive, "status": "pass"})["applicable"])

    def test_mutations_require_an_accepted_original_and_its_own_departure(self):
        mutations = load_mutations()
        test = {"expected": "run-or-reject", "diagnostic": ""}
        accepted = {"status": "pass", "reason": "", "departure": False}
        permitted = {**accepted, "reason": "permitted-rejection"}
        rejected = {"status": "unexpected-reject", "reason": "required-compilation", "departure": False}
        for mutant in [rejected, accepted, {"status": "runtime-fail", "reason": "wrong-output"},
                       {"status": "diagnostic-fail", "reason": "warning-none"}]:
            with self.subTest(mutant=mutant):
                self.assertEqual(mutations.classify(test, permitted, mutant, False)[0], "inconclusive-original")
        self.assertEqual(mutations.classify(test, accepted, rejected, False)[0], "killed")
        self.assertEqual(mutations.classify(test, accepted, accepted, False)[0], "survived")
        self.assertEqual(mutations.classify({**test, "expected": "reject"}, accepted, accepted, False)[0], "repaired")
        # A ledger entry alone, or a passing original, cannot excuse a survivor.
        self.assertEqual(mutations.classify(test, accepted, accepted, True)[0], "survived")
        self.assertEqual(mutations.classify(test, {**accepted, "departure": True}, accepted, True)[0], "survived")
        self.assertEqual(mutations.classify(test, {**rejected, "departure": True}, accepted, True)[0], "inconclusive-departure")

    def test_mutation_pairs_keep_the_plan_level_and_scope_departures(self):
        mutations = load_mutations()
        resolution = resolve_level(self.config, "2")
        for resume in [False, True]:
            for scenario in ["matching", "other-compiler", "other-commit", "other-target", "other-source",
                             "other-level", "conforming-boundary"]:
                for original_failed in [False, True]:
                    with self.subTest(resume=resume, scenario=scenario, original_failed=original_failed):
                        output = self.scratch / ("mutation-plan-" + scenario + "-" + str(resume) + "-" + str(original_failed))
                        output.mkdir()
                        source = output / "input.cs"
                        source.write_bytes(b"/*\nExpected: run\n*/\nclass Input { int value = 1; }\n")
                        membership = {"edition": 4, "level_source_id": "ecma-334-ed4", "superseded": None,
                                      "conflict_table": {"path": "ecma-334/edition-conflicts/4.json", "sha256": "4" * 64}}
                        test = dict(next(row for row in load_controls() if row["test_id"] == "control--positive"))
                        test.update(suite_id="ecma-334", test_id="planned", version="1", origin="handwritten",
                                    path="clauses/10-conversions/tests/causal.cs", expected="run", diagnostic="",
                                    source_sha256=sha(source), mutation_old="int value = 1;", mutation_new="int value = 2;",
                                    edition_membership=membership)
                        row = {"status": "confirmed", "kind": "compiler", "source_sha256": sha(source),
                               "compiler_id": self.config["id"], "compiler_commit": self.config["commit"],
                               "target_id": "dotnet", "levels_json": '["2"]', "conforms_since": ""}
                        context = Context.__new__(Context)
                        context.config = copy.deepcopy(self.config)
                        context.target_config, context.output = {"id": "dotnet"}, output
                        context._departures = {"ecma-334": {"planned": row}}
                        context.source_path, context.provenance = lambda current: source, lambda: {}
                        if scenario == "other-compiler":
                            context.config["id"] = "another"
                        elif scenario == "other-commit":
                            context.config["commit"] = "0" * 40
                        elif scenario == "other-target":
                            row["target_id"] = "another"
                        elif scenario == "other-source":
                            row["source_sha256"] = "0" * 64
                        elif scenario == "other-level":
                            row["levels_json"] = '["1"]'
                        elif scenario == "conforming-boundary":
                            row["conforms_since"] = "2"
                        calls = []
                        def record(method, current, level, mode, executed_bytes):
                            actual = level or resolve_level(context.config, current["version"])
                            calls.append((method, actual["level"], mode))
                            failed = original_failed and mode == "test"
                            raw = source.read_bytes() if executed_bytes is None else executed_bytes
                            result = {"suite_id": current["suite_id"], "test_id": current["test_id"],
                                      "source_sha256": current["source_sha256"], "level": actual["level"], "mode": mode,
                                      "status": "unexpected-reject" if failed else "pass",
                                      "reason": "required-compilation" if failed else "", "departure": False,
                                      "departure_kind": "", "diagnostics": [], "compile_exit": 1 if failed else 0,
                                      "executed_source_sha256": hashlib.sha256(raw).hexdigest(),
                                      "edition_membership": current.get("edition_membership"),
                                      "result_path": str(output / (mode + ".json"))}
                            context.mark_departure(result)
                            write_json(Path(result["result_path"]), result)
                            return result
                        context.run = lambda current, level=None, mode="test", executed_bytes=None: record(
                            "run", current, level, mode, executed_bytes)
                        context.saved = lambda current, level=None, mode="test", completed=False, executed_bytes=None: record(
                            "saved", current, level, mode, executed_bytes)
                        argv = ["check-mutations.py", "--compiler", "unused.json", "--results", str(output),
                                "--suite", "ecma-334", *(["--resume"] if resume else [])]
                        exempt = original_failed and scenario == "matching"
                        with patch.object(sys, "argv", argv), patch.object(mutations, "load_config", return_value=(context.config, {}, {})), \
                                patch.object(mutations, "load_manifest", return_value=[test]), \
                                patch.object(mutations, "header_plans", return_value=([(test, resolution, "test")], {})), \
                                patch.object(mutations, "Context", return_value=context), \
                                patch.object(mutations, "run_controls", return_value={"valid": True, "errors": []}), \
                                patch.object(mutations, "departure_rows", return_value={"planned": row}, create=True), \
                                patch("sys.stdout", new=io.StringIO()):
                            self.assertEqual(mutations.main(), 0 if exempt else 1)
                        self.assertEqual(calls, [("saved" if resume else "run", "2", mode) for mode in ["test", "mutation"]])
                        summary = json.loads((output / "summary.json").read_bytes())
                        observed = summary["rows"][0]
                        expected = "inconclusive-departure" if exempt else "inconclusive-original" if original_failed else "survived"
                        self.assertEqual(observed["status"], expected)
                        self.assertEqual(json.loads(observed["edition_membership_json"]), membership)
                        for field in ["original_result", "mutant_result"]:
                            result = json.loads(Path(observed[field]).read_bytes())
                            self.assertEqual((result["level"], result["edition_membership"]), ("2", membership))


class EditionChecks(unittest.TestCase):
    config = RunnerChecks.config

    def setUp(self):
        editions = registered_editions("ecma-334")
        self.editions = {number: copy.deepcopy(editions[number]) for number in [1, 7]}
        registry = patch("suite_editions.registered_editions", return_value=self.editions)
        registry.start()
        self.addCleanup(registry.stop)
        unmapped = patch("suite_editions.iso_edition", return_value=None)
        unmapped.start()
        self.addCleanup(unmapped.stop)
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
        self.rows = {test["test_id"]: selection_bounds(self.config, "1") for test in self.tests}
        for name in ["own", "own-2", "late", "feature", "disconnected"]:
            self.rows[name] = selection_bounds(self.config, "2")
        self.rows["disconnected"]["other_passing_levels"] = ["1"]
        self.runner = load_runner()

    def args(self, **changes):
        values = dict(edition=1, langversion=None, select=".*", origin=None, pilot_versions=None)
        return SimpleNamespace(**(values | changes))

    def bounds(self, test):
        return self.rows[test["test_id"]], "current"

    def add_second_edition(self):
        self.editions[2] = {**self.editions[1], "id": "ecma-334-ed2", "authority_prefix": "ECMA-334 2nd ed"}
        test = {**self.tests[0], "test_id": "second", "authority": "ECMA-334 2nd ed 10.1"}
        self.tests.append(test)
        self.rows["second"] = selection_bounds(self.config, "1")
        return test

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

    def test_cited_compiler_leave_out_suppresses_claims_and_refusals(self):
        self.add_second_edition()
        compiler = source_registry("ecma-334")["compiler_authority"]
        feature = {**self.tests[-2], "test_id": "feature", "version": "8.0",
                   "authority": compiler["id"] + " " + compiler["version"] + " (C# 8.0)"}
        peer = next(test for test in self.tests if test["test_id"] == "continuity")
        for number, language in [(1, "ISO-1"), (2, "ISO-2")]:
            row = {"action": "leave-out", "test_id": "feature",
                   "authority": self.editions[number]["authority_prefix"] + " 10.1, p. 69 (PDF p. 83)"}
            table = {**self.table, "edition": number, "conflicts": [row]}
            definition = {**self.definition, "edition": number, "level": resolve_level(self.config, language),
                          "table": table}
            validate_conflicts(table, "ecma-334", [feature, peer])
            for since in ["1", "3"]:
                self.rows["feature"] = selection_bounds(self.config, since)
                with self.subTest(edition=number, since=since), \
                        patch("suite_versions.version_row", side_effect=self.bounds), \
                        patch("suite_editions.superseded_claims", return_value={}):
                    baseline, reasons = edition_inventory([feature, peer], {"ecma-334": {
                        **definition, "table": {**table, "conflicts": []}}}, gating=True)
                    self.assertEqual({test["test_id"] for test in baseline}, {"feature", "continuity"})
                    category = "continuity_test_ids" if since == "1" else "version_gating_test_ids"
                    self.assertIn("feature", reasons["ecma-334"][category])
                    selected, reasons = edition_inventory([feature, peer], {"ecma-334": definition}, gating=True)
                    self.assertEqual([test["test_id"] for test in selected], ["continuity"])
                    self.assertEqual(reasons["ecma-334"]["left_out_test_ids"], ["feature"])
                    self.assertEqual(reasons["ecma-334"]["version_gating_test_ids"], [])
                selected, _ = edition_inventory([feature, peer], {"ecma-334": definition}, header=True)
                self.assertEqual([test["test_id"] for test in selected], ["continuity"])

    def test_compiler_targets_require_cited_ordinary_leave_out(self):
        compiler = source_registry("ecma-334")["compiler_authority"]
        feature = {**self.tests[-1], "version": "8.0",
                   "authority": compiler["id"] + " " + compiler["version"] + " (C# 8.0)"}
        table = {**self.table, "conflicts": [{"action": "leave-out", "test_id": "feature",
                 "authority": "ECMA-334 1st ed 10.1, p. 69 (PDF p. 83)"}]}
        for scenario in ["replace", "superseded", "uncited", "unknown-authority", "other-version"]:
            invalid, tests = copy.deepcopy(table), [copy.deepcopy(feature), self.tests[0]]
            if scenario == "replace":
                invalid["conflicts"][0].update(action="replace", replacement_test_id="own")
            elif scenario == "superseded":
                invalid["conflicts"][0]["superseded"] = {}
            elif scenario == "uncited":
                invalid["conflicts"][0]["authority"] = "ECMA-334 1st ed 10.1"
            elif scenario == "unknown-authority":
                tests[0]["authority"] = "Unknown source"
            else:
                tests[0]["authority"] = compiler["id"] + " unpinned (C# 8.0)"
            with self.subTest(scenario=scenario), self.assertRaises(ValueError):
                validate_conflicts(invalid, "ecma-334", tests)

    def prepare_edition(self, tests=None, args=None):
        with patch.object(self.runner, "edition_definition", return_value=self.definition):
            return self.runner.prepare_run(tests or self.tests, ["ecma-334"], self.config, args or self.args())

    def test_continuity_obeys_upper_interval_edge_and_other_editions(self):
        self.definition["level"] = resolve_level(self.config, "2")
        self.rows["continuity"]["until"] = "1"
        other = {**self.tests[0], "test_id": "other-edition", "authority": "ECMA-334 2nd ed 10.1"}
        self.rows["other-edition"] = selection_bounds(self.config, "1", until="2")
        editions = copy.deepcopy(self.editions)
        editions[2] = {**editions[1], "authority_prefix": "ECMA-334 2nd ed"}
        with patch("suite_editions.registered_editions", return_value=editions), \
                patch("suite_versions.version_row", side_effect=self.bounds):
            tests = self.prepare_edition([*self.tests, other])[0]
            self.assertIn("other-edition", [test["test_id"] for test in tests])
            self.assertNotIn("continuity", [test["test_id"] for test in tests])
            self.assertNotIn("other-edition", [test["test_id"] for test in version_inventory([other, *self.tests])])

    def test_older_editions_join_by_continuity_in_both_directions(self):
        second = self.add_second_edition()
        first = self.tests[0]
        self.rows["own"] = selection_bounds(self.config, "1")
        for requested, own, continuing in [(1, first, second), (2, second, first)]:
            table = {**self.table, "edition": requested, "conflicts": []}
            definition = {**self.definition, "edition": requested, "table": table}
            with self.subTest(edition=requested), patch("suite_versions.version_row", side_effect=self.bounds):
                validate_conflicts(table, "ecma-334", self.tests)
                tests, decisions = edition_inventory([first, second], {"ecma-334": definition})
            self.assertEqual([test["test_id"] for test in tests], ["own", "second"])
            self.assertEqual(decisions["ecma-334"]["own_test_ids"], [own["test_id"]])
            self.assertEqual(decisions["ecma-334"]["continuity_test_ids"], [continuing["test_id"]])

    def test_older_edition_conflicts_are_symmetric(self):
        second = self.add_second_edition()
        first = self.tests[0]
        for requested, own, target in [(1, first, second), (2, second, first)]:
            for action in ["replace", "leave-out"]:
                row = {"action": action, "test_id": target["test_id"],
                       "authority": own["authority"] + ", p. 69 (PDF p. 83)"}
                if action == "replace":
                    row["replacement_test_id"] = own["test_id"]
                table = {**self.table, "edition": requested, "conflicts": [row]}
                definition = {**self.definition, "edition": requested, "table": table}
                with self.subTest(edition=requested, action=action), \
                        patch("suite_versions.version_row", side_effect=self.bounds):
                    validate_conflicts(table, "ecma-334", self.tests)
                    tests, decisions = edition_inventory([first, second], {"ecma-334": definition})
                self.assertEqual([test["test_id"] for test in tests], [own["test_id"]])
                category = "replaced_test_ids" if action == "replace" else "left_out_test_ids"
                self.assertEqual(decisions["ecma-334"][category], [target["test_id"]])

    def test_cross_edition_canonical_replacement_and_requested_citation(self):
        self.add_second_edition()
        self.rows["own"] = selection_bounds(self.config, "1")
        row = {**self.table["conflicts"][0], "authority": "ECMA-334 2nd ed 10.1, p. 71 (PDF p. 87)"}
        table = {**self.table, "edition": 2, "conflicts": [row]}
        definition = {**self.definition, "edition": 2, "table": table}
        validate_conflicts(table, "ecma-334", self.tests)
        with patch("suite_versions.version_row", side_effect=self.bounds):
            tests, decisions = edition_inventory(self.tests, {"ecma-334": definition})
        self.assertIn("own", [test["test_id"] for test in tests])
        self.assertIn("own", decisions["ecma-334"]["continuity_test_ids"])
        self.assertEqual(decisions["ecma-334"]["replaced_test_ids"], ["replaced"])
        mutations = [lambda row: row.update(test_id="second"),
                     lambda row: row.update(test_id="feature"),
                     lambda row: row.update(replacement_test_id="continuity"),
                     lambda row: row.update(replacement_test_id="feature"),
                     lambda row: row.update(authority="ECMA-334 1st ed 10.1, p. 69 (PDF p. 83)")]
        for index, change in enumerate(mutations):
            invalid = copy.deepcopy(table)
            change(invalid["conflicts"][0])
            with self.subTest(mutation=index), self.assertRaises(ValueError):
                validate_conflicts(invalid, "ecma-334", self.tests)

    def test_cited_older_replacement_outside_interval_keeps_bounds_and_runs_ordinary(self):
        self.add_second_edition()
        row = {**self.table["conflicts"][0], "replacement_test_id": "second"}
        table = {**self.table, "conflicts": [row]}
        definition = {**self.definition, "table": table}
        validate_conflicts(table, "ecma-334", self.tests)
        for bounds in [selection_bounds(self.config, "2"), selection_bounds(self.config, "2", other=["1"])]:
            self.rows["second"] = bounds
            original = copy.deepcopy(bounds)
            with self.subTest(bounds=bounds), patch("suite_versions.version_row", side_effect=self.bounds), \
                    patch.object(self.runner, "edition_definition", return_value=definition):
                tests, plans, selection, levels, details = self.runner.prepare_run(
                    self.tests, ["ecma-334"], self.config, self.args())
            self.assertIn("second", [test["test_id"] for test in tests])
            self.assertIn("second", details["edition_selection"]["ecma-334"]["replacement_test_ids"])
            self.assertEqual([(level["level"], mode) for test, level, mode in plans if test["test_id"] == "second"],
                             [("1", "test")])
            self.assertEqual(self.rows["second"], original)
        self.rows["second"] = selection_bounds(self.config, "1")
        with patch("suite_versions.version_row", side_effect=self.bounds):
            self.assertIn("second", [test["test_id"] for test in
                          edition_inventory(self.tests, {"ecma-334": definition})[0]])
        self.tests[-1]["version_status"] = "stale"
        with patch("suite_versions.version_row", side_effect=self.bounds), \
                self.assertRaisesRegex(ValueError, "Current bounds required"):
            edition_inventory(self.tests, {"ecma-334": definition})

    def test_outside_interval_replacement_requires_older_standard_authority_and_citation(self):
        self.add_second_edition()
        for replacement in ["continuity", "feature"]:
            table = {**self.table, "conflicts": [{**self.table["conflicts"][0],
                                                "replacement_test_id": replacement}]}
            with self.subTest(replacement=replacement), self.assertRaisesRegex(ValueError, "older edition"):
                validate_conflicts(table, "ecma-334", self.tests)
        for citation in ["ECMA-334 1st ed 10.1", "ECMA-334 2nd ed 10.1, p. 71 (PDF p. 87)"]:
            table = {**self.table, "conflicts": [{**self.table["conflicts"][0],
                                                "replacement_test_id": "second", "authority": citation}]}
            with self.subTest(citation=citation), self.assertRaisesRegex(ValueError, "clause and printed/PDF"):
                validate_conflicts(table, "ecma-334", self.tests)

    def test_replacement_admission_requires_target_in_candidate_selection(self):
        second = self.add_second_edition()
        self.rows["second"] = selection_bounds(self.config, "2")
        table = {**self.table, "conflicts": [{**self.table["conflicts"][0], "replacement_test_id": "second"}]}
        definition = {**self.definition, "table": table}
        validate_conflicts(table, "ecma-334", self.tests)
        with patch("suite_versions.version_row", side_effect=self.bounds):
            tests, decisions = edition_inventory([self.tests[0], second], {"ecma-334": definition})
        self.assertEqual([test["test_id"] for test in tests], ["own"])
        self.assertEqual(decisions["ecma-334"]["replacement_test_ids"], [])

    def test_off_header_departure_preserves_reject_measurement_and_failure(self):
        source = self.scratch / "reject.cs"
        source.write_bytes(b"/*\nExpected: reject\n*/\nclass Entry { int value = 1; }\n")
        test = {"suite_id": "ecma-334", "test_id": "reject", "version": "ISO-1", "expected": "reject",
                "version_witness": "", "origin": "handwritten", "path": "clauses/check/tests/reject.cs",
                "mutation_old": "int value", "mutation_new": "long value"}
        row = {"status": "confirmed", "kind": "compiler", "levels_json": '["2"]', "conforms_since": "",
               "source_sha256": sha(source), "compiler_id": "csc", "compiler_commit": self.config["commit"],
               "target_id": "dotnet"}
        context = Context.__new__(Context)
        context.config, context.target_config = self.config, {"id": "dotnet"}
        context.source_path = lambda test: source
        context._departures = {"ecma-334": {"reject": row}}
        basis, positive, declared = witness_for(test, context, {"reject": row})
        self.assertEqual((basis, positive, declared),
                         ("repair", b"/*\nExpected: reject\n*/\nclass Entry { long value = 1; }\n", ""))
        record = {"suite_id": "ecma-334", "test_id": "reject", "mode": "test", "source_sha256": sha(source),
                  "level": "2", "status": "unexpected-accept", "departure": False, "departure_kind": ""}
        context.mark_departure(record)
        self.assertEqual((record["status"], record["departure"], record["departure_kind"]),
                         ("unexpected-accept", True, "compiler"))
        with self.assertRaisesRegex(ValueError, "declared positive construct witness"):
            witness_for({**test, "version": "ISO-2"}, context, {"reject": row})

    def test_active_conflict_requires_replacement_in_filtered_selection(self):
        with patch("suite_versions.version_row", side_effect=self.bounds):
            with self.assertRaisesRegex(ValueError, "Replacement is not selected"):
                self.prepare_edition([self.tests[2]])
            tests = self.prepare_edition([self.tests[0]])[0]
        self.assertEqual([test["test_id"] for test in tests], ["own"])

    def test_replacements_cannot_be_excluded_or_form_cycles(self):
        second = self.add_second_edition()
        self.rows["second"] = selection_bounds(self.config, "2")
        other = {**second, "test_id": "second-other"}
        self.tests.append(other)
        citation = "ECMA-334 1st ed 10.1, p. 69 (PDF p. 83)"
        for action in ["replace", "leave-out"]:
            excluded = {"action": action, "test_id": "second", "authority": citation}
            if action == "replace":
                excluded["replacement_test_id"] = "own"
            table = {**self.table, "conflicts": [
                {**self.table["conflicts"][0], "replacement_test_id": "second"}, excluded]}
            with self.subTest(action=action), self.assertRaisesRegex(ValueError, "itself replaced or left out"):
                validate_conflicts(table, "ecma-334", self.tests)
        for links in [[("second", "second")], [("second", "second-other"), ("second-other", "second")]]:
            table = {**self.table, "conflicts": [
                {"action": "replace", "test_id": target, "replacement_test_id": replacement,
                 "authority": citation} for target, replacement in links]}
            with self.subTest(links=links), self.assertRaisesRegex(ValueError, "itself replaced or left out"):
                validate_conflicts(table, "ecma-334", self.tests)

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


class SupersededChecks(unittest.TestCase):
    config = RunnerChecks.config

    def setUp(self):
        self.runner = load_runner()
        self.editions = registered_editions("ecma-334")
        self.tests = []
        self.rows = {}
        for number, names in [(1, ["first-changed", "first-kept"]), (2, ["second-own"]),
                              (3, ["third-changed", "third-kept"]), (4, ["fourth-own"]), (7, ["latest"])]:
            for name in names:
                test = dict(load_controls()[0])
                test.update(suite_id="ecma-334", test_id=name, path="clauses/07-basic-concepts/tests/" + name + ".cs",
                            authority=self.editions[number]["authority_prefix"] + " 10.1", version_status="current",
                            version=self.editions[number]["language_version"], origin="handwritten", diagnostic="")
                test["fixture_sha256"] = fixture_info({}, "ecma-334", "07-basic-concepts", False, [])
                self.tests.append(test)
                self.rows[name] = selection_bounds(self.config, "1" if number < 3 else "2")
        self.tables = {number: {"schema_version": 1, "edition": number, "base_edition": 7, "conflicts": []}
                       for number in [1, 2, 3, 4]}
        for number, old, name in [(2, 1, "first-changed"), (4, 3, "third-changed")]:
            self.tables[number]["conflicts"] = [self.row(name, old, number)]
            self.rows[name] = selection_bounds(self.config, "3")
        for target, value in [("suite_editions.load_conflicts", self.table),
                              ("suite_versions.version_row", self.bounds),
                              ("suite_editions.sha", lambda path: digest(self.tables[int(path.stem)]))]:
            mocked = patch(target, side_effect=value)
            mocked.start()
            self.addCleanup(mocked.stop)
        bounds = patch.object(self.runner, "version_row", side_effect=self.bounds)
        bounds.start()
        self.addCleanup(bounds.stop)

    def row(self, name, old, new):
        def citation(number, quote):
            return {"source_id": self.editions[number]["id"], "clause": "10.1", "printed_pages": [70],
                    "pdf_pages": [84], "quote": quote}
        return {"action": "leave-out", "test_id": name,
                "authority": self.editions[new]["authority_prefix"] + " 10.1, p. 70 (PDF p. 84)",
                "superseded": {"test": [citation(old, "The older requirement applies.")],
                               "level": [citation(new, "The changed requirement applies.")]}}

    def table(self, suite_id, number, tests):
        return validate_conflicts(copy.deepcopy(self.tables[number]), suite_id, tests)

    def bounds(self, test):
        return self.rows[test["test_id"]], "current"

    def prepare(self, *, edition=None, language=None, select=".*", tests=None):
        args = SimpleNamespace(edition=edition, langversion=language, select=select, origin=None, pilot_versions=None)
        return self.runner.prepare_run(self.tests if tests is None else tests, ["ecma-334"], self.config, args)

    def context(self, label, test):
        source = self.scratch / (label + ".cs")
        source.write_bytes(b"class Input {}\n")
        test["source_sha256"] = sha(source)
        context = Context.__new__(Context)
        context.evidence_only, context.config = False, self.config
        context.output = self.scratch / label
        context.target_config = {"id": "dotnet", "description": "synthetic target", "references": {}}
        context.target_assets, context._departures = {}, {"ecma-334": {}}
        context.artifact_extension, context.identity_sha256 = ".dll", "f" * 64
        context.compile_timeout, context.run_timeout = 60, 20
        context.source_path = lambda test: source
        context.preflight = Mock(side_effect=AssertionError("Superseded must precede capability checks"))
        context.execute = Mock(side_effect=AssertionError("Superseded must not execute"))
        context.target = SimpleNamespace(run_batch=Mock(side_effect=AssertionError("Superseded must not run")))
        return context, source

    def observation(self, name, level, status="conforming"):
        test = next(test for test in self.tests if test["test_id"] == name)
        own = next(number for number, entry in self.editions.items()
                   if test["authority"].startswith(entry["authority_prefix"] + " "))
        source = self.editions[own] if status == "conforming" else iso_edition("ecma-334", level) or self.editions[own]
        return dict(zip(DEPARTURE_FIELDS, [name, "compiler", "E7-1-observation", source["id"],
                    "10.1, p. 70 (PDF p. 84)", '"The older requirement applies."', test["source_sha256"],
                    "csc", self.config["commit"], "dotnet", json.dumps([level]), '{"compile_exit":1}', status, "",
                    "Observation against the older requirement; the governing requirement is satisfied."]))

    def ledger(self, departures=(), observations=()):
        from suite_audits import COVERAGE_FIELDS, ledger_audit
        directory = self.scratch / "observation-ledger"
        clause = directory / "clauses/07-basic-concepts"
        for test in self.tests:
            path = directory / test["path"]
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_bytes(b"/*\nRules: E7-1-observation\n*/\nclass Input {}\n")
            test.update(expected="reject", rule_ids="E7-1-observation", source_sha256=sha(path))
        write_json(directory / "ledger-scope.json", {"schema_version": 1, "coverage_proof": "explicit inventory",
                   "clauses": {"07-basic-concepts": {"status": "available", "complete_clause_claim": False,
                                                    "expected_block_ids": ["10.1:p1"]}}})
        write_tsv(clause / "coverage.tsv", [dict(zip(COVERAGE_FIELDS, ["10.1:p1", "ecma-334-ed1", "10.1",
                  "E7-1-observation", "rules", ""]))], COVERAGE_FIELDS)
        for rows, filename in [(departures, "departures.tsv"), (observations, "superseded-observations.tsv")]:
            write_tsv(clause / filename, [{**row, "source_sha256": self.tests[0]["source_sha256"]} for row in rows], DEPARTURE_FIELDS)
        rule = {"ledger": "clauses/07-basic-concepts/rules.tsv", "kind": "forbids", "requirement": "An explicit requirement.",
                "source_id": "ecma-334-ed1", "locator": "10.1, p. 70 (PDF p. 84)", "quote_json": '"The older requirement applies."'}
        with patch("suite_audits.standard_root", return_value=directory), \
                patch("suite_engine.standard_root", return_value=directory), \
                patch("suite_audits.load_manifest", return_value=self.tests), \
                patch("suite_audits.read_rules", return_value={"E7-1-observation": rule}), \
                patch("suite_audits.suite_path", side_effect=lambda path, suite: directory / path):
            return ledger_audit("ecma-334", require_confirmed=True)

    def test_ledger_distinguishes_superseded_observations_from_live_departures(self):
        active = self.observation("first-kept", "1", "confirmed")
        old = [self.observation(name, level) for name, level in [("first-changed", "1"), ("third-changed", "2")]]
        audit = self.ledger([active], old)
        self.assertEqual(audit["errors"], [])
        self.assertEqual((audit["departures"], audit["superseded_observations"]), (1, 2))
        self.assertEqual(audit["departure_status"], {"confirmed": 1})
        details = audit["superseded_observation_levels"]
        self.assertEqual([(row["test_id"], row["level"], row["status"]) for row in details],
                         [("first-changed", "1", "conforming"), ("third-changed", "2", "conforming")])
        self.assertEqual(details[0]["superseded"], self.tables[2]["conflicts"][0]["superseded"])
        # The same source may have an active disagreement at another level.
        active = self.observation("first-changed", "2", "confirmed")
        self.assertEqual(self.ledger([active], old)["errors"], [])

    def test_ledger_refuses_active_departures_at_superseded_levels(self):
        for name, level in [("first-changed", "1"), ("third-changed", "2"),
                            ("first-changed", "ISO-1"), ("third-changed", "ISO-2")]:
            for status in ["confirmed", "pending"]:
                row = self.observation(name, level, status)
                errors = self.ledger([row])["errors"]
                with self.subTest(name=name, status=status):
                    self.assertIn(name + ": departure level " + level + " is superseded by the governing edition", errors)
        for name in ["first-kept", "first-changed"]:
            self.assertEqual(self.ledger([self.observation(name, "2", "confirmed")])["errors"], [])

    def test_split_departures_keep_both_governing_citations_and_one_witness_basis(self):
        first = self.observation("first-kept", "1", "confirmed")
        second = self.observation("first-kept", "2", "confirmed")
        audit = self.ledger([first, second])
        self.assertEqual(audit["errors"], [])
        self.assertEqual((audit["departures"], audit["departure_citations"]), (1, 2))
        directory = self.scratch / "observation-ledger"
        with patch("suite_engine.standard_root", return_value=directory):
            combined = departure_rows("ecma-334")["first-kept"]
        self.assertEqual(json.loads(combined["levels_json"]), ["1", "2"])
        self.assertEqual([row["source_id"] for row in combined["level_citations"]],
                         ["ecma-334-ed2", "ecma-334-ed4"])
        test = next(test for test in self.tests if test["test_id"] == "first-kept")
        test.update(version="7.3", expected="run", version_witness="")
        context, source = self.context("split-departure", test)
        context._departures = {"ecma-334": {"first-kept": combined}}
        for level in ["1", "2", "3"]:
            record = {"suite_id": "ecma-334", "test_id": "first-kept", "mode": "test",
                      "source_sha256": combined["source_sha256"], "level": level,
                      "status": "unexpected-reject", "departure": False, "departure_kind": ""}
            context.mark_departure(record)
            self.assertEqual(record["departure"], level in ["1", "2"])
        for row in [first, second, combined]:
            basis, positive, declared = witness_for(test, context, {"first-kept": row})
            self.assertEqual((basis, positive, declared), ("original", source.read_bytes(), ""))
        test["version_witness"] = "version-witnesses/shared.cs.part"
        witness = directory / "clauses/07-basic-concepts" / test["version_witness"]
        witness.parent.mkdir(parents=True, exist_ok=True)
        witness.write_bytes(b"class ValidConstruct {}\n")
        with patch("suite_measurements.standard_root", return_value=directory):
            for row in [first, second, combined]:
                self.assertEqual(witness_for(test, context, {"first-kept": row}),
                                 ("departure-witness", witness.read_bytes(), sha(witness)))

    def test_split_departures_refuse_overlap_and_disagreeing_observations(self):
        first = self.observation("first-kept", "1", "confirmed")
        second = self.observation("first-kept", "2", "confirmed")
        for changes, message in [({"levels_json": '["ISO-1"]'}, "Overlapping split departure levels"),
                                 ({"observation_json": '{"compile_exit":0}'}, "Inconsistent split departure"),
                                 ({"kind": "hosted-runtime"}, "Inconsistent split departure"),
                                 ({"status": "pending"}, "Inconsistent split departure")]:
            with self.subTest(changes=changes), self.assertRaisesRegex(ValueError, message):
                self.ledger([first, second | changes])

    def test_departures_require_governing_authority_and_check_every_split_quote(self):
        first = self.observation("first-kept", "1", "confirmed")
        second = self.observation("first-kept", "2", "confirmed")
        for level, row, wrong in [("1", first, "ecma-334-ed1"), ("2", second, "ecma-334-ed3")]:
            with self.subTest(level=level):
                errors = self.ledger([row | {"source_id": wrong}])["errors"]
                self.assertTrue(any("must cite governing edition" in error for error in errors))
        second["quote_json"] = json.dumps(" ".join(["word"] * 31))
        self.assertTrue(any("quote must be a nonempty short JSON string" in error
                            for error in self.ledger([first, second])["errors"]))
        second["quote_json"] = first["quote_json"]
        second["levels_json"] = "[]"
        self.assertTrue(any("missing or repeated observed levels" in error
                            for error in self.ledger([first, second])["errors"]))

    def test_departure_level_lists_reject_gaps(self):
        row = self.observation("first-kept", "3", "confirmed")
        row["source_id"] = "ecma-334-ed7"
        row["levels_json"] = json.dumps(["3", "7.3", "15"])
        errors = self.ledger([row])["errors"]
        self.assertTrue(any("observed levels contain a gap" in error for error in errors))
        row["levels_json"] = json.dumps(list(self.config["language"]["explicit"])[2:])
        self.assertEqual(self.ledger([row])["errors"], [])
        first = row | {"levels_json": '["3", "4"]'}
        second = row | {"levels_json": '["6"]'}
        errors = self.ledger([first, second])["errors"]
        self.assertTrue(any("observed levels contain a gap" in error for error in errors))

    def test_split_departures_check_the_second_quotation_at_its_source_page(self):
        from suite_audits import Sources
        first = self.observation("first-kept", "1", "confirmed")
        second = self.observation("first-kept", "2", "confirmed")
        sources = Sources(source_registry(), None)
        sources.texts = {self.editions[number]["id"]: edition_page_fixture("The older requirement applies.")
                         for number in [1, 2, 3, 4]}
        second["quote_json"] = '"The governing requirement applies."'
        with patch("suite_audits.Sources", return_value=sources):
            self.assertTrue(any("quotation is not exact at its pinned source locator" in error
                                for error in self.ledger([first, second])["errors"]))
            sources.texts["ecma-334-ed4"] = edition_page_fixture("The governing requirement applies.")
            self.assertEqual(self.ledger([first, second])["errors"], [])

    def test_departure_after_iso_levels_requires_the_latest_standard_edition(self):
        row = self.observation("first-kept", "3", "confirmed")
        row["source_id"] = "ecma-334-ed4"
        self.assertTrue(any("must cite governing edition ecma-334-ed7" in error
                            for error in self.ledger([row])["errors"]))
        row["source_id"] = "ecma-334-ed7"
        self.assertEqual(self.ledger([row])["errors"], [])

    def test_leave_out_authority_requires_a_real_clause_on_its_pinned_page(self):
        from suite_audits import Sources
        sources = Sources(source_registry(), None)
        sources.texts = {self.editions[number]["id"]: edition_page_fixture("The governing requirement applies.")
                         for number in [1, 2, 3, 4]}
        row = self.tables[2]["conflicts"][0]
        row.pop("superseded")
        self.tables[4]["conflicts"] = []
        prefix = self.editions[2]["authority_prefix"]
        with patch("suite_audits.Sources", return_value=sources):
            row["authority"] = prefix + " 10.99, p. 70 (PDF p. 84)"
            self.assertTrue(any("clause" in error for error in suite_editions.edition_audit(
                "ecma-334", self.tests, source_map="unused")["errors"]))
            row["authority"] = prefix + " 10.1, p. 70 (PDF p. 84)"
            self.assertEqual(suite_editions.edition_audit("ecma-334", self.tests, source_map="unused")["errors"], [])

    def test_superseded_observation_needs_own_authority_and_a_cited_table_marker(self):
        original = self.observation("first-changed", "1")
        for changes, message in [({"test_id": "first-kept"}, "needs a cited superseded claim"),
                                 ({"levels_json": '["2"]'}, "needs a cited superseded claim"),
                                 ({"source_id": "ecma-334-ed2"}, "must cite its own edition"),
                                 ({"conforms_since": "3"}, "without conforms_since"),
                                 ({"compiler_commit": "0" * 40}, "does not name the pinned authority")]:
            with self.subTest(changes=changes):
                self.assertTrue(any(message in error for error in self.ledger(observations=[original | changes])["errors"]))
        marker = self.tables[2]["conflicts"][0].pop("superseded")
        self.tables[2]["conflicts"][0]["action"] = "leave-out"
        self.assertTrue(any("needs a cited superseded claim" in error for error in self.ledger(observations=[original])["errors"]))
        self.tables[2]["conflicts"][0]["superseded"] = marker
        for status in ["confirmed", "pending"]:
            with self.subTest(status=status), self.assertRaisesRegex(ValueError, "Invalid observation kind/status"):
                self.ledger(observations=[original | {"status": status}])

    def test_superseded_observation_retains_measurement_witness_without_a_departure_mark(self):
        test = self.tests[0]
        context, source = self.context("old-observation", test)
        test["version_witness"] = "version-witnesses/old.cs.part"
        directory = self.scratch / "witness-standard"
        witness = directory / "clauses/07-basic-concepts" / test["version_witness"]
        witness.parent.mkdir(parents=True)
        witness.write_bytes(b"class ValidConstruct {}\n")
        row = self.observation(test["test_id"], "1")
        with patch("suite_measurements.standard_root", return_value=directory), \
                patch("suite_measurements.departure_rows", return_value={}), \
                patch("suite_measurements.superseded_observation_rows", return_value={test["test_id"]: row}):
            measurement = Measurement(context, [test], ["1"], {}, fresh=True)
            basis, positive, declared = witness_for(test, context, measurement.departures, measurement.superseded)
            calls = []
            def observe(current, resolution, mode, raw):
                calls.append(mode)
                self.assertEqual(raw, witness.read_bytes() if mode == "compile-only" else None)
                path = context.output / (mode + ".json")
                result = {"status": "pass" if mode == "compile-only" else "unexpected-reject", "reason": "",
                          "run_exit": "", "error_diagnostic_codes": "", "result_path": str(path)}
                write_json(path, result)
                return result
            context.run = observe
            measured = measurement.measure(test, "exhaustive")
        self.assertEqual((basis, positive, declared), ("departure-witness", witness.read_bytes(), sha(witness)))
        self.assertEqual(calls, ["test", "compile-only"])
        self.assertEqual(measured["row"]["basis"], "departure-witness")
        self.assertEqual(measured["row"]["observations"]["1"]["original_status"], "unexpected-reject")
        self.assertTrue(measured["row"]["observations"]["1"]["applicable"])
        self.assertEqual(measurement.departures, {})
        record = {"suite_id": "ecma-334", "test_id": test["test_id"], "mode": "test", "source_sha256": sha(source),
                  "level": "1", "status": "unexpected-reject", "departure": False, "departure_kind": ""}
        context.mark_departure(record)
        self.assertEqual((record["status"], record["departure"], record["departure_kind"]), ("unexpected-reject", False, ""))
        with self.assertRaisesRegex(ValueError, "declared positive construct witness"):
            witness_for(test | {"version_witness": ""}, context, {}, {test["test_id"]: row})

    def test_claim_and_cross_reference_use_the_governing_table_before_gating(self):
        for number, effective, changed in [(1, 2, "first-changed"), (2, 2, "first-changed"),
                                           (3, 4, "third-changed"), (4, 4, "third-changed")]:
            with self.subTest(edition=number):
                tests, plans, _, _, details = self.prepare(edition=number)
                detail = details["edition_selection"]["ecma-334"]
                self.assertEqual(detail["level_edition"], effective)
                self.assertTrue(detail["conflict_table"]["path"].endswith(str(effective) + ".json"))
                self.assertTrue(detail["source_conflict_table"]["path"].endswith(str(number) + ".json"))
                self.assertIn(changed, [test["test_id"] for test in tests])
                self.assertEqual(detail["superseded_test_ids"], [changed])
                self.assertEqual([mode for test, _, mode in plans if test["test_id"] == changed], ["superseded"])
                self.assertIn("test", [mode for test, _, mode in plans if test["test_id"].endswith("kept")])
                self.assertNotIn("version-gating", [mode for _, _, mode in plans])

    def test_explicit_iso_levels_gate_unlisted_newer_constructs(self):
        self.rows["latest"] = selection_bounds(self.config, "3")
        feature = {**self.tests[-1], "test_id": "feature", "authority": "csc 5.11 (C# 15.0)", "version": "15"}
        self.tests.append(feature)
        self.rows["feature"] = copy.deepcopy(self.rows["latest"])
        for selectors in [["ISO-1"], ["ISO-2"], ["1,2,3"], ["all"]]:
            with self.subTest(selectors=selectors):
                _, plans, _, _, details = self.prepare(language=selectors)
                for level in [level for level in ["1", "2"]
                              if any(resolution["level"] == level for _, resolution, _ in plans)]:
                    for name in ["latest", "feature"]:
                        gated = [(test, mode) for test, resolution, mode in plans
                                 if test["test_id"] == name and resolution["level"] == level]
                        self.assertEqual([mode for _, mode in gated], ["version-gating"])
                        self.assertIsNone(gated[0][0]["edition_membership"]["superseded"])
                        self.assertIn(name, details["language_edition_selection"]["ecma-334"][level]["version_gating_test_ids"])
                for test, resolution, mode in plans:
                    if resolution["level"] == "3" and test["test_id"] in {"latest", "feature"}:
                        self.assertEqual(mode, "test")
        # An unlisted older source can also need a below-Since refusal check.
        older = next(plan for plan in self.prepare(language=["1"])[1] if plan[0]["test_id"] == "third-kept")
        self.assertEqual(older[2], "version-gating")

    def test_supersession_at_either_iso_level_prevents_all_refusal_checks(self):
        for selectors in [["1"], ["2"], ["1,2,3"], ["all"]]:
            with self.subTest(selectors=selectors):
                _, plans, _, _, details = self.prepare(language=selectors)
                for test, level, mode in plans:
                    if test["test_id"] in {"first-changed", "third-changed"}:
                        self.assertNotEqual(mode, "version-gating")
                first_level = details["language_edition_selection"]["ecma-334"].get("1")
                if first_level:
                    self.assertNotIn("third-changed", first_level["version_gating_test_ids"])
                    self.assertIn("third-kept", first_level["version_gating_test_ids"])
                second_level = details["language_edition_selection"]["ecma-334"].get("2")
                if second_level:
                    self.assertIn("third-changed", second_level["superseded_test_ids"])
        # A narrow candidate list still needs the complete governing tables.
        with self.assertRaisesRegex(ValueError, "No tests selected for this run mode"):
            self.prepare(language=["1"], select="^third-changed$")
        self.assertEqual([mode for _, _, mode in self.prepare(edition=4, select="^third-changed$")[1]],
                         ["superseded"])

    def test_explicit_iso_dispositions_suppress_refusal_checks(self):
        self.rows["latest"] = selection_bounds(self.config, "3")
        originals = copy.deepcopy(self.tables)
        for number, level, replacement, changed in [(2, "1", "second-own", "first-changed"),
                                                     (4, "2", "fourth-own", "third-changed")]:
            for action in ["replace", "leave-out"]:
                self.tables = copy.deepcopy(originals)
                row = {"action": action, "test_id": "latest",
                       "authority": self.editions[number]["authority_prefix"] + " 10.1, p. 70 (PDF p. 84)"}
                if action == "replace":
                    row["replacement_test_id"] = replacement
                    self.rows[replacement] = selection_bounds(self.config, "3")
                self.tables[number]["conflicts"].append(row)
                with self.subTest(level=level, action=action):
                    _, plans, _, _, details = self.prepare(language=[level])
                    self.assertNotIn("latest", [test["test_id"] for test, _, _ in plans])
                    decision = details["language_edition_selection"]["ecma-334"][level]
                    self.assertNotIn("latest", decision["version_gating_test_ids"])
                    self.assertEqual([mode for test, _, mode in plans if test["test_id"] == changed], ["superseded"])
                    if action == "replace":
                        self.assertEqual([mode for test, _, mode in plans if test["test_id"] == replacement], ["test"])

    def test_iso_refusal_checks_require_refusal_and_preserve_claim_and_header_plans(self):
        for level in ["1", "2"]:
            for behavior, disconnected, expected in [("refuses", [], ["version-gating"]),
                                                      ("meaning-change", [], []),
                                                      ("refuses", [level], [])]:
                self.rows["latest"] = selection_bounds(self.config, "3", behavior=behavior, other=disconnected)
                with self.subTest(level=level, behavior=behavior, disconnected=disconnected):
                    plans = self.prepare(language=[level])[1]
                    self.assertEqual([mode for test, _, mode in plans if test["test_id"] == "latest"], expected)
            self.rows["latest"] = selection_bounds(self.config, "1", until="1")
            expected = ["test"] if level == "1" else []
            self.assertEqual([mode for test, _, mode in self.prepare(language=[level])[1]
                              if test["test_id"] == "latest"], expected)
        self.rows["latest"] = selection_bounds(self.config, "3")
        for number in [1, 2, 3, 4]:
            plans = self.prepare(edition=number)[1]
            self.assertNotIn("latest", [test["test_id"] for test, _, _ in plans])
            self.assertNotIn("version-gating", [mode for _, _, mode in plans])
        for selector in ["declared-per-test", "earliest-per-test"]:
            self.assertEqual([mode for test, _, mode in self.prepare(language=[selector])[1]
                              if test["test_id"] == "latest"], ["test"])

    def test_iso_refusal_plan_dispatches_its_positive_construct(self):
        self.rows["latest"] = selection_bounds(self.config, "3")
        positive = b"class Available<T> {}\n"
        for level in ["1", "2"]:
            output = self.scratch / ("iso-refusal-" + level)
            calls = []
            def compile_test(test, resolution, mode, raw, skip_status):
                calls.append((test["test_id"], resolution["level"], mode, raw, skip_status))
                return {**test, "level": resolution["level"], "mode": mode, "status": "pass", "departure": False}
            context = SimpleNamespace(output=output, provenance=lambda: {}, compile=compile_test,
                                      run_batch=lambda prepared, jobs: prepared)
            argv = ["run-suite.py", "--compiler", "unused.json", "--results", str(output),
                    "--langversion", level, "--select", "^latest$", "--suite", "ecma-334"]
            with patch.object(sys, "argv", argv), patch.object(self.runner, "load_config", return_value=(self.config, {}, {})), \
                    patch.object(self.runner, "load_manifest", return_value=self.tests), \
                    patch.object(self.runner, "Context", return_value=context), \
                    patch.object(self.runner, "gating_source", return_value=positive) as witness, \
                    patch.object(self.runner, "run_controls", return_value={"valid": True, "errors": []}), \
                    patch("sys.stdout", new=io.StringIO()):
                self.assertEqual(self.runner.main(), 0)
            self.assertEqual(calls, [("latest", level, "version-gating", positive, None)])
            self.assertTrue(witness.called)
            self.assertEqual({call.args[0]["test_id"] for call in witness.call_args_list}, {"latest"})
            run = json.loads((output / "run.json").read_bytes())
            self.assertEqual(run["language_edition_selection"]["ecma-334"][level]["version_gating_test_ids"], ["latest"])

    def test_mixed_language_plans_share_iso_decisions_and_keep_other_level_policy(self):
        for selectors in [["ISO-1"], ["ISO-2"], ["1,2,7.3"], ["all"], ["earliest-per-test"], ["declared-per-test"]]:
            with self.subTest(selectors=selectors):
                _, plans, _, _, details = self.prepare(language=selectors)
                for test, level, mode in plans:
                    if level["level"] in {"1", "2"}:
                        expected = "first-changed" if level["level"] == "1" else "third-changed"
                        if test["test_id"] == expected:
                            self.assertEqual(mode, "superseded")
                        self.assertIn("edition_membership", test)
                    elif selectors != ["declared-per-test"]:
                        self.assertEqual(test["test_id"], "latest")
                self.assertTrue(details["language_edition_selection"])
        self.assertEqual([test["test_id"] for test in self.prepare(language=["7.3"])[0]], ["latest"])

    def test_source_table_cannot_override_the_governing_table(self):
        for number, name in [(1, "second-own"), (3, "fourth-own")]:
            self.tables[number]["conflicts"].append({"action": "leave-out", "test_id": name,
                                                    "authority": self.editions[number]["authority_prefix"]
                                                    + " 10.1, p. 70 (PDF p. 84)"})
            with self.subTest(edition=number):
                tests, _, _, _, details = self.prepare(edition=number)
                self.assertIn(name, [test["test_id"] for test in tests])
                detail = details["edition_selection"]["ecma-334"]
                self.assertNotEqual(detail["source_conflict_table"]["sha256"], detail["conflict_table"]["sha256"])

    def test_header_level_aliases_keep_their_execution_resolution(self):
        self.tests[1]["version"] = "1"
        plans = self.prepare(language=["declared-per-test"])[1]
        test, level, mode = next(plan for plan in plans if plan[0]["test_id"] == "first-kept")
        self.assertEqual(level, resolve_level(self.config, test["version"]))
        self.assertEqual(mode, "test")

    def test_superseded_schema_refuses_uncited_nonolder_conflicting_and_duplicate_rows(self):
        original = self.tables[2]
        mutations = [lambda row: row.update(action="replace", replacement_test_id="first-kept"),
                     lambda row: row.update(superseded={}), lambda row: row["superseded"].update(test=[]),
                     lambda row: row["superseded"].update(level=[]),
                     lambda row: row["superseded"]["test"][0].update(source_id="ecma-334-ed3"),
                     lambda row: row["superseded"]["test"][0].update(clause="10.2"),
                     lambda row: row["superseded"]["level"][0].update(source_id="ecma-334-ed4"),
                     lambda row: row["superseded"]["level"][0].update(clause="10.2"),
                     lambda row: row["superseded"]["level"][0].update(pdf_pages=[85]),
                     lambda row: row.update(authority="ECMA-334 2nd ed 10.1, p. 0 (PDF p. 84)"),
                     lambda row: row["superseded"]["level"][0].update(quote=" "),
                     lambda row: row["superseded"]["test"][0].update(printed_pages=[True]),
                     lambda row: row["superseded"]["test"][0].update(pdf_pages=[0]),
                     lambda row: row["superseded"]["test"][0].update(pdf_pages=[84, 84]),
                     lambda row: row["superseded"]["test"][0].update(pdf_pages=[84, 85]),
                     lambda row: row["superseded"]["test"].append(copy.deepcopy(row["superseded"]["test"][0])),
                     lambda row: row.update(test_id="second-own"), lambda row: row.update(test_id="third-kept")]
        for index, mutation in enumerate(mutations):
            table = copy.deepcopy(original)
            mutation(table["conflicts"][0])
            with self.subTest(mutation=index), self.assertRaises(ValueError):
                validate_conflicts(table, "ecma-334", self.tests)
        compiler = {**self.tests[0], "test_id": "compiler", "authority": "csc pinned (C# 8)"}
        for name in ["compiler", "latest"]:
            table = copy.deepcopy(original)
            table["conflicts"][0]["test_id"] = name
            with self.subTest(authority=name), self.assertRaises(ValueError):
                validate_conflicts(table, "ecma-334", [*self.tests, compiler])
        for first in [False, True]:
            for action in ["replace", "leave-out", "duplicate", "replacement-value"]:
                table = copy.deepcopy(original)
                other = copy.deepcopy(table["conflicts"][0])
                if action != "duplicate":
                    other.pop("superseded")
                if action in {"replace", "replacement-value"}:
                    other.update(action="replace", replacement_test_id="first-kept")
                if action == "replacement-value":
                    other.update(test_id="latest", replacement_test_id="first-changed")
                table["conflicts"].insert(0 if first else 1, other)
                with self.subTest(action=action, first=first), self.assertRaises(ValueError):
                    validate_conflicts(table, "ecma-334", self.tests)

    def test_superseded_evidence_skips_execution_and_rejects_changed_resume_inputs(self):
        test, level, mode = next(plan for plan in self.prepare(edition=1)[1] if plan[2] == "superseded")
        context, source = self.context("superseded-evidence", test)
        record = context.superseded(test, level)
        self.assertEqual((record["status"], record["mode"], record["departure"]), ("superseded", mode, False))
        self.assertEqual(record["executed_source_sha256"], "")
        self.assertEqual(record["stages"], [])
        self.assertEqual(record["compile_command_json"], "[]")
        self.assertEqual(record["run_command_json"], "[]")
        verify_record(context, test, record, level, mode)
        with self.assertRaisesRegex(ValueError, "cannot execute"):
            context.compile(test, level)
        with self.assertRaisesRegex(ValueError, "cannot be replayed"):
            verify_record(context, test, record, level)
        self.assertIsNotNone(context.saved(test, level, mode))
        for field in ["conflict_table", "superseded"]:
            changed = copy.deepcopy(test)
            if field == "conflict_table":
                changed["edition_membership"][field]["sha256"] = "0" * 64
            else:
                changed["edition_membership"][field]["level"][0]["quote"] += " Different text."
            self.assertIsNone(context.saved(changed, level, mode, completed=True))
        stale = {**test, "fixture_sha256": "0" * 64}
        with self.assertRaisesRegex(ValueError, "Fixture changed"):
            context.superseded(stale, level)
        source.write_bytes(b"class Changed {}\n")
        self.assertIsNone(context.saved(test, level, mode, completed=True))
        with self.assertRaisesRegex(ValueError, "Source changed"):
            context.superseded(test, level)
        context.preflight.assert_not_called()
        context.execute.assert_not_called()
        context.target.run_batch.assert_not_called()

    def test_governing_table_keeps_cited_older_replacements_outside_their_interval(self):
        self.tables[4]["conflicts"].append({"action": "replace", "test_id": "latest",
                                           "replacement_test_id": "first-kept",
                                           "authority": "ECMA-334 4th ed 10.1, p. 70 (PDF p. 84)"})
        self.rows["first-kept"] = selection_bounds(self.config, "3")
        original = copy.deepcopy(self.rows)
        for number in [3, 4]:
            with self.subTest(edition=number):
                _, plans, _, _, details = self.prepare(edition=number)
                self.assertEqual([mode for test, _, mode in plans if test["test_id"] == "first-kept"], ["test"])
                self.assertIn("first-kept", details["edition_selection"]["ecma-334"]["replacement_test_ids"])
                self.assertNotIn("latest", [test["test_id"] for test, _, _ in plans])
        self.assertEqual(self.rows, original)

    def test_earliest_replacement_runs_at_its_own_and_the_governing_level(self):
        self.tables[4]["conflicts"].append({"action": "replace", "test_id": "latest",
                                           "replacement_test_id": "first-kept",
                                           "authority": "ECMA-334 4th ed 10.1, p. 70 (PDF p. 84)"})
        self.rows["first-kept"]["until"] = "1"
        original = copy.deepcopy(self.rows)
        tests, plans, _, _, details = self.prepare(language=["earliest-per-test"], select="^(latest|first-kept)$")
        self.assertEqual([test["test_id"] for test in tests], ["first-kept"])
        self.assertEqual([(test["test_id"], level["level"], mode) for test, level, mode in plans],
                         [("first-kept", "1", "test"), ("first-kept", "2", "test")])
        decision = details["language_edition_selection"]["ecma-334"]["2"]
        self.assertEqual(decision["replacement_test_ids"], ["first-kept"])
        self.assertEqual(decision["replaced_test_ids"], ["latest"])
        self.assertEqual(self.rows, original)

    def test_earliest_replacement_requires_both_sources_in_the_candidate_selection(self):
        self.tables[4]["conflicts"].append({"action": "replace", "test_id": "latest",
                                           "replacement_test_id": "first-kept",
                                           "authority": "ECMA-334 4th ed 10.1, p. 70 (PDF p. 84)"})
        self.rows["first-kept"]["until"] = "1"
        with self.assertRaisesRegex(ValueError, "Replacement is not selected"):
            self.prepare(language=["earliest-per-test"], select="^latest$")
        _, plans, _, _, _ = self.prepare(language=["earliest-per-test"], select="^first-kept$")
        self.assertEqual([(test["test_id"], level["level"], mode) for test, level, mode in plans],
                         [("first-kept", "1", "test")])

    def test_earliest_shared_replacement_has_one_plan_per_level(self):
        second = {**self.tests[-1], "test_id": "latest-two"}
        self.tests.append(second)
        self.rows["latest-two"] = copy.deepcopy(self.rows["latest"])
        self.rows["first-kept"]["until"] = "1"
        for name in ["latest", "latest-two"]:
            self.tables[4]["conflicts"].append({"action": "replace", "test_id": name,
                                               "replacement_test_id": "first-kept",
                                               "authority": "ECMA-334 4th ed 10.1, p. 70 (PDF p. 84)"})
        for selectors in [["earliest-per-test"], ["1,2"]]:
            with self.subTest(selectors=selectors):
                _, plans, _, _, _ = self.prepare(language=selectors, select="^(latest|latest-two|first-kept)$")
                expected = [("first-kept", "1", "test"), ("first-kept", "2", "test")]
                if selectors == ["1,2"]:
                    expected.extend((name, "1", "version-gating") for name in ["latest", "latest-two"])
                self.assertEqual(sorted((test["test_id"], level["level"], mode) for test, level, mode in plans),
                                 sorted(expected))

    def test_unchanged_older_test_executes_and_counts_beside_superseded(self):
        changed = self.tests[0]
        context, _ = self.context("changed-and-kept", changed)
        context.provenance = lambda: {}
        def compile_test(test, level, mode, raw, skip):
            self.assertEqual((test["test_id"], mode), ("first-kept", "test"))
            return {**test, "level": level["level"], "mode": mode, "status": "pass", "departure": False}
        context.compile = Mock(side_effect=compile_test)
        context.run_batch = Mock(side_effect=lambda records, jobs: records)
        argv = ["run-suite.py", "--compiler", "unused.json", "--results", str(context.output),
                "--edition", "2", "--select", "^first-", "--suite", "ecma-334"]
        with patch.object(sys, "argv", argv), patch.object(self.runner, "load_config", return_value=(self.config, {}, {})), \
                patch.object(self.runner, "load_manifest", return_value=self.tests), \
                patch.object(self.runner, "Context", return_value=context), \
                patch.object(self.runner, "run_controls", return_value={"valid": True, "errors": []}), \
                patch.object(self.runner, "gating_source", side_effect=AssertionError("No superseded gating")), \
                patch("sys.stdout", new=io.StringIO()):
            self.assertEqual(self.runner.main(), 0)
        summary = json.loads((context.output / "summary.json").read_bytes())
        run = json.loads((context.output / "run.json").read_bytes())
        self.assertEqual((run["passes"], run["superseded"], run["new_executions"]), (1, 1, 1))
        self.assertEqual(summary["groups"][0]["applicable"], 1)
        context.compile.assert_called_once()
        context.run_batch.assert_called_once()

    def test_full_citation_audit_requires_exact_text_on_the_cited_pinned_page(self):
        from suite_audits import Sources
        sources = Sources(source_registry(), None)
        quote = " ".join(["required"] * 30) + "."
        longer = "extra " + quote
        sources.texts = {"ecma-334-ed1": edition_page_fixture(longer) + "\fDifferent rule."}
        citation = {**self.tables[2]["conflicts"][0]["superseded"]["test"][0], "quote": quote}
        errors = []
        sources.citation(citation, errors, "test")
        self.assertEqual(errors, [])
        for changes in [{"quote": "Different rule."}, {"pdf_pages": [85]}, {"pdf_pages": [86]},
                        {"source_id": "ecma-334-ed2"}, {"quote": longer}, {"quote": " \n "},
                        {"quote": None}, {"quote": [quote]}]:
            errors = []
            sources.citation(citation | changes, errors, "test")
            self.assertEqual(len(errors), 1)

    def test_quotation_comparison_only_normalizes_whitespace_and_punctuation_spacing(self):
        from suite_audits import normalized
        self.assertEqual(normalized("value \n ( T [ ] ) , result ."), normalized("value(T[]),result."))
        for printed, changed in [("value 12", "value 21"), ("source 41 operand", "source operand"),
                                 ("value-type", "valuetype"), ("a value", "avalue"),
                                 ("10^28", "1028"), ("allowed", "forbidden")]:
            with self.subTest(printed=printed, changed=changed):
                self.assertNotEqual(normalized(printed), normalized(changed))

    def test_mutation_check_records_superseded_without_an_original_or_mutant_execution(self):
        spec = importlib.util.spec_from_file_location("mutation_check_subject", ROOT / "runner/tools/check-mutations.py")
        mutation = importlib.util.module_from_spec(spec)
        spec.loader.exec_module(mutation)
        test = self.tests[0]
        context, _ = self.context("superseded-mutation", test)
        context.provenance = lambda: {}
        context.run = Mock(side_effect=AssertionError("No superseded original or mutant"))
        argv = ["check-mutations.py", "--compiler", "unused.json", "--results", str(context.output),
                "--select", "^first-changed$", "--suite", "ecma-334"]
        with patch.object(sys, "argv", argv), patch.object(mutation, "load_config", return_value=(self.config, {}, {})), \
                patch.object(mutation, "load_manifest", return_value=self.tests), \
                patch.object(mutation, "Context", return_value=context), \
                patch.object(mutation, "run_controls", return_value={"valid": True, "errors": []}), \
                patch.object(mutation, "mutated_source", side_effect=AssertionError("No superseded mutation")), \
                patch("sys.stdout", new=io.StringIO()):
            self.assertEqual(mutation.main(), 0)
        summary = json.loads((context.output / "summary.json").read_bytes())
        self.assertTrue(summary["complete"])
        self.assertEqual(summary["status_counts"], {"superseded": 1})
        self.assertEqual(summary["rows"][0]["mutant_status"], "")
        self.assertEqual(json.loads(summary["rows"][0]["edition_membership_json"])["superseded"],
                         self.tables[2]["conflicts"][0]["superseded"])
        context.run.assert_not_called()

    def test_header_audit_replays_superseded_as_a_cited_nonfailure(self):
        from suite_audits import csc_audit
        test = self.tests[0]
        test["csc_codes"] = "CS9000"
        context, _ = self.context("superseded-header", test)
        context.provenance = lambda: {"identity_sha256": context.identity_sha256}
        argv = ["run-suite.py", "--compiler", "unused.json", "--results", str(context.output),
                "--langversion", "declared-per-test", "--select", "^first-changed$", "--suite", "ecma-334"]
        with patch.object(sys, "argv", argv), patch.object(self.runner, "load_config", return_value=(self.config, {}, {})), \
                patch.object(self.runner, "load_manifest", return_value=self.tests), \
                patch.object(self.runner, "Context", return_value=context), \
                patch.object(self.runner, "run_controls", return_value={"valid": True, "errors": [], "rows": []}), \
                patch("sys.stdout", new=io.StringIO()):
            self.assertEqual(self.runner.main(), 0)
        with patch.object(Context, "from_evidence", return_value=context), \
                patch("suite_measurements.ObservationRegistry") as registry, \
                patch("suite_audits.load_manifest", return_value=self.tests), patch("suite_audits.load_controls", return_value=[]):
            registry.return_value.header.return_value = context
            audit = csc_audit(["ecma-334"], Path("unused.json"), Path("unused.json"), context.output, "^first-changed$")
        self.assertEqual(audit["errors"], [])
        self.assertEqual(audit["status_counts"], {"superseded": 1})
        self.assertEqual(audit["csc_headers_checked"], 0)

    def test_static_rows_both_summaries_exit_status_and_failed_controls(self):
        for number, changed in [(1, "first-changed"), (2, "first-changed"), (3, "third-changed"), (4, "third-changed")]:
            for valid in [False, True]:
                test = next(test for test in self.tests if test["test_id"] == changed)
                context, _ = self.context("static-run-" + str(number) + "-" + str(valid), test)
                context.provenance = lambda: {}
                context.compile = Mock(side_effect=AssertionError("Superseded must not compile"))
                context.run_batch = Mock(side_effect=AssertionError("Superseded must not enter a runtime batch"))
                argv = ["run-suite.py", "--compiler", "unused.json", "--results", str(context.output),
                        "--edition", str(number), "--select", "^" + changed + "$", "--suite", "ecma-334"]
                with self.subTest(edition=number, controls=valid), patch.object(sys, "argv", argv), \
                        patch.object(self.runner, "load_config", return_value=(self.config, {}, {})), \
                        patch.object(self.runner, "load_manifest", return_value=self.tests), \
                        patch.object(self.runner, "Context", return_value=context), \
                        patch.object(self.runner, "run_controls", return_value={"valid": valid, "errors": []}) as controls, \
                        patch("sys.stdout", new=io.StringIO()):
                    self.assertEqual(self.runner.main(), 0 if valid else 3)
                controls.assert_called_once_with(context, 1)
                run = json.loads((context.output / "run.json").read_bytes())
                summary = json.loads((context.output / "summary.json").read_bytes())
                self.assertEqual(run["new_executions"], 0)
                self.assertEqual(run["void"], not valid)
                self.assertEqual(run["superseded"], int(valid))
                if valid:
                    self.assertEqual(summary["groups"][0]["applicable"], 0)
                    for data in [run, summary]:
                        self.assertEqual(data["status_counts"].get("superseded"), 1)
                        self.assertFalse(data["status_counts"].get("pass"))
                        self.assertEqual(data["superseded_tests"][0]["superseded"], self.tables[2 if number < 3 else 4]["conflicts"][0]["superseded"])
                    markdown = (context.output / "summary.md").read_text()
                    self.assertIn("The older requirement applies.", markdown)
                    self.assertIn("The changed requirement applies.", markdown)
                    self.assertIn("printed pp. 70 (PDF pp. 84)", markdown)
                context.compile.assert_not_called()
                context.run_batch.assert_not_called()


class PublishingChecks(unittest.TestCase):
    def setUp(self):
        spec = importlib.util.spec_from_file_location("publishing_check_subject", ROOT / "runner/tools/check-publishing.py")
        self.publishing = importlib.util.module_from_spec(spec)
        spec.loader.exec_module(self.publishing)

    def test_absolute_paths_are_refused_and_portable_references_are_allowed(self):
        directory = self.scratch / "portable-public-text"
        documents = ["README.md", "LICENSE-MIT", "LICENSE-APACHE", "NOTICE", ".gitattributes",
                     "docs/ARCHITECTURE.md", "docs/CONVENTIONS.md", "docs/CONTRIBUTING.md", "docs/RESULTS.md"]
        for relative in documents:
            path = directory / relative
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_bytes((ROOT / relative).read_bytes())
        subject = directory / "paths.txt"
        absolute = [
            "Q" + ":" + "/work/file.cs", "Q" + ":" + "\\work\\file.cs",
            *["/" + name + "/work/file.cs" for name in
              ["home", "Users", "tmp", "usr", "opt", "mnt", "private", "root", "Volumes"]],
            "\\" * 2 + "wsl" + "$" + "\\Example\\work\\file.cs",
            "\\" * 2 + "WSL" + "$" + "\\Example\\work\\file.cs",
            "\\" * 2 + "wsl.localhost" + "\\Example\\work\\file.cs",
            "\\" * 2 + "wsl.localhost" + "/Example/work/file.cs",
        ]
        portable = ["../sources/source-map.json", "ecma-334/clauses/example.cs", "root/work/file.cs",
                    "Volumes/work/file.cs", "https://example.org/root/file.cs",
                    "https://example.org/Volumes/file.cs", "wsl$", "wsl.localhost", "value: item"]
        with patch.object(self.publishing, "ROOT", directory), \
                patch.object(self.publishing, "raw_sources", return_value=set()):
            for value in absolute + portable:
                with self.subTest(value=value):
                    subject.write_bytes((value + "\n").encode("ascii"))
                    errors = self.publishing.text_audit(["ecma-334"])["errors"]
                    self.assertEqual(errors, ["paths.txt: absolute machine path"] if value in absolute else [])

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


    def test_external_policy_rejects_names_inside_identifiers(self):
        directory = self.scratch / "neutral-standard-text"
        documents = ["README.md", "LICENSE-MIT", "LICENSE-APACHE", "NOTICE", ".gitattributes",
                     "docs/ARCHITECTURE.md", "docs/CONVENTIONS.md", "docs/CONTRIBUTING.md", "docs/RESULTS.md"]
        for relative in documents:
            path = directory / relative
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_bytes((ROOT / relative).read_bytes())
        raw_relative = "clauses/06-lexical-structure/tests/raw.cs"
        policy = self.scratch / "identifier-policy.txt"
        policy.write_bytes(b"testbrand|testcc|TEST0001\n")
        patterns = self.publishing.forbidden_patterns(policy)
        examples = {
            "ecma-334/clauses/22-attributes/tests/example.cs": b"#define EmitTeStBrAnDCalls\n",
            "ecma-334/" + raw_relative: b"\xffprefixTESTCC_suffix\r\n",
            "ecma-334/source-registry.json": b'{"code":"prefixTEST0001suffix"}\n',
            "configs/compiler.txt": b"testbrand testcc TEST0001\n",
            "ecma-334/neutral.cs": b"#define CALLS\n",
        }
        for relative, data in examples.items():
            path = directory / relative
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_bytes(data)
        with patch.object(self.publishing, "ROOT", directory), \
                patch.object(self.publishing, "raw_sources", return_value={raw_relative}):
            self.assertEqual(self.publishing.text_audit(["ecma-334"])["errors"], [])
            result = self.publishing.text_audit(["ecma-334"], patterns)
        expected = {relative + ": extra forbidden text (pattern line 1)" for relative in examples
                    if relative != "ecma-334/neutral.cs"}
        self.assertEqual(set(result["errors"]), expected)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--report", type=Path, required=True)
    args = parser.parse_args()
    args.report.parent.mkdir(parents=True, exist_ok=True)
    with tempfile.TemporaryDirectory(prefix="runner-check-", dir=args.report.parent.resolve()) as scratch:
        RunnerChecks.scratch = Path(scratch)
        EditionChecks.scratch = Path(scratch)
        SupersededChecks.scratch = Path(scratch)
        PublishingChecks.scratch = Path(scratch)
        output = io.StringIO()
        checks = unittest.TestSuite(unittest.defaultTestLoader.loadTestsFromTestCase(case)
                                   for case in [RunnerChecks, EditionChecks, SupersededChecks, PublishingChecks,
                                                SourceLocatorChecks])
        result = unittest.TextTestRunner(stream=output, verbosity=2).run(checks)
    errors = [detail for _, detail in [*result.errors, *result.failures]]
    emit_audit(args.report, {"checks": result.testsRun, "errors": errors, "valid": result.wasSuccessful(),
                             "details": output.getvalue()})
    return 0 if result.wasSuccessful() else 1


if __name__ == "__main__":
    sys.exit(main())
