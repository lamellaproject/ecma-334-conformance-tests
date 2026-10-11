"""Width-based bit truth tables, Boolean tables and nullable logical matrices.

Expected integer values are accumulated a bit at a time from Boolean truth
tables, then interpreted at the declared width. No compiler output is an oracle.
Authority: ECMA-334 12.13.2-12.13.5. Programs use an external template.
"""
import argparse
import csv
import io
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

HERE = Path(__file__).resolve().parent
SUITE = HERE.parents[2]
FOLDER = 'clauses/12-expressions'
GENERATOR = FOLDER + '/generators/logical.py'
TYPES = [('int', 32, True), ('uint', 32, False), ('long', 64, True), ('ulong', 64, False)]
ENUM = [('sbyte', 8, True), ('byte', 8, False), ('short', 16, True), ('ushort', 16, False)] + TYPES
OPS = [('and', '&'), ('or', '|'), ('xor', '^')]
TABLES = {'&': [0, 0, 0, 1], '|': [0, 1, 1, 1], '^': [0, 1, 1, 0]}


def bits(a, b, width, signed, op):
    result = sum(TABLES[op][((a // (2 ** n)) % 2) * 2 + (b // (2 ** n)) % 2] * (2 ** n)
                 for n in range(width))
    return result - 2 ** width if signed and result >= 2 ** (width - 1) else result


def literal(n, typ, enum=False):
    value = str(n) + {'uint': 'U', 'long': 'L', 'ulong': 'UL'}.get(typ, '')
    return '(E)(' + value + ')' if enum else value


def write(path, text):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(text, encoding='ascii', newline='\n')


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--output-root', type=Path, default=SUITE)
    output = parser.parse_args().output_root
    index = []
    template = (HERE / 'logical.template.txt').read_text(encoding='ascii')

    def emit(section, slugs, name, typ, declaration, cases, prerequisites):
        rules = ['E12-13-' + str(section) + '-' + x for x in slugs]
        primary = rules[0]
        header = '\n'.join(['/*', 'Rules: ' + '; '.join(rules),
                            'Authority: ECMA-334 7th ed 12.13.' + str(section), 'Version: 7.3',
                            'Expected: run', 'Stdout: OK ' + str(len(cases)), 'Generated: ' + GENERATOR, '*/'])
        text = template.replace('{header}', header).replace('{type}', typ)
        text = text.replace('{declaration}', declaration).replace('{cases}', '\n'.join(cases))
        write(output / FOLDER / 'tests' / primary / (name + '.cs'), text)
        for n in range(len(cases)):
            index.append({'test_id': '12-expressions--' + primary + '--' + name,
                          'case_id': 'case-' + str(n), 'rule_ids': ';'.join(rules),
                          'prerequisites': prerequisites})

    for section, group in [(2, TYPES), (3, ENUM)]:
        for typ, width, signed in group:
            enum = section == 3
            cs_type = 'E' if enum else typ
            declaration = 'enum E : ' + typ + ' { }' if enum else ''
            lo = -(2 ** (width - 1)) if signed else 0
            hi = 2 ** (width - (1 if signed else 0)) - 1
            stripe = sum(2 ** n for n in range(0, width - 1, 2))
            other_stripe = stripe * 2
            if signed and other_stripe > hi:
                other_stripe -= 2 ** width
            samples = [(lo, hi), (hi, hi), (0, hi), (stripe, other_stripe), (stripe, stripe), (23, 12)]
            if signed:
                samples += [(-1, stripe), (-19, -4)]
            for slug, op in OPS:
                cases = []
                for context in ['checked', 'unchecked']:
                    for a, b in samples:
                        expr = context + '(A(' + literal(a, typ, enum) + ') ' + op + ' A(' + literal(b, typ, enum) + '))'
                        expected = literal(bits(a, b, width, signed, op), typ, enum)
                        cases.append('        Check(' + expr + ' == ' + expected + ' && Kind(' + expr + ') == 1, "case-' + str(len(cases)) + '");')
                slugs = ['predefined-' + slug, 'bitwise-' + slug, 'no-overflow'] if section == 2 else ['predefined-' + slug, 'underlying-operation']
                emit(section, slugs, typ, cs_type, declaration, cases, cs_type + ' bitwise ' + op)
                cases = []
                for a, b in [(lo, hi), (23, 12), (None, 12), (23, None), (None, None)]:
                    left = 'null' if a is None else literal(a, typ, enum)
                    right = 'null' if b is None else literal(b, typ, enum)
                    expr = 'A(' + left + ') ' + op + ' A(' + right + ')'
                    expected = 'null' if a is None or b is None else literal(bits(a, b, width, signed, op), typ, enum)
                    cases.append('        Check((' + expr + ') == ' + expected + ' && Kind(' + expr + ') == 1, "case-' + str(len(cases)) + '");')
                emit(section, ['lifted'], typ + '-' + slug + '-nullable', cs_type + '?', declaration, cases,
                     cs_type + '? lifted bitwise ' + op)

    states = [('false', False), ('true', True)]
    for slug, op in OPS:
        cases = []
        for left, a in states:
            for right, b in states:
                expr = 'A(' + left + ') ' + op + ' A(' + right + ')'
                expected = 'true' if TABLES[op][int(a) * 2 + int(b)] else 'false'
                cond = '(' + expr + ') == ' + expected + ' && Kind(' + expr + ') == 1'
                if op == '^':
                    cond += ' && (' + expr + ') == (A(' + left + ') != A(' + right + '))'
                cases.append('        Check(' + cond + ', "case-' + str(len(cases)) + '");')
        emit(4, ['predefined-' + slug, slug + '-result'] + (['xor-inequality'] if op == '^' else []),
             'bool', 'bool', '', cases, 'Boolean ' + op)

    values = ['true', 'false', 'null']
    nullable_tables = {'&': ['true', 'false', 'null', 'false', 'false', 'false', 'null', 'false', 'null'],
                       '|': ['true', 'true', 'true', 'true', 'false', 'null', 'true', 'null', 'null']}
    for slug, op in OPS[:2]:
        cases, slugs = [], ['predefined-' + slug, 'value-domain']
        for left in values:
            for right in values:
                n = len(cases)
                expr = 'A(' + left + ') ' + op + ' A(' + right + ')'
                cases.append('        Check((' + expr + ') == ' + nullable_tables[op][n] + ' && Kind(' + expr + ') == 1, "case-' + str(n) + '");')
                slugs.append(slug + '-' + left + '-' + right)
        emit(5, slugs, 'truth-table', 'bool?', '', cases, 'nullable Boolean ' + op)

    stream = io.StringIO(newline='')
    index = normalize_case_rows(output, index)
    writer = csv.DictWriter(stream, fieldnames=['test_id', 'case_id', 'rule_ids', 'prerequisites', 'checks'], delimiter='\t', lineterminator='\n')
    writer.writeheader()
    writer.writerows(index)
    write(output / GENERATOR.replace('.py', '.cases.tsv'), stream.getvalue())
    print('Logical programs:', len({r['test_id'] for r in index}), 'cases:', len(index))


if __name__ == '__main__':
    main()
