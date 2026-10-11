"""Generate all independent choices of the optional for-statement clauses."""
import argparse
import csv
import io
from itertools import product
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows


def main():
    suite = Path(__file__).resolve().parents[3]
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=suite)
    args = parser.parse_args()
    output = args.output_root.resolve()
    relative = "clauses/13-statements/tests/E13-9-4-form-for/optional-parts.cs"
    test_id = "13-statements--E13-9-4-form-for--optional-parts"
    rules = "E13-9-4-form-for;E13-9-4-for-absent-condition-body;E13-9-4-for-condition-evaluation"
    lines, rows = [], []
    for initial, condition, iterator in product((0, 1), repeat=3):
        case_id = f"parts-{initial}{condition}{iterator}"
        init = "Tick(ref a)" if initial else ""
        cond = "Gate(ref b)" if condition else ""
        step = "Tick(ref c)" if iterator else ""
        lines += ["        {", "            int a = 0, b = 0, c = 0, n = 0;",
                  f"            for ({init}; {cond}; {step}) {{ n++; if (n == 2) break; }}",
                  f'            Check(a == {initial} && b == {condition * 2} && c == {iterator} && n == 2, "{case_id}");',
                  "        }"]
        rows.append(dict(test_id=test_id, case_id=case_id, rule_ids=rules,
                         prerequisites="for-statement;int-ref-parameters;named-accumulating-checks"))
    template = Path(__file__).with_suffix(".template").read_text(encoding="ascii")
    source = template.replace("@@CASES@@", "\n".join(lines))
    if "@@CASES@@" in source or any(len(line) > 120 for line in source.splitlines() if "Rules:" not in line):
        raise ValueError("invalid generated source")
    stream = io.StringIO(newline="")
    rows = normalize_case_rows(output, rows, {test_id: source})
    writer = csv.DictWriter(stream, fieldnames=["test_id", "case_id", "rule_ids", "prerequisites", "checks"],
                            delimiter="\t", lineterminator="\n")
    writer.writeheader()
    writer.writerows(rows)
    for name, text in [(relative, source), ("clauses/13-statements/generators/for-parts.cases.tsv", stream.getvalue())]:
        path = output / name
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_text(text, encoding="utf-8", newline="\n")


if __name__ == "__main__":
    main()
