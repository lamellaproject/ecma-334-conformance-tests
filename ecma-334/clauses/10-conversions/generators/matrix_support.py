"""Emission support for combinatorial conversions, with homogeneous named batches."""
import re
import sys
import math
from collections import defaultdict
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import source_registry, writable, write_text, write_tsv
from numeric_model import assertion, convert, literal


class Matrix:
    def __init__(self, root, generator):
        self.root = writable(root)
        self.generator = "clauses/10-conversions/generators/" + generator
        self.cells = []
        self.dimensions = []
        self.names = set()

    def emit(self, rules, name, cases, prerequisites, reject=False, declarations="", native=False, checks=1):
        rules = list(dict.fromkeys(rules))
        primary = rules[0]
        owner = "12-expressions" if primary.startswith("E12-") else "10-conversions"
        path = f"clauses/{owner}/tests/{primary}/{name}.cs"
        if path in self.names:
            raise ValueError("Repeated generated path: " + path)
        if not cases or len(cases) > 16 or (reject and len(cases) != 1):
            raise ValueError("Invalid case batch")
        self.names.add(path)
        version = "9.0" if native else "7.3"
        authority = (f"csc {source_registry()['csc_version']} (C# {version})" if native else
                     "ECMA-334 7th ed " + re.match(r"E([0-9-]+)-", primary)[1].replace("-", "."))
        header = ("/*\nRules: " + "; ".join(rules) + "\nAuthority: " + authority +
                  "\nVersion: " + version + "\nExpected: " + ("reject" if reject else "run") + "\n")
        if not reject:
            header += f"Stdout: OK {len(cases) * checks}\n"
        header += "Generated: " + self.generator + "\n*/\n"
        program = "using System;\n" + (declarations + "\n" if declarations else "") + "class Program\n{\n"
        if not reject:
            program += ('    static int checks, failures;\n'
                        '    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }\n')
        program += "    static void Main()\n    {\n"
        for case_id, lines, metadata in cases:
            program += "\n".join("        " + line for line in lines) + "\n"
            test_id = "--".join([owner, primary, name])
            self.cells.append(dict(test_id=test_id, case_id=case_id, rule_ids=";".join(rules),
                                   prerequisites=prerequisites, checks="0" if reject else str(checks)))
            self.dimensions.append(dict(test_id=test_id, case_id=case_id, **metadata))
        if not reject:
            program += '        if (failures == 0) Console.WriteLine("OK " + checks);\n'
        program += "    }\n}\n"
        write_text(self.root / path, header + program)

    def batches(self, rules, name, cases, prerequisites, **kwargs):
        for offset in range(0, len(cases), 16):
            self.emit(rules, name + f"-{offset // 16:02d}", cases[offset:offset + 16], prerequisites, **kwargs)

    def finish(self):
        path = Path(self.generator).with_suffix(".cases.tsv")
        write_tsv(self.root / path, self.cells, ["test_id", "case_id", "rule_ids", "prerequisites", "checks"])


def named_assertion(target, value, variable, case_id, guard=""):
    check = assertion(target, value, variable)
    expression = check[len("Check("):-2]
    return f'Check({guard}{expression}, "{case_id}");'


