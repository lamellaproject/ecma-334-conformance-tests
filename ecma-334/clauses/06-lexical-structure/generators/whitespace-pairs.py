"""Cross permitted whitespace characters in two independent token boundaries."""
import argparse
import csv
import io
from itertools import product
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

HERE = Path(__file__).resolve().parent
SUITE = HERE.parents[2]
CLAUSE = Path("clauses/06-lexical-structure")
SPACES = [("space", " ", "E6-3-4-grammar-whitespace-1"),
          ("vertical-tab", "\v", "E6-3-4-grammar-whitespace-3"),
          ("form-feed", "\f", "E6-3-4-grammar-whitespace-4")]


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=SUITE)
    args = parser.parse_args()
    root = args.output_root.resolve()
    template = (HERE / "whitespace-pairs.cs.in").read_text(encoding="ascii")
    rows = []
    for left, right in product(SPACES, repeat=2):
        name = left[0] + "-then-" + right[0]
        rules = list(dict.fromkeys([left[2], right[2], "E6-4-1-whitespace-separator", "E6-3-1-separators"]))
        relative = CLAUSE / "tests" / rules[0] / (name + ".cs")
        path = root / relative
        path.parent.mkdir(parents=True, exist_ok=True)
        source = template.replace("@RULES@", "; ".join(rules)).replace("@LEFT@", left[1])
        source = source.replace("@RIGHT@", right[1]).replace("@CASE@", name)
        path.write_bytes(source.encode("ascii"))
        rows.append(dict(test_id="--".join(["06-lexical-structure", rules[0], name]), case_id=name,
                         rule_ids=";".join(rules),
                         prerequisites=f"whitespace-{ord(left[1]):04X}-and-{ord(right[1]):04X}"))
    index = io.StringIO(newline="")
    rows = normalize_case_rows(root, rows)
    writer = csv.DictWriter(index, fieldnames=list(rows[0]), delimiter="\t", lineterminator="\n")
    writer.writeheader()
    writer.writerows(rows)
    path = root / CLAUSE / "generators" / "whitespace-pairs.cases.tsv"
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(index.getvalue(), encoding="ascii", newline="\n")


if __name__ == "__main__":
    main()
