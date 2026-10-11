"""Cross reserved/contextual words with ordinary/verbatim identifier spelling.

Every reserved ordinary spelling is a separate rejected program. The matching
verbatim program proves the same declaration is valid when escaped. Contextual
words exercise both declaration/reference spelling directions outside their
special syntactic contexts. Canonical keyword uses are separate handwritten tests.
The external .cs.in templates contain the program structure; emitted .cs are truth.
"""
import argparse
import csv
import json
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

HERE = Path(__file__).resolve().parent
SUITE = HERE.parents[2]
CLAUSE = "clauses/06-lexical-structure"


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=SUITE)
    root = parser.parse_args().output_root.resolve()
    with (HERE.parent / "rules.tsv").open(encoding="utf-8", newline="") as stream:
        ledger = list(csv.DictReader(stream, delimiter="\t"))
    templates = {name: (HERE / (name + "-word.cs.in")).read_text(encoding="ascii")
                 for name in ["reserved", "verbatim", "contextual"]}
    index_rows = []

    def emit(primary, name, source, rules, cases, prerequisites):
        destination = root / CLAUSE / "tests" / primary / (name + ".cs")
        destination.parent.mkdir(parents=True, exist_ok=True)
        destination.write_text(source, encoding="ascii", newline="\n")
        test_id = "--".join(["06-lexical-structure", primary, name])
        for case in cases:
            index_rows.append({"test_id": test_id, "case_id": case, "rule_ids": ";".join(rules),
                               "prerequisites": prerequisites})

    for row in ledger:
        rid = row["rule_id"]
        if rid.startswith("E6-4-4-grammar-keyword-"):
            word = json.loads(row["quote_json"]).strip("'").lower()
            for variant in ["reserved", "verbatim"]:
                source = templates[variant].replace("{{WORD}}", word)
                rules = source.split("Rules: ", 1)[1].split("\n", 1)[0].split("; ")
                emit(rules[0], word + "-" + variant, source, rules,
                     ["reserved-name" if variant == "reserved" else "verbatim-name"],
                     "integer-local-declaration;" + variant + "-identifier")
        elif rid.startswith("E6-4-4-grammar-contextual-keyword-"):
            word = json.loads(row["quote_json"]).strip("'")
            rules = [rid, "E6-4-4-contextual-identifier", "E6-4-4-contextual-verbatim-identifier",
                     "E6-4-3-grammar-identifier-2", "E6-4-3-identity-remove-at"]
            if word == "await":
                rules.append("E6-4-4-await-identifier-context")
            source = templates["contextual"].replace("{{WORD}}", word).replace("{{RULES}}", "; ".join(rules))
            emit(rid, word + "-identifier-spellings", source, rules,
                 ["ordinary-declaration-verbatim-reference", "verbatim-declaration-ordinary-reference"],
                 "integer-local-declaration;contextual-identifier;verbatim-identifier")
    destination = root / CLAUSE / "generators" / "identifier-words.cases.tsv"
    destination.parent.mkdir(parents=True, exist_ok=True)
    with destination.open("w", encoding="ascii", newline="") as stream:
        index_rows = normalize_case_rows(root, index_rows)
        writer = csv.DictWriter(stream, fieldnames=["test_id", "case_id", "rule_ids", "prerequisites", "checks"],
                                delimiter="\t", lineterminator="\n")
        writer.writeheader()
        writer.writerows(index_rows)


if __name__ == "__main__":
    main()
