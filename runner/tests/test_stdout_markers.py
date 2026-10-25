"""Counted output keeps exact intermediate markers observable after termination."""
import sys
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1] / "tools"))
from suite_common import expected_stdout


class StdoutMarkerTests(unittest.TestCase):
    def test_existing_counted_output(self):
        self.assertEqual(expected_stdout("OK 0"), "OK 0\n")

    def test_markers_and_count_are_exact(self):
        self.assertEqual(expected_stdout('"ANCESTOR\\nOK 2"'), "ANCESTOR\nOK 2\n")
        self.assertEqual(expected_stdout('"FIRST\\nSECOND_2\\nOK 3"'),
                         "FIRST\nSECOND_2\nOK 3\n")

    def test_invalid_or_incomplete_output(self):
        for value in ["", "BASE", "OK 02", '"BASE\\n"', '"BASE\\nOK 2\\n"',
                      '"BASE\\n\\nOK 2"', '"FAIL base\\nOK 2"',
                      '"FAIL BASE\\nOK 2"', '"lowercase\\nOK 2"', '"unterminated']:
            with self.subTest(value=value), self.assertRaises(ValueError):
                expected_stdout(value)


if __name__ == "__main__":
    unittest.main()
