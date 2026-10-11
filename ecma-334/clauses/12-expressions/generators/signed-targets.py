"""Independent signed/unsigned and nullable conversion-target combinations, 12.6.4.7."""
import argparse
import csv
import io
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

CLAUSE = "clauses/12-expressions"
GENERATOR = CLAUSE + "/generators/signed-targets.py"
PAIRS = {"sbyte": ("byte", "ushort", "uint", "ulong"),
         "short": ("ushort", "uint", "ulong"), "int": ("uint", "ulong"), "long": ("ulong",)}

def write(root, path, text):
    target = root / path
    target.parent.mkdir(parents=True, exist_ok=True)
    target.write_text(text, encoding="ascii", newline="\n")

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=Path(__file__).resolve().parents[3])
    root = parser.parse_args().output_root.resolve()
    index = []
    for signed, unsigned_types in PAIRS.items():
        rid = "E12-6-4-7-target-" + signed
        rules = rid + "; E12-6-4-5-better-target"
        for unsigned in unsigned_types:
            for left_nullable in (False, True):
                for right_nullable in (False, True):
                    left = signed + ("?" if left_nullable else "")
                    right = unsigned + ("?" if right_nullable else "")
                    case = signed + ("-nullable" if left_nullable else "") + "-over-" + unsigned + ("-nullable" if right_nullable else "")
                    header = (f"/*\nRules: {rules}\nAuthority: ECMA-334 7th ed 12.6.4.7\n"
                              f"Version: 7.3\nExpected: run\nStdout: OK 1\nGenerated: {GENERATOR}\n*/\n")
                    body = ("using System;\nstruct Source\n{\n"
                            f"    public static implicit operator {left}(Source x) {{ return 1; }}\n"
                            f"    public static implicit operator {right}(Source x) {{ return 1; }}\n"
                            "}\nclass Program\n{\n    static int checks, failures;\n"
                            f"    static int Pick({left} x) {{ return 1; }}\n"
                            f"    static int Pick({right} x) {{ return 2; }}\n"
                            '    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }\n'
                            "    static void Main()\n    {\n"
                            f'        Check(Pick(new Source()) == 1, "{case}");\n'
                            '        if (failures == 0) Console.WriteLine("OK " + checks);\n    }\n}\n')
                    write(root, f"{CLAUSE}/tests/{rid}/{case}.cs", header + body)
                    index.append(dict(test_id=f"12-expressions--{rid}--{case}", case_id=case,
                                      rule_ids=rules.replace("; ", ";"), prerequisites="two-user-conversions;overload-resolution"))
    output = io.StringIO(newline="")
    index = normalize_case_rows(root, index)
    writer = csv.DictWriter(output, ("test_id", "case_id", "rule_ids", "prerequisites", "checks"),
                            delimiter="\t", lineterminator="\n")
    writer.writeheader()
    writer.writerows(index)
    write(root, GENERATOR.replace(".py", ".cases.tsv"), output.getvalue())

if __name__ == "__main__":
    main()
