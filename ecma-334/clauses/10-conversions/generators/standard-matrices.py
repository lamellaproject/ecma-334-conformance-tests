"""Independent ECMA numeric, nullable and user-operator selection matrices.

No compiler test corpus or standard examples are used. Numeric expectations come
from numeric_model.py.
Each batch shares types, conversion/context, constant status, nullable shape and
exception prerequisites. The decimal profile is the documented 96-bit target.
"""
import argparse
import itertools
from pathlib import Path

from matrix_support import Matrix, conversion_case, null_case, partition
from numeric_model import TYPES, IMPLICIT, implicit, boundaries, convert, literal
from suite_common import SUITE


def numeric(matrix):
    for source, target in itertools.product(TYPES, repeat=2):
        values = boundaries(source, target)
        for mode, context, constant in itertools.product(["implicit", "explicit"], ["checked", "unchecked"], [False, True]):
            name = f"matrix-{source}-{target}-{mode}-{context}-{'constant' if constant else 'variable'}"
            positive = []
            for index, value in enumerate(values):
                label = f"{source}-{target}-{mode}-{context}-{'constant' if constant else 'variable'}-{index}"
                available = mode == "explicit" or implicit(source, target, value, constant)
                kind, _ = convert(source, target, value, context == "checked")
                rejected = not available or (constant and mode == "explicit" and kind == "overflow")
                if rejected:
                    rules = ["E10-2-3-only-listed"] if not available else ["E12-23-exception"]
                    if not available and constant and source == "int" and target in {"sbyte", "byte", "short", "ushort", "uint", "ulong"}:
                        rules = ["E10-2-11-int-range"]
                    if not available and constant and source == "long" and target == "ulong":
                        rules = ["E10-2-11-negative-long"]
                    if not available and not constant and source == "int" and target in {"sbyte", "byte", "short", "ushort", "uint", "ulong"}:
                        rules.append("E10-2-11-nonconstant")
                    if not available and target == "char":
                        rules.append("E10-2-3-no-char")
                    declaration = ("const " if constant else "") + source + " input = " + literal(source, value) + ";"
                    expression = "input" if mode == "implicit" else f"({target})input"
                    lines = [declaration, f"{target} result = {context}({expression});"]
                    metadata = dict(family="numeric", source=source, target=target, mode=mode, context=context,
                                    constant=str(constant), source_value=literal(source, value), expected="reject",
                                    assertion_label=label, shape="plain")
                    matrix.emit(rules, name + f"-reject-{index:02d}", [(label, lines, metadata)],
                                f"{source}; {target}; {mode}; {context}; const={constant}", reject=True)
                    if not available and not (constant and source in {"int", "long"}):
                        break
                else:
                    case, kind = conversion_case(source, target, value, mode, context, constant, label)
                    case[2]["family"] = "numeric"
                    positive.append((case, kind))
            rules = (["E10-3-2-all-pairs"] if mode == "explicit" else
                     ["E10-2-2-same"] if source == target else ["E10-2-3-" + source])
            if mode == "implicit" and target not in IMPLICIT[source] and source != target:
                rules = ["E10-2-11-int" if source == "int" else "E10-2-11-long"]
            if mode == "explicit" and target != source:
                rules.append("E10-3-2-" + source)
            if constant:
                rules.append("E12-23-numeric")
            for kind, group in partition(positive).items():
                matrix.batches(rules, name + "-" + kind, group,
                               f"{source}; {target}; {mode}; {context}; const={constant}; {kind}")


