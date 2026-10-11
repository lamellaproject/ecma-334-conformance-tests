"""Independent integer/decimal/Boolean/enum/IEEE comparison and lifted-null matrices.

Floating comparison uses symbolic ranks, shared by the two signed zeros, and a
separate NaN state. It does not use host floating comparison or compiler results.
Authority: ECMA-334 12.12.1-12.12.6. Programs are external templates.
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
GENERATOR = FOLDER + '/generators/comparisons.py'
OPS = [('equality', '=='), ('inequality', '!='), ('less', '<'), ('greater', '>'), ('less-equal', '<='), ('greater-equal', '>=')]
TYPES = [('int', 32, True), ('uint', 32, False), ('long', 64, True), ('ulong', 64, False)]
ENUM = [('sbyte', 8, True), ('byte', 8, False), ('short', 16, True), ('ushort', 16, False)] + TYPES
BITS = {'float': [0xFF800000, 0xFF7FFFFF, 0x80000001, 0x80000000, 0, 1, 0x7F7FFFFF, 0x7F800000, 0x7FC00000],
        'double': [0xFFF0000000000000, 0xFFEFFFFFFFFFFFFF, 0x8000000000000001, 0x8000000000000000, 0,
                   1, 0x7FEFFFFFFFFFFFFF, 0x7FF0000000000000, 0x7FF8000000000000]}
RANKS = [-3, -2, -1, 0, 0, 1, 2, 3, None]

def relation(a, b, op):
    if a is None or b is None:
        return op == '!='
    return {'==': a == b, '!=': a != b, '<': a < b, '>': a > b, '<=': a <= b, '>=': a >= b}[op]

def literal(n, typ):
    if typ == 'bool':
        return 'true' if n else 'false'
    return str(n) + {'uint': 'U', 'long': 'L', 'ulong': 'UL', 'float': 'F', 'double': 'D', 'decimal': 'M'}.get(typ, '')

def write(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(value, encoding='ascii', newline='\n')

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--output-root', type=Path, default=SUITE)
    output = parser.parse_args().output_root
    index = []

    def emit(section, slugs, name, typ, declaration, cases, prerequisites, floating=False, extras=None):
        rules = ['E12-12-' + str(section) + '-' + slug for slug in slugs] + (extras or [])
        primary = rules[0]
        joined = '; '.join(rules)
        header = '\n'.join(['/*', 'Rules: ' + joined, 'Authority: ECMA-334 7th ed 12.12.' + str(section),
                            'Version: 7.3', 'Expected: run', 'Stdout: OK ' + str(len(cases)), 'Generated: ' + GENERATOR, '*/'])
        template = (HERE / ('comparisons-float.template.txt' if floating else 'comparisons.template.txt')).read_text(encoding='ascii')
        text = template.replace('{header}', header).replace('{type}', typ).replace('{declaration}', declaration)
        text = text.replace('{bits}', 'uint' if typ == 'float' else 'ulong').replace('{cases}', '\n'.join(cases))
        write(output / FOLDER / 'tests' / primary / (name + '.cs'), text)
        for n in range(len(cases)):
            index.append({'test_id': '12-expressions--' + primary + '--' + name, 'case_id': 'case-' + str(n),
                          'rule_ids': ';'.join(rules), 'prerequisites': prerequisites})

    groups = [(2, typ, width, signed) for typ, width, signed in TYPES]
    groups += [(4, 'decimal', 96, True), (5, 'bool', 1, False)]
    groups += [(6, typ, width, signed) for typ, width, signed in ENUM]
    for section, typ, width, signed in groups:
        enum = section == 6
        actual_type = 'E' if enum else typ
        declaration = 'enum E : ' + typ + ' { }' if enum else ''
        if typ == 'bool':
            samples = [(False, False), (False, True), (True, False), (True, True)]
        else:
            lo = -(1 << (width - 1)) if signed else 0
            hi = (1 << (width - (1 if signed else 0))) - 1
            if typ == 'decimal':
                lo, hi = -79228162514264337593543950335, 79228162514264337593543950335
            samples = [(lo, hi), (hi, lo), (lo, lo), (hi, hi), (19, 4), (4, 19), (4, 4)]
            if signed:
                samples += [(-4, 0), (0, -4)]
        for slug, op in OPS[:2] if typ == 'bool' else OPS:
            cases = []
            for n, (a, b) in enumerate(samples):
                left = literal(a, typ); right = literal(b, typ)
                if enum:
                    left = '(E)(' + left + ')'; right = '(E)(' + right + ')'
                expr = 'A(' + left + ') ' + op + ' A(' + right + ')'
                condition = '(' + expr + ') == ' + ('true' if relation(a, b, op) else 'false')
                if typ == 'bool' and op == '!=':
                    condition += ' && (' + expr + ') == (A(' + left + ') ^ A(' + right + '))'
                cases.append('        Check(' + condition + ' && Kind(' + expr + ') == 1, "case-' + str(n) + '");')
            slugs = ['predefined-' + slug] + (['underlying-comparison'] if enum else ['numeric-values'] if typ != 'bool' else (
                ['equal-values', 'different-values'] if op == '==' else ['unequal-same-values', 'unequal-different-values', 'xor-equivalence']))
            if section == 4:
                slugs += ['decimal-equivalence']
                expr = 'A(2.00M) ' + op + ' A(2.0M)'
                cases.append('        Check((' + expr + ') == ' + ('true' if relation(2, 2, op) else 'false') + ', "case-' + str(len(cases)) + '");')
            extras = ['E12-12-1-predefined-bool', 'E12-12-1-' + slug + '-result']
            emit(section, slugs, typ, actual_type, declaration, cases, actual_type + ' ' + op + ' comparison', extras=extras)
            values = [(4, 19), (4, 4), (None, 4), (4, None), (None, None)] if typ != 'bool' else [(False, True), (True, True), (None, True), (True, None), (None, None)]
            cases = []
            for n, (a, b) in enumerate(values):
                def operand(value):
                    if value is None:
                        return 'null'
                    text = literal(value, typ)
                    return '(E)(' + text + ')' if enum else text
                expr = 'A(' + operand(a) + ') ' + op + ' A(' + operand(b) + ')'
                expected = (a == b) if op == '==' else (a != b) if op == '!=' else False if a is None or b is None else relation(a, b, op)
                cases.append('        Check((' + expr + ') == ' + ('true' if expected else 'false') + ', "case-' + str(n) + '");')
            emit(section, ['lifted'], typ + '-' + slug, actual_type + '?', declaration, cases, 'nullable ' + actual_type + ' ' + op + ' comparison')

    for typ in ('float', 'double'):
        suffix = 'U' if typ == 'float' else 'UL'
        digits = 8 if typ == 'float' else 16
        def operand(n):
            return 'A(0x' + format(BITS[typ][n], '0' + str(digits) + 'X') + suffix + ')'
        pairs = [(a, b) for a in range(len(RANKS)) for b in range(len(RANKS))]
        for slug, op in OPS:
            for start in range(0, len(pairs), 16):
                batch = pairs[start:start + 16]
                cases = []
                for n, (a, b) in enumerate(batch):
                    expr = operand(a) + ' ' + op + ' ' + operand(b)
                    cases.append('        Check((' + expr + ') == ' + ('true' if relation(RANKS[a], RANKS[b], op) else 'false') + ' && Kind(' + expr + ') == 1, "case-' + str(n) + '");')
                slugs = ['predefined-' + slug, 'iec-comparison', 'ordered-finite-values']
                if any(a == 8 or b == 8 for a, b in batch):
                    slugs += ['nan-' + slug]
                if any(a in (3, 4) and b in (3, 4) for a, b in batch) and op in ('==', '!='):
                    slugs += ['signed-zero-equality']
                if (0, 0) in batch and op in ('==', '!='):
                    slugs += ['negative-infinity-equality']
                if (7, 7) in batch and op in ('==', '!='):
                    slugs += ['positive-infinity-equality']
                if any(a == 0 and b != 0 and b != 8 for a, b in batch) and op == '<':
                    slugs += ['negative-infinity-less']
                if any(a == 7 and b != 7 and b != 8 for a, b in batch) and op == '>':
                    slugs += ['positive-infinity-greater']
                emit(3, slugs, typ + '-' + str(start // 16), typ, '', cases, typ + ' raw IEEE ' + op + ' comparison', floating=True,
                     extras=['E12-12-1-predefined-bool', 'E12-12-1-' + slug + '-result'])
            cases = []
            for n, (a, b) in enumerate([(4, 19), (4, 4), (None, 4), (4, None), (None, None)]):
                left = 'null' if a is None else literal(a, typ)
                right = 'null' if b is None else literal(b, typ)
                expected = (a == b) if op == '==' else (a != b) if op == '!=' else False if a is None or b is None else relation(a, b, op)
                cases.append('        Check((A(' + left + ') ' + op + ' A(' + right + ')) == ' + ('true' if expected else 'false') + ', "case-' + str(n) + '");')
            emit(3, ['lifted'], typ + '-' + slug, typ + '?', '', cases, 'nullable ' + typ + ' ' + op + ' comparison')

    stream = io.StringIO(newline='')
    index = normalize_case_rows(output, index)
    writer = csv.DictWriter(stream, fieldnames=['test_id', 'case_id', 'rule_ids', 'prerequisites', 'checks'], delimiter='\t', lineterminator='\n')
    writer.writeheader()
    writer.writerows(index)
    write(output / FOLDER / 'generators' / 'comparisons.cases.tsv', stream.getvalue())

if __name__ == '__main__':
    main()
