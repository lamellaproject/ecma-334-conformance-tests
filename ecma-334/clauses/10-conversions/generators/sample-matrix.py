"""Small numeric matrix. Every program's cases share types and conversion context."""
import argparse
import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import SUITE, writable, write_text, write_tsv

GENERATOR = "clauses/10-conversions/generators/sample-matrix.py"
CLAUSE = "10-conversions"


def generate(root):
    root = writable(root)
    cells = []
    helper = '    static int checks, failures;\n    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }\n'

    def emit(primary, name, ids, authority, version, expected, lines, cases, prerequisite):
        header = "/*\nRules: " + "; ".join(ids) + "\nAuthority: " + authority + "\nVersion: " + version + "\nExpected: " + expected + "\n"
        if expected == "run":
            header += f"Stdout: OK {len(cases)}\n"
        header += "Generated: " + GENERATOR + "\n*/\n"
        program = "using System;\nclass Program\n{\n" + (helper if expected == "run" else "") + "    static void Main()\n    {\n"
        program += "\n".join("        " + line for line in lines) + "\n"
        if expected == "run":
            program += '        if (failures == 0) Console.WriteLine("OK " + checks);\n'
        program += "    }\n}\n"
        path = f"clauses/{CLAUSE}/tests/{primary}/{name}.cs"
        write_text(root / path, header + program)
        test_id = "--".join([CLAUSE, primary, name])
        cells.extend({"test_id": test_id, "case_id": case, "rule_ids": ";".join(ids), "prerequisites": prerequisite,
                      "checks": "1" if expected == "run" else "0"} for case in cases)

    families = [
        ("E10-2-3-int", "int", [-2147483648, -65537, -32769, -257, -129, -1, 0, 1, 2, 127, 128, 255, 256, 32768, 65536, 2147483647]),
        ("E10-2-3-sbyte", "sbyte", [-128, -127, -100, -65, -64, -2, -1, 0, 1, 2, 16, 63, 64, 100, 126, 127]),
    ]
    for rule, source_type, values in families:
        lines, cases = [], []
        for index, value in enumerate(values):
            case = f"{source_type}-long-{index:02d}"
            cases.append(case)
            lines.append(f'{{ {source_type} input = {value}; long output = input; Check(output == {value}L, "{case}"); }}')
        emit(rule, "generated-widen", [rule, "E10-2-3-exact"], "ECMA-334 7th ed 10.2.3", "7.3", "run", lines, cases, f"{source_type}; long; implicit numeric conversion")
    lines, cases = [], []
    for index, value in enumerate([-2147483648, -257, -256, -129, -1, 0, 1, 2, 127, 128, 254, 255, 256, 257, 65536, 2147483647]):
        case = f"checked-int-byte-{index:02d}"
        cases.append(case)
        allowed = 0 <= value <= 255
        lines += ["{", f"    int input = {value};", "    try", "    {", "        byte output = checked((byte)input);",
                  f'        Check({"output == " + str(value) if allowed else "false"}, "{case}");', "    }", "    catch (OverflowException)", "    {",
                  f'        Check({"false" if allowed else "true"}, "{case}");', "    }", "    catch (Exception error)", "    {",
                  f'        Check(false, "{case}");', '        Console.WriteLine("EXCEPTION " + error.GetType().FullName);', "    }", "}"]
    emit("E10-3-2-checked-integral", "generated-boundaries", ["E10-3-2-checked-integral", "E10-3-2-checked-overflow"],
         "ECMA-334 7th ed 10.3.2", "7.3", "run", lines, cases, "int; byte; checked explicit conversion; exception handling")
    emit("E10-2-3-only-listed", "generated-float-int-reject", ["E10-2-3-only-listed"], "ECMA-334 7th ed 10.2.3", "7.3", "reject",
         ["float input = 17.5f;", "int output = input;"], ["float-int-no-implicit"], "float; int; implicit numeric conversion")
    lines, cases = [], []
    for index, value in enumerate([-2147483648, -65537, -32769, -257, -129, -1, 0, 1, 2, 127, 128, 255, 256, 32768, 65536, 2147483647]):
        case = f"nint-long-{index:02d}"
        cases.append(case)
        lines.append(f'{{ nint input = {value}; long output = input; Check(output == {value}L, "{case}"); }}')
    emit("P09-native-nint-long", "generated-widen", ["P09-native-nint-long"], "csc 5.11.0-1.26425.128 (C# 9.0)", "9.0", "run",
         lines, cases, "nint; long; implicit native numeric conversion")
    emit("P09-native-long-nint-no-implicit", "generated-reject", ["P09-native-long-nint-no-implicit"], "csc 5.11.0-1.26425.128 (C# 9.0)", "9.0", "reject",
         ["long input = 17;", "nint output = input;"], ["long-nint-no-implicit"], "long; nint; implicit native numeric conversion")
    write_tsv(root / "clauses/10-conversions/generators/sample-matrix.cases.tsv", cells, ["test_id", "case_id", "rule_ids", "prerequisites", "checks"])


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=SUITE)
    generate(parser.parse_args().output_root)
