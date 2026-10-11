"""Cross Boolean operands, operator families, grouping, and whitespace."""
import argparse
import csv
from itertools import product
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

HERE = Path(__file__).resolve().parent
SUITE = HERE.parents[2]
CLAUSE = Path("clauses/06-lexical-structure")
BASE = ["E6-5-3-grammar-pp-expression-1", "E6-5-3-grammar-pp-unary-expression-1",
        "E6-5-3-grammar-pp-primary-expression-1", "E6-5-3-grammar-pp-primary-expression-2",
        "E6-5-3-expression-boolean-result", "E6-5-3-expression-constant-evaluation",
        "E6-5-3-expression-directive-contexts"]
BINARY = [("and", "&&", "E6-5-3-grammar-pp-and-expression-1", lambda a, b: a and b),
          ("or", "||", "E6-5-3-grammar-pp-or-expression-1", lambda a, b: a or b),
          ("equal", "==", "E6-5-3-grammar-pp-equality-expression-1", lambda a, b: a == b),
          ("unequal", "!=", "E6-5-3-grammar-pp-equality-expression-1", lambda a, b: a != b)]


def write(path, source):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(source, encoding="ascii", newline="\n")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=SUITE)
    root = parser.parse_args().output_root.resolve()
    template = (HERE / "preprocessor-booleans.cs.in").read_text(encoding="ascii")
    case_template = (HERE / "preprocessor-booleans.case.in").read_text(encoding="ascii")
    rows = []

    def emit(primary, name, related, cases, prerequisites):
        rules = list(dict.fromkeys([primary, *related, *BASE]))
        test_id = "--".join(["06-lexical-structure", primary, name])
        blocks = []
        for index, (expr, expected, case_id) in enumerate(cases):
            block = case_template.replace("@EXPRESSION@", expr).replace("@EXPECTED@", str(int(expected)))
            block = block.replace("@INDEX@", str(index)).replace("@CASE@", case_id)
            blocks.append(block.rstrip("\n"))
            rows.append(dict(test_id=test_id, case_id=case_id, rule_ids=";".join(rules), prerequisites=prerequisites))
        source = template.replace("@RULES@", "; ".join(rules)).replace("@COUNT@", str(len(cases)))
        source = source.replace("@CASES@", "\n".join(blocks))
        write(root / CLAUSE / "tests" / primary / (name + ".cs"), source)

    for family, grouped, spaced in product(BINARY, [False, True], [False, True]):
        label, operator, primary, oracle = family
        space = " " if spaced else ""
        cases = []
        for a, b in product([False, True], repeat=2):
            left, right = str(a).lower(), str(b).lower()
            if grouped:
                left, right = "(" + space + left + space + ")", "(" + space + right + space + ")"
            expr = left + space + operator + space + right
            cases.append((expr, oracle(a, b), f"{label}-{int(a)}-{int(b)}"))
        name = label + ("-grouped" if grouped else "-bare") + ("-spaced" if spaced else "-tight")
        related = ["E6-5-3-grammar-pp-primary-expression-4"] if grouped else []
        emit(primary, name, related, cases, name)

    for depth, spaced in product([1, 2], [False, True]):
        space = " " if spaced else ""
        cases = [((("!" + space) * depth) + str(a).lower(), (not a) if depth == 1 else a,
                  f"negations-{depth}-{int(a)}") for a in [False, True]]
        name = f"negations-{depth}" + ("-spaced" if spaced else "-tight")
        emit("E6-5-3-grammar-pp-unary-expression-2", name, [], cases, name)

    precedence = [
        ("or-before-and", ["||", "&&"], lambda a, b, c: a or (b and c),
         ["E6-5-3-grammar-pp-or-expression-1", "E6-5-3-grammar-pp-and-expression-1"]),
        ("and-before-or", ["&&", "||"], lambda a, b, c: (a and b) or c,
         ["E6-5-3-grammar-pp-and-expression-1", "E6-5-3-grammar-pp-or-expression-1"]),
        ("equal-before-and", ["==", "&&"], lambda a, b, c: (a == b) and c,
         ["E6-5-3-grammar-pp-equality-expression-1", "E6-5-3-grammar-pp-and-expression-1"]),
        ("or-before-unequal", ["||", "!="], lambda a, b, c: a or (b != c),
         ["E6-5-3-grammar-pp-or-expression-1", "E6-5-3-grammar-pp-equality-expression-1"]),
    ]
    for family, spaced in product(precedence, [False, True]):
        label, operators, oracle, related = family
        space = " " if spaced else ""
        cases = []
        for a, b, c in product([False, True], repeat=3):
            words = [str(a).lower(), operators[0], str(b).lower(), operators[1], str(c).lower()]
            cases.append((space.join(words), oracle(a, b, c), f"{label}-{int(a)}-{int(b)}-{int(c)}"))
        name = label + ("-spaced" if spaced else "-tight")
        emit("E6-5-3-expression-constant-evaluation", name, related, cases, name)

    path = root / CLAUSE / "generators" / "preprocessor-booleans.cases.tsv"
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open("w", encoding="ascii", newline="") as stream:
        rows = normalize_case_rows(root, rows)
        writer = csv.DictWriter(stream, fieldnames=["test_id", "case_id", "rule_ids", "prerequisites", "checks"],
                                delimiter="\t", lineterminator="\n")
        writer.writeheader()
        writer.writerows(rows)


if __name__ == "__main__":
    main()