def conversion_case(source, target, value, mode, context, constant, case_id, shape="plain", aliases=None):
    aliases = aliases or {}
    model_source, model_target = aliases.get(source, source), aliases.get(target, target)
    kind, expected = convert(model_source, model_target, value, context == "checked")
    initializer = literal(model_source, value)
    if source in aliases:
        initializer = f"({source})({initializer})"
    source_type = source + ("?" if shape in {"lift", "unwrap"} else "")
    destination = target + ("?" if shape in {"wrap", "lift"} else "")
    declaration = ("const " if constant else "") + f"{source_type} input = {initializer};"
    expression = "input" if mode == "implicit" else f"({destination})input"
    assignment = f"{destination} result = {context}({expression});"
    variable = "result.Value" if shape in {"wrap", "lift"} else "result"
    if target in aliases:
        variable = f"({model_target}){variable}"
    guard = "result.HasValue && " if shape in {"wrap", "lift"} else ""
    if kind == "value":
        check = named_assertion(model_target, expected, variable, case_id, guard)
        compact = "{ " + declaration + " " + assignment + " " + check + " }"
        lines = [compact] if len(compact) + 8 <= 120 else ["{", "    " + declaration, "    " + assignment, "    " + check, "}"]
    else:
        lines = ["{", "    " + declaration]
        if kind == "unspecified":
            lines += ["    bool completed = false;", "    try", "    {",
                      "        // Every destination value is allowed; check only successful completion.",
                      "        " + assignment, "        completed = true;", "    }",
                      "    catch (Exception error)", "    {",
                      '        Console.WriteLine("EXCEPTION " + error.GetType().FullName);', "    }",
                      f'    Check(completed, "{case_id}");', "}"]
        else:
            lines += ["    bool threw = false;", "    try", "    {", "        " + assignment, "    }",
                      "    catch (OverflowException)", "    {", "        threw = true;", "    }",
                      "    catch (Exception error)", "    {",
                      '        Console.WriteLine("EXCEPTION " + error.GetType().FullName);', "    }",
                      f'    Check(threw, "{case_id}");', "}"]
    oracle = "comparison"
    if kind == "value" and model_target in {"float", "double"}:
        oracle = ("is-nan" if math.isnan(expected) else
                  "is-negative-infinity" if math.isinf(expected) and expected < 0 else
                  "is-positive-infinity" if math.isinf(expected) else "bit-pattern")
    source_construct = "literal"
    if model_source in {"float", "double"} and not math.isfinite(value):
        source_construct = "nan-field" if math.isnan(value) else "negative-infinity-field" if value < 0 else "positive-infinity-field"
    elif model_source == "decimal" and constant and value < 0:
        source_construct = "negative-decimal-constant"
    return (case_id, lines, dict(source=source, target=target, mode=mode, context=context, constant=str(constant),
                                source_value=initializer, expected=kind, assertion_label=case_id, shape=shape,
                                oracle=oracle, source_construct=source_construct)), kind


def null_case(source, target, mode, context, unwrap=False):
    shape = "null-unwrap" if unwrap else "null-lift"
    case_id = f"{source}-{target}-{mode}-{context}-{shape}"
    destination = target if unwrap else target + "?"
    expression = "input" if mode == "implicit" else f"({destination})input"
    assignment = f"{destination} result = {context}({expression});"
    if unwrap:
        lines = ["{", f"    {source}? input = null;", "    bool threw = false;", "    try", "    {",
                 "        " + assignment, "    }", "    catch (InvalidOperationException)", "    {",
                 "        threw = true;", "    }", "    catch (Exception error)", "    {",
                 '        Console.WriteLine("EXCEPTION " + error.GetType().FullName);', "    }",
                 f'    Check(threw, "{case_id}");', "}"]
    else:
        compact = f'{{ {source}? input = null; {assignment} Check(!result.HasValue, "{case_id}"); }}'
        lines = [compact] if len(compact) + 8 <= 120 else ["{", f"    {source}? input = null;", "    " + assignment,
                                                               f'    Check(!result.HasValue, "{case_id}");', "}"]
    return case_id, lines, dict(source=source, target=target, mode=mode, context=context, constant="False",
                              source_value="null", expected="null-unwrap" if unwrap else "null",
                              assertion_label="null-unwrap" if unwrap else "null-source", shape=shape)


def partition(cases):
    groups = defaultdict(list)
    for case, kind in cases:
        prerequisites = [kind]
        if case[2].get("oracle", "comparison") != "comparison":
            prerequisites.append(case[2]["oracle"])
        if case[2].get("source_construct", "literal") != "literal":
            prerequisites.append(case[2]["source_construct"])
        groups["-".join(prerequisites)].append(case)
    return groups
