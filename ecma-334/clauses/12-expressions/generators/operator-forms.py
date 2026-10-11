"""Deterministic independent operator-declaration witnesses from ECMA-334 12.4.3."""
import argparse
import csv
import io
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

CLAUSE = "clauses/12-expressions"
GENERATOR = CLAUSE + "/generators/operator-forms.py"
UNARY = [("plus", "+"), ("minus", "-"), ("not", "!"), ("complement", "~"),
         ("increment", "++"), ("decrement", "--"), ("true", "true"), ("false", "false")]
BINARY = [("plus", "+"), ("minus", "-"), ("multiply", "*"), ("divide", "/"), ("remainder", "%"),
          ("and", "&"), ("or", "|"), ("xor", "^"), ("left-shift", "<<"), ("right-shift", ">>"),
          ("equal", "=="), ("unequal", "!="), ("greater", ">"), ("less", "<"),
          ("less-equal", "<="), ("greater-equal", ">=")]
PAIRS = {"==": "!=", "!=": "==", ">": "<", "<": ">", "<=": ">=", ">=": "<="}


def write(root, relative, text):
    path = root / relative
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(text, encoding="ascii", newline="\n")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=Path(__file__).resolve().parents[3])
    args = parser.parse_args()
    root = args.output_root.resolve()
    index = []
    for category, operators in (("unary", UNARY), ("binary", BINARY)):
        for slug, op in operators:
            rid = f"E12-4-3-overload-{category}-{slug}"
            declarations = ""
            if category == "unary" and op in {"true", "false"}:
                declarations = ("    public static int truths, falses, ands;\n"
                    "    public static bool operator true(Box x) { truths++; return x.value != 0; }\n"
                    "    public static bool operator false(Box x) { falses++; return x.value == 0; }\n"
                    "    public static Box operator &(Box x, Box y) { ands++; return new Box(71); }\n")
                if op == "true":
                    action = "int result = 0; if (new Box(5)) result = 1;"
                    predicate = "result == 1 && Box.truths == 1 && Box.falses == 0"
                else:
                    action = "Box result = new Box(0) && new Box(8);"
                    predicate = "result.value == 0 && Box.falses == 1 && Box.ands == 0"
            elif category == "unary":
                declarations = f"    public static Box operator {op}(Box x) {{ return new Box(x.value + 40); }}\n"
                action = f"Box operand = new Box(11); Box result = {op}operand;"
                predicate = "result.value == 51"
            else:
                boolean = op in PAIRS
                result_type = "bool" if boolean else "Box"
                right_type = "int" if op in {"<<", ">>"} else "Box"
                right_value = "y" if right_type == "int" else "y.value"
                answer = f"x.value + {right_value} == 18" if boolean else f"new Box(x.value * 10 + {right_value})"
                declarations = f"    public static {result_type} operator {op}(Box x, {right_type} y) {{ return {answer}; }}\n"
                if boolean:
                    declarations += f"    public static bool operator {PAIRS[op]}(Box x, Box y) {{ return false; }}\n"
                right = "7" if right_type == "int" else "new Box(7)"
                action = f"{result_type} result = new Box(11) {op} {right};"
                predicate = "result" if boolean else "result.value == 117"
            case_id = f"{category}-{slug}-invoked"
            body = ("using System;\nstruct Box\n{\n    public int value;\n"
                    "    public Box(int n) { value = n; }\n" + declarations + "}\nclass Program\n{\n"
                    "    static int checks, failures;\n"
                    '    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }\n'
                    "    static void Main()\n    {\n        " + action + "\n"
                    f'        Check({predicate}, "{case_id}");\n'
                    '        if (failures == 0) Console.WriteLine("OK " + checks);\n    }\n}\n')
            header = (f"/*\nRules: {rid}\nAuthority: ECMA-334 7th ed 12.4.3\nVersion: 7.3\nExpected: run\n"
                      f"Stdout: OK 1\nGenerated: {GENERATOR}\n*/\n")
            write(root, f"{CLAUSE}/tests/{rid}/operator-form.cs", header + body)
            index.append(dict(test_id=f"12-expressions--{rid}--operator-form", case_id=case_id,
                              rule_ids=rid, prerequisites=f"user-defined-{category}-operator-{slug}"))
    stream = io.StringIO(newline="")
    index = normalize_case_rows(root, index)
    writer = csv.DictWriter(stream, fieldnames=["test_id", "case_id", "rule_ids", "prerequisites", "checks"],
                            delimiter="\t", lineterminator="\n")
    writer.writeheader()
    writer.writerows(index)
    write(root, GENERATOR.replace(".py", ".cases.tsv"), stream.getvalue())


if __name__ == "__main__":
    main()
