"""Native-integer numeric and nullable tables for the documented 64-bit target.

The graph comes from the pinned native-integers proposal. Runtime values use the
independent numeric model with 64-bit aliases. Constant declarations have portable
32-bit domains. Decimal and checked-real constant folding uses csc's fixed domain
in the independent model; csc is the authority for this later feature.
"""
import argparse
import itertools
from pathlib import Path

from matrix_support import Matrix, conversion_case, null_case, partition
from numeric_model import TYPES, IMPLICIT, RANGES, boundaries, convert, literal
from suite_common import SUITE

ALIASES = {"nint": "long", "nuint": "ulong"}
EXTENDED = TYPES + list(ALIASES)
GRAPH = {t: set(IMPLICIT.get(t, set())) for t in EXTENDED}
for _type in ["sbyte", "byte", "short", "ushort", "int", "char"]:
    GRAPH[_type].add("nint")
for _type in ["byte", "ushort", "uint", "char"]:
    GRAPH[_type].add("nuint")
GRAPH["nint"] = {"long", "float", "double", "decimal"}
GRAPH["nuint"] = {"ulong", "float", "double", "decimal"}


def lit(type_name, value):
    text = literal(ALIASES.get(type_name, type_name), value)
    return f"({type_name})({text})" if type_name in ALIASES else text


def pairs():
    return ((s, t) for s, t in itertools.product(EXTENDED, repeat=2) if s in ALIASES or t in ALIASES)


def numeric(matrix):
    for source, target in pairs():
        model_source, model_target = ALIASES.get(source, source), ALIASES.get(target, target)
        availability = source == target or target in GRAPH[source]
        permit = f"P09-native-{source}-{target}"
        deny = permit + "-no-implicit"
        for mode, context, constant in itertools.product(["implicit", "explicit"], ["checked", "unchecked"], [False, True]):
            name = f"matrix-{source}-{target}-{mode}-{context}-{'constant' if constant else 'variable'}"
            entries = []
            for index, value in enumerate(boundaries(model_source, model_target)):
                if constant and source in ALIASES:
                    fixed = "int" if source == "nint" else "uint"
                    if not RANGES[fixed][0] <= value <= RANGES[fixed][1]:
                        continue
                available = availability or (constant and source == "int" and target == "nuint" and value >= 0)
                kind, _ = convert(model_source, model_target, value, context == "checked")
                folded_overflow = False
                if constant and target in ALIASES:
                    fixed = "int" if target == "nint" else "uint"
                    if source == "decimal" or (source in {"float", "double"} and context == "checked"):
                        folded_overflow = convert(model_source, fixed, value, True)[0] == "overflow"
                rejected = (mode == "implicit" and not available) or (mode == "explicit" and constant and (kind == "overflow" or folded_overflow))
                label = f"{source}-{target}-{mode}-{context}-{constant}-{index}"
                if rejected:
                    rules = [deny] if mode == "implicit" else [permit, "E12-23-exception"]
                    declaration = ("const " if constant else "") + f"{source} input = {lit(source, value)};"
                    expression = "input" if mode == "implicit" else f"({target})input"
                    metadata = dict(family="native-numeric", source=source, target=target, mode=mode, context=context,
                                    constant=str(constant), source_value=lit(source, value), expected="reject",
                                    assertion_label=label, shape="plain", folded_overflow=folded_overflow)
                    matrix.emit(rules, name + f"-reject-{index:02d}",
                                [(label, [declaration, f"{target} result = {context}({expression});"], metadata)],
                                f"native width64; {source}; {target}; {mode}; {context}; const={constant}", reject=True, native=True)
                    if mode == "implicit" and not (constant and source == "int" and target == "nuint"):
                        break
                else:
                    case, kind = conversion_case(source, target, value, mode, context, constant, label, aliases=ALIASES)
                    case[2]["family"] = "native-numeric"
                    entries.append((case, kind))
            for kind, group in partition(entries).items():
                matrix.batches([permit], name + "-" + kind, group,
                               f"native width64; {source}; {target}; {mode}; {context}; const={constant}; {kind}", native=True)
    for type_name, value in [("nint", "4294967296L"), ("nuint", "4294967296UL")]:
        label = type_name + "-constant-limit"
        metadata = dict(family="native-constant-limit", source=type_name, target=type_name, mode="explicit", context="unchecked",
                        constant="True", source_value=value, expected="reject", assertion_label=label, shape="plain")
        matrix.emit(["P09-native-constant-limit"], "matrix-" + label,
                    [(label, [f"const {type_name} value = ({type_name}){value};"], metadata)],
                    f"{type_name}; const declaration; fixed32 domain", reject=True, native=True)


def nullable(matrix):
    for source, target in pairs():
        model_source, model_target = ALIASES.get(source, source), ALIASES.get(target, target)
        rid = f"P09-native-{source}-{target}"
        for mode, context in itertools.product(["implicit", "explicit"], ["checked", "unchecked"]):
            name = f"matrix-{source}-{target}-{mode}-{context}"
            availability = source == target or target in GRAPH[source]
            if mode == "implicit" and not availability:
                label = "implicit-lift-unavailable"
                metadata = dict(family="native-nullable", source=source, target=target, mode=mode, context=context,
                                constant="False", source_value="97", expected="reject", assertion_label=label, shape="lift")
                matrix.emit([rid + "-no-implicit"], name + "-nullable-reject",
                            [(label, [f"{source}? input = {lit(source, 97)};", f"{target}? result = {context}(input);"], metadata)],
                            f"native width64; {source}?; {target}?; {mode}; {context}; lift", reject=True, native=True)
                continue
            for shape in (["wrap", "lift"] if mode == "implicit" else ["wrap", "lift", "unwrap"]):
                entries = []
                for index, value in enumerate(boundaries(model_source, model_target)):
                    label = f"{source}-{target}-{mode}-{context}-{shape}-{index}"
                    case, kind = conversion_case(source, target, value, mode, context, False, label, shape, ALIASES)
                    case[2].update(family="native-nullable", assertion_label=f"{shape}-{index}")
                    entries.append((case, kind))
                related = "P09-native-nullable-" + ("lift" if shape == "lift" else shape)
                for kind, group in partition(entries).items():
                    matrix.batches([rid, related], name + "-" + shape + "-" + kind, group,
                                   f"native width64; {source}; {target}; nullable {shape}; {mode}; {context}; {kind}", native=True)
            for unwrap in ([False] if mode == "implicit" else [False, True]):
                case = null_case(source, target, mode, context, unwrap)
                case[2]["family"] = "native-nullable"
                matrix.emit([rid, "P09-native-nullable-unwrap" if unwrap else "P09-native-nullable-lift"],
                            name + ("-null-unwrap" if unwrap else "-null-lift"), [case],
                            f"native width64; {source}?; {target}; {mode}; {context}; null {'unwrap' if unwrap else 'lift'}", native=True)


def generate(root):
    matrix = Matrix(root, "native-matrices.py")
    numeric(matrix)
    nullable(matrix)
    matrix.finish()
    return matrix


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output-root", type=Path, default=SUITE)
    generate(parser.parse_args().output_root)