def nullable(matrix):
    for source, target in itertools.product(TYPES, repeat=2):
        values = boundaries(source, target)
        for mode, context in itertools.product(["implicit", "explicit"], ["checked", "unchecked"]):
            name = f"matrix-{source}-{target}-{mode}-{context}"
            if mode == "implicit" and not implicit(source, target):
                label = "nullable-availability"
                lines = [f"{source}? input = {literal(source, values[0])};", f"{target}? result = {context}(input);"]
                metadata = dict(family="nullable", source=source, target=target, mode=mode, context=context,
                                constant="False", source_value=literal(source, values[0]), expected="reject",
                                assertion_label=label, shape="lift")
                matrix.emit(["E10-2-3-only-listed", "E10-6-1-classification"], name + "-nullable-reject",
                            [(label, lines, metadata)], f"{source}?; {target}?; {mode}; {context}; lift", reject=True)
                continue
            for shape in (["wrap", "lift"] if mode == "implicit" else ["wrap", "lift", "unwrap"]):
                entries = []
                for index, value in enumerate(values):
                    label = f"nullable-{source}-{target}-{mode}-{context}-{shape}-{index}"
                    case, kind = conversion_case(source, target, value, mode, context, False, label, shape)
                    case[2]["family"] = "nullable"
                    entries.append((case, kind))
                related = {"wrap": "E10-6-1-wrap", "lift": "E10-6-1-nonnull", "unwrap": "E10-6-1-unwrap"}[shape]
                for kind, group in partition(entries).items():
                    matrix.batches(["E10-6-1-classification", related], name + "-" + shape + "-" + kind, group,
                                   f"{source}; {target}; nullable {shape}; {mode}; {context}; {kind}")
            for unwrap in ([False] if mode == "implicit" else [False, True]):
                case = null_case(source, target, mode, context, unwrap)
                case[2]["family"] = "nullable"
                primary = "E10-6-1-unwrap" if unwrap else "E10-6-1-null"
                matrix.emit([primary, "E10-6-1-classification"], name + ("-null-unwrap" if unwrap else "-null-lift"),
                            [case], f"{source}?; {target}; {mode}; {context}; null {'unwrap' if unwrap else 'lift'}")
        metadata = dict(family="nullable", source=source, target=target, mode="implicit", context="unchecked",
                        constant="False", source_value=literal(source, values[0]), expected="reject",
                        assertion_label="implicit-unwrap", shape="unwrap")
        matrix.emit(["E10-6-1-no-implicit-unwrap"], f"matrix-{source}-{target}-implicit-unwrap-reject",
                    [("implicit-unwrap", [f"{source}? input = null;", f"{target} result = input;"], metadata)],
                    f"{source}?; {target}; implicit unwrap", reject=True)


def unique(types, encompassing):
    choices = [x for x in types if all(implicit(y, x) if encompassing else implicit(x, y) for y in types)]
    return choices[0] if len(choices) == 1 else None


def selection(endpoint, operators, direction, mode):
    if direction == "source":
        candidates = [x for x in operators if implicit(endpoint, x) or (mode == "explicit" and implicit(x, endpoint))]
        preferred = [x for x in candidates if implicit(endpoint, x)]
        if not candidates:
            return None, "empty"
        if endpoint in candidates:
            return endpoint, "source-exact"
        if mode == "implicit":
            return unique(candidates, False), "source-fallback"
        if preferred:
            return unique(preferred, False), "source-encompassing"
        return unique(candidates, True), "source-encompassed"
    candidates = [x for x in operators if implicit(x, endpoint) or (mode == "explicit" and implicit(endpoint, x))]
    preferred = [x for x in candidates if implicit(x, endpoint)]
    if not candidates:
        return None, "empty"
    if endpoint in candidates:
        return endpoint, "target-exact"
    if mode == "implicit":
        return unique(candidates, True), "target-fallback"
    if preferred:
        return unique(preferred, True), "target-encompassed"
    return unique(candidates, False), "target-encompassing"


