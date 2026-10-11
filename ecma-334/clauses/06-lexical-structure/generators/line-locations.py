"""Cross line spelling, source name, mapping mode, and diagnostic severity.

Generated diagnostic probes are checked by the runner's verdict.
The run probes compile and run (OK 0); their cases are compiler observations.
"""
import argparse
import csv
import json
from itertools import product
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

HERE = Path(__file__).resolve().parent
SUITE = HERE.parents[2]
CLAUSE = Path("clauses/06-lexical-structure")
MODES = {
    "mapped": ("E6-5-8-reported-line-number",
               ["E6-5-8-reported-source-name", "E6-5-8-grammar-pp-line-indicator-1"]),
    "number-only": ("E6-5-8-grammar-pp-line-indicator-2", ["E6-5-8-reported-line-number"]),
    "default": ("E6-5-8-line-default-reset",
                ["E6-5-8-grammar-pp-line-indicator-3", "E6-5-8-true-source-line", "E6-5-8-true-source-name"]),
    "hidden": ("E6-5-8-grammar-pp-line-indicator-4", []),
    "plain": ("E6-5-8-true-source-line", ["E6-5-8-true-source-name"]),
}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=SUITE)
    root = parser.parse_args().output_root.resolve()
    template = (HERE / "line-locations.cs.in").read_text(encoding="ascii")
    rows = []

    def emit(mode, spelling, filename, severity, name):
        primary, related = MODES[mode]
        rules = [primary, *related]
        if mode != "plain":
            rules += ["E6-5-8-grammar-pp-line-1", "E6-5-1-grammar-pp-kind-3",
                      "E6-5-8-grammar-pp-compilation-unit-name-1",
                      "E6-5-8-grammar-pp-compilation-unit-name-character-1"]
        if mode == "hidden" and severity == "error":
            rules.append("E6-5-8-hidden-error-line")
        rules += ["E6-5-1-grammar-pp-kind-4", "E6-5-6-grammar-pp-message-1",
                  "E6-5-6-grammar-pp-diagnostic-1" if severity == "error" else "E6-5-6-grammar-pp-diagnostic-2",
                  "E6-5-6-error-diagnostic" if severity == "error" else "E6-5-6-warning-diagnostic"]
        rules = list(dict.fromkeys(rules))
        directives = (HERE / ("line-" + mode + ".directives.in")).read_text(encoding="ascii")
        directives = directives.replace("@NUMBER@", spelling).replace("@FILE@", filename).rstrip("\n")
        message = "diagnostic-" + name
        expected_line = "physical" if mode in {"plain", "default"} else (2 if mode == "hidden" else 1)
        expected_file = "physical" if mode in {"plain", "default"} else filename
        observation = dict(case_id=name, source="#" + severity + " " + message, severity=severity,
                           file=expected_file, line=expected_line, contains=message)
        source = template.replace("@RULES@", "; ".join(rules)).replace("@EXPECTED@", "reject" if severity == "error" else "run")
        source = source.replace("@STDOUT@", "" if severity == "error" else "Stdout: OK 0\n")
        source = source.replace("@OBSERVATION@", json.dumps(observation, separators=(",", ":")))
        source = source.replace("@DIRECTIVES@", directives).replace("@SEVERITY@", severity).replace("@MESSAGE@", message)
        path = root / CLAUSE / "tests" / primary / (name + ".cs")
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_text(source, encoding="ascii", newline="\n")
        rows.append(dict(test_id="--".join(["06-lexical-structure", primary, name]), case_id=name,
                         rule_ids=";".join(rules), prerequisites="line-" + mode + ";diagnostic-" + severity))

    for mode, number, file, severity in product(["mapped", "number-only", "default", "hidden"],
                                               [("one", "1"), ("padded-one", "0001")],
                                               [("alpha", "alpha.origin"), ("punctuation", "segment+[-]().origin")],
                                               ["warning", "error"]):
        name = "-".join([mode, number[0], file[0], severity])
        emit(mode, number[1], file[1], severity, name)
    for severity in ["warning", "error"]:
        emit("plain", "", "", severity, "plain-" + severity)
    path = root / CLAUSE / "generators" / "line-locations.cases.tsv"
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open("w", encoding="ascii", newline="") as stream:
        rows = normalize_case_rows(root, rows)
        writer = csv.DictWriter(stream, fieldnames=["test_id", "case_id", "rule_ids", "prerequisites", "checks"],
                                delimiter="\t", lineterminator="\n")
        writer.writeheader()
        writer.writerows(rows)


if __name__ == "__main__":
    main()
