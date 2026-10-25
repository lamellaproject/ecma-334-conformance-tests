"""A warning-absence assertion must preserve behavioral mutation checking."""
import importlib.util
from pathlib import Path
import sys
import unittest

TOOLS = Path(__file__).resolve().parents[1] / "tools"
sys.path.insert(0, str(TOOLS))
spec = importlib.util.spec_from_file_location("mutation_checks", TOOLS / "check-mutations.py")
checks = importlib.util.module_from_spec(spec)
spec.loader.exec_module(checks)


def record(status="pass", *, warning=False, reason=""):
    return dict(status=status, compile_exit=0, reason=reason,
                diagnostics=[dict(stage="program", severity="warning")] if warning else [])


class DiagnosticMutationTests(unittest.TestCase):
    def test_absence_assertion_retains_runtime_check_failures(self):
        test = dict(diagnostic="none", expected="run")
        actual = checks.classify(test, record(), record("runtime-fail", reason="named-check"), False)
        self.assertEqual(actual, ("killed", "runtime-fail:named-check"))

    def test_added_warning_kills_a_warning_absence_test(self):
        test = dict(diagnostic="none", expected="run")
        actual = checks.classify(test, record(), record("diagnostic-fail", warning=True, reason="unexpected-warning"), False)
        self.assertEqual(actual[0], "killed")

    def test_positive_warning_cause_still_requires_a_valid_program(self):
        test = dict(diagnostic="warning", expected="run")
        actual = checks.classify(test, record(warning=True), record("runtime-fail", reason="unrelated"), False)
        self.assertEqual(actual[0], "survived")

    def test_positive_warning_toggle_is_detected(self):
        test = dict(diagnostic="warning", expected="run")
        self.assertEqual(checks.classify(test, record(warning=True), record(), False),
                         ("killed", "warning-cause-changed"))

    def test_declared_departure_does_not_claim_sensitivity(self):
        test = dict(diagnostic="none", expected="run")
        self.assertEqual(checks.classify(test, record(), record("runtime-fail"), True)[0],
                         "inconclusive-departure")


if __name__ == "__main__":
    unittest.main()