def user_selection(matrix):
    domain = ["byte", "short", "ushort", "int", "uint", "long"]
    combinations = itertools.product(["source", "target"], domain, list(itertools.combinations(domain, 2)),
                                     ["implicit", "explicit"], [False, True])
    for direction, endpoint, operators, mode, lifted in combinations:
        chosen, branch = selection(endpoint, operators, direction, mode)
        clause = "E10-5-4" if mode == "implicit" else "E10-5-5"
        if chosen is None:
            suffix = "empty" if branch == "empty" else direction + "-ambiguous" if mode == "implicit" else branch + "-ambiguous"
            rules = [clause + "-" + suffix]
        else:
            rules = [clause + "-" + branch]
            if lifted:
                rules += [clause + "-lifted", "E10-6-2-null", "E10-6-2-nonnull"]
        declarations = ['static class Trace { public static string Selected = ""; public static int Calls; }',
                        'struct Packet { public int Number;']
        for index, operator_type in enumerate(operators):
            if direction == "source":
                declarations.append(f'    public static {mode} operator Packet({operator_type} x) '
                                    f'{{ Trace.Selected = "{operator_type}"; Trace.Calls++; return new Packet {{ Number = 61 }}; }}')
            else:
                declarations.append(f'    public static {mode} operator {operator_type}(Packet x) '
                                    f'{{ Trace.Selected = "{operator_type}"; Trace.Calls++; return ({operator_type})({61 + index}); }}')
        declarations.append("}")
        source = endpoint if direction == "source" else "Packet"
        target = "Packet" if direction == "source" else endpoint
        source_type, target_type = source + ("?" if lifted else ""), target + ("?" if lifted else "")
        initializer = literal(endpoint, 61) if direction == "source" else "new Packet { Number = 61 }"
        expression = "input" if mode == "implicit" else f"({target_type})input"
        label = f"selection-{direction}-{endpoint}-{'-'.join(operators)}-{mode}-{'lifted' if lifted else 'direct'}"
        lines = [f"{source_type} input = {initializer};", f"{target_type} result = {expression};"]
        if chosen is not None:
            variable = "result.Value" if lifted else "result"
            predicate = f"{variable}.Number == 61" if direction == "source" else f"{variable} == {61 + operators.index(chosen)}"
            guard = "result.HasValue && " if lifted else ""
            lines.append(f'Check({guard}{predicate} && Trace.Selected == "{chosen}" && Trace.Calls == 1, "{label}");')
            if lifted:
                lines += [f"input = null; {target_type} absent = {expression};",
                          f'Check(!absent.HasValue && Trace.Calls == 1, "{label}");']
        note = f"user-{direction}; expression/final={endpoint}; candidates={','.join(operators)}; {mode}; lifted={lifted}; branch={branch}"
        metadata = dict(family="user-selection", source=source, target=target, mode=mode, context="unchecked",
                        constant="False", source_value=literal(source, 61) if source in TYPES else "61",
                        expected="reject" if chosen is None else chosen,
                        assertion_label=note, shape="lift" if lifted else "plain")
        matrix.emit(rules, label, [(label, lines, metadata)], note, reject=chosen is None,
                    declarations="\n".join(declarations), checks=2 if lifted else 1)
    for mode, lifted in itertools.product(["implicit", "explicit"], [False, True]):
        src, dst = "First" + ("?" if lifted else ""), "Second" + ("?" if lifted else "")
        declarations = (f"struct First {{ public static {mode} operator Second(First x) {{ return new Second(); }} }}\n"
                        f"struct Second {{ public static {mode} operator Second(First x) {{ return new Second(); }} }}")
        expression = "input" if mode == "implicit" else f"({dst})input"
        label = f"duplicate-owner-{mode}-{'lifted' if lifted else 'direct'}"
        metadata = dict(family="user-selection", source="First", target="Second", mode=mode, context="unchecked",
                        constant="False", source_value="61", expected="reject", assertion_label="duplicate-owner",
                        shape="lift" if lifted else "plain")
        matrix.emit([f"E10-5-{'4' if mode == 'implicit' else '5'}-operator-ambiguous"], label,
                    [(label, [f"{src} input = new First(); {dst} result = {expression};"], metadata)],
                    f"both operator owners; {mode}; lifted={lifted}", reject=True, declarations=declarations)


def generate(root):
    matrix = Matrix(root, "standard-matrices.py")
    numeric(matrix)
    nullable(matrix)
    user_selection(matrix)
    matrix.finish()
    return matrix


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=SUITE)
    generate(parser.parse_args().output_root)
