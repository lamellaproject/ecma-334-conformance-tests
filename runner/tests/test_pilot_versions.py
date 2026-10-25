"""Pilot selection must preserve full-run sampling and source-binding gates."""
import contextlib
import io
import json
from pathlib import Path
import sys
import tempfile
import unittest
from unittest.mock import patch

sys.path.insert(0, str(Path(__file__).resolve().parents[1] / "tools"))
import suite_version_schedule as schedule
import suite_versions as versions


class ReachedCompilerContext(Exception):
    pass


class PilotPolicyTests(unittest.TestCase):
    def test_small_pilots_sample_every_selected_test(self):
        inventory = [{"test_id": "new-ed1-" + str(i), "fixture_json": "{}"} for i in range(144)]
        for selection, sample, accepted in [
            (".*-ed1-", 144, True), (".*-ed1-", 143, False),
            (".*-ed1-", 200, False), (None, 144, False),
            ("no-match", 1, False), ("new-ed1-0$", 1, True),
        ]:
            with self.subTest(selection=selection, sample=sample):
                argv = ["compute-versions.py", "--results", "unused", "--sample", str(sample)]
                if selection is not None:
                    argv += ["--select", selection]
                with patch.object(sys, "argv", argv), patch.object(schedule, "load_manifest", return_value=inventory), \
                        patch.object(schedule, "Context", side_effect=ReachedCompilerContext) as compiler, \
                        contextlib.redirect_stderr(io.StringIO()):
                    with self.assertRaises(ReachedCompilerContext if accepted else SystemExit) as raised:
                        schedule.main()
                    if accepted:
                        compiler.assert_called_once()
                    else:
                        self.assertEqual(raised.exception.code, 2)
                        compiler.assert_not_called()


class PilotBindingTests(unittest.TestCase):
    def setUp(self):
        self.directory = tempfile.TemporaryDirectory(prefix="pilot-versions-")
        self.path = Path(self.directory.name) / "pilot.json"
        self.path.write_text("{}", encoding="ascii")
        self.test = {"suite_id": "ecma-334", "source_sha256": "a" * 64, "test_id": "test-ed1-case"}
        self.row = {"since": "1", "until": "7"}
        self.metadata = {"rows": {"a" * 64: {"test-ed1-case": self.row}}, "levels": ["1", "7"],
                         "sample": {"complete": True, "independent": True, "mismatches": [],
                                    "tests": 1, "test_ids": ["test-ed1-case"], "levels": ["1", "7"]}}
        self.previous = dict(versions._PILOT_VERSIONS)

    def tearDown(self):
        versions._PILOT_VERSIONS.clear()
        versions._PILOT_VERSIONS.update(self.previous)
        versions.version_file.cache_clear()
        self.directory.cleanup()

    def use(self, *, current=True, row_status="current"):
        with patch.object(versions, "validate_metadata", return_value=self.metadata), \
                patch.object(versions, "identity_current", return_value=current), \
                patch.object(versions, "version_row", return_value=(self.row, row_status)):
            return versions.use_pilot_versions(self.path, [self.test])

    def test_valid_pilot_changes_only_the_in_memory_selection(self):
        original = dict(self.test)
        before = self.path.read_bytes()
        selected = self.use()
        self.assertEqual(selected[0]["version_status"], "current")
        self.assertEqual(selected[0]["since"], "1")
        self.assertEqual(selected[0]["until"], "7")
        self.assertEqual(self.test, original)
        self.assertEqual(self.path.read_bytes(), before)

    def test_stale_tool_identity_is_rejected(self):
        with self.assertRaisesRegex(ValueError, "identity is stale"):
            self.use(current=False)

    def test_another_source_inventory_is_rejected(self):
        self.metadata["rows"] = {"b" * 64: {"test-ed1-case": self.row}}
        with self.assertRaisesRegex(ValueError, "source inventory"):
            self.use()

    def test_incomplete_or_reused_sample_is_rejected(self):
        for field, value in [("complete", False), ("independent", False), ("mismatches", ["different"]),
                             ("tests", 0), ("test_ids", ["another-test"]), ("levels", ["1"])]:
            with self.subTest(field=field):
                original = self.metadata["sample"][field]
                self.metadata["sample"][field] = value
                with self.assertRaisesRegex(ValueError, "independent all-level sample"):
                    self.use()
                self.metadata["sample"][field] = original

    def test_stale_fixture_or_witness_binding_restores_prior_metadata(self):
        original = {"earlier": True}
        versions._PILOT_VERSIONS["ecma-334"] = original
        with self.assertRaisesRegex(ValueError, "Pilot bounds are stale"):
            self.use(row_status="stale")
        self.assertIs(versions._PILOT_VERSIONS["ecma-334"], original)


if __name__ == "__main__":
    unittest.main()
