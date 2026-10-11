"""Cross integer radix, suffix spelling, and the representable type boundaries.

The emitted .cs files are the test sources. The program structure is an external
source template; this script only enumerates literals and their mathematical
values/types. Each program has one radix and one suffix prerequisite.
"""
import argparse
import csv
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

HERE = Path(__file__).resolve().parent
SUITE = HERE.parents[2]
CLAUSE = "clauses/06-lexical-structure"


def write(path, contents):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(contents, encoding="ascii", newline="\n")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=SUITE)
    root = parser.parse_args().output_root.resolve()
    template = (HERE / "integer-suffixes.cs.in").read_text(encoding="ascii")
    suffixes = ["", "U", "u", "L", "l", "UL", "Ul", "uL", "ul", "LU", "Lu", "lU", "lu"]
    rows = []
    for suffix_index, suffix in enumerate(suffixes):
        if not suffix:
            primary = "E6-4-5-3-unsuffixed-type"
            domain = [(61, 1), (2147483648, 2), (4294967296, 3), (9223372036854775808, 4)]
            type_rule = primary
        else:
            primary = f"E6-4-5-3-grammar-integer-type-suffix-{suffix_index}"
            if suffix.upper() == "U":
                domain, type_rule = [(61, 2), (4294967296, 4)], "E6-4-5-3-u-type"
            elif suffix.upper() == "L":
                domain, type_rule = [(61, 3), (9223372036854775808, 4)], "E6-4-5-3-l-type"
            else:
                domain, type_rule = [(61, 4), (18446744073709551615, 4)], "E6-4-5-3-ul-type"
        for radix_index, radix in enumerate(["decimal", "hexadecimal", "binary"], 1):
            rule_ids = list(dict.fromkeys([
                primary, type_rule, f"E6-4-5-3-{radix}-value",
                f"E6-4-5-3-grammar-integer-literal-{radix_index}",
                f"E6-4-5-3-grammar-{radix}-integer-literal-1",
            ]))
            name = radix + "-suffix-" + (str(suffix_index) if suffix else "none")
            test_id = "--".join(["06-lexical-structure", primary, name])
            checks = []
            for case_index, (value, tag) in enumerate(domain):
                digits = str(value) if radix == "decimal" else format(value, "X" if radix == "hexadecimal" else "b")
                prefix = "" if radix == "decimal" else ("0x" if radix == "hexadecimal" else "0b")
                literal = prefix + digits + suffix
                case_id = f"value-{case_index}"
                checks.append(f'        Check(Tag({literal}) == {tag} && {literal} == {value}UL, "{case_id}");')
                rows.append({"test_id": test_id, "case_id": case_id, "rule_ids": ";".join(rule_ids),
                             "prerequisites": f"integer-literal-{radix};suffix-{suffix_index};primitive-overloads"})
            source = template.replace("{{RULES}}", "; ".join(rule_ids)).replace("{{COUNT}}", str(len(checks)))
            source = source.replace("{{CHECKS}}", "\n".join(checks))
            write(root / CLAUSE / "tests" / primary / (name + ".cs"), source)
    index = root / CLAUSE / "generators" / "integer-suffixes.cases.tsv"
    index.parent.mkdir(parents=True, exist_ok=True)
    with index.open("w", encoding="ascii", newline="") as stream:
        rows = normalize_case_rows(root, rows)
        writer = csv.DictWriter(stream, fieldnames=["test_id", "case_id", "rule_ids", "prerequisites", "checks"],
                                delimiter="\t", lineterminator="\n")
        writer.writeheader()
        writer.writerows(rows)


if __name__ == "__main__":
    main()
