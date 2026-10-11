"""Combinatorial witnesses for numeric widths, overflow contexts and enum underlying types.

Oracles use mathematical integers (including truncation toward zero) and modulo
2**width, independently of csc. The source text is in the adjacent templates.
Authority: ECMA-334 12.10.2-12.10.6, blocks in coverage.tsv.
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
GENERATOR = FOLDER + '/generators/arithmetic.py'
OPS = {2: '*', 3: '/', 4: '%', 5: '+', 6: '-'}
VALUE_RULE = {2: 'product', 3: 'quotient', 4: 'remainder', 5: 'numeric-sum', 6: 'numeric-difference'}
INTEGER = [('int', 32, True), ('uint', 32, False), ('long', 64, True), ('ulong', 64, False)]
ENUM = [('sbyte', 8, True), ('byte', 8, False), ('short', 16, True), ('ushort', 16, False),
        ('int', 32, True), ('uint', 32, False), ('long', 64, True), ('ulong', 64, False)]

def literal(n, typ):
    suffix = {'uint': 'U', 'long': 'L', 'ulong': 'UL', 'float': 'F', 'double': 'D', 'decimal': 'M'}.get(typ, '')
    return str(n) + suffix

def bounds(width, signed):
    return (-(1 << (width - 1)), (1 << (width - 1)) - 1) if signed else (0, (1 << width) - 1)

def arithmetic(section, a, b):
    quotient = (abs(a) // abs(b)) * (-1 if (a < 0) != (b < 0) else 1) if b else 0
    return {2: a * b, 3: quotient, 4: a - quotient * b, 5: a + b, 6: a - b}[section]

def wrapped(value, width, signed):
    value %= 1 << width
    return value - (1 << width) if signed and value >= 1 << (width - 1) else value

def write(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(value, encoding='ascii', newline='\n')

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--output-root', type=Path, default=SUITE)
    output = parser.parse_args().output_root
    index = []

    def emit(section, slugs, name, typ, cases, template_name, prerequisites):
        rules = '; '.join('E12-10-' + str(section) + '-' + slug for slug in slugs)
        primary = rules.split('; ')[0]
        header = '\n'.join(['/*', 'Rules: ' + rules, 'Authority: ECMA-334 7th ed 12.10.' + str(section),
                            'Version: 7.3', 'Expected: run', 'Stdout: OK ' + str(len(cases)),
                            'Generated: ' + GENERATOR, '*/'])
        template = (HERE / template_name).read_text(encoding='ascii')
        write(output / FOLDER / 'tests' / primary / (name + '.cs'),
              template.replace('{header}', header).replace('{type}', typ).replace('{cases}', '\n'.join(cases)))
        for n in range(len(cases)):
            index.append({'test_id': '12-expressions--' + primary + '--' + name, 'case_id': 'case-' + str(n),
                          'rule_ids': rules.replace('; ', ';'), 'prerequisites': prerequisites})

    for typ, width, signed in INTEGER:
        lo, hi = bounds(width, signed)
        for section, op in OPS.items():
            samples = [(19, 4), (0, 4), (3, 7)]
            if signed:
                samples += [(-19, 4), (19, -4), (-19, -4)]
            cases = []
            for n, (a, b) in enumerate(samples):
                expr = 'unchecked(A(' + literal(a, typ) + ') ' + op + ' A(' + literal(b, typ) + '))'
                expected = literal(wrapped(arithmetic(section, a, b), width, signed), typ)
                cases.append('        Check(' + expr + ' == ' + expected + ' && Kind(' + expr + ') == 1, "case-' + str(n) + '");')
            slugs = ['integer-predefined', VALUE_RULE[section]]
            if section == 3:
                slugs += ['integer-rounding', 'integer-same-sign'] + (['integer-opposite-sign'] if signed else [])
            if section == 4:
                slugs += ['integer-value']
            emit(section, slugs, typ + '-values', typ, cases, 'arithmetic.template.txt', typ + ' runtime arithmetic')
            if section in (2, 5, 6):
                pairs = {2: [(hi, 2)], 5: [(hi, 1)], 6: [(lo, 1)]}[section]
                if signed:
                    pairs.append({2: (lo, -1), 5: (lo, -1), 6: (hi, -1)}[section])
                for context in ('checked', 'unchecked'):
                    cases = []
                    for n, (a, b) in enumerate(pairs):
                        expr = context + '(A(' + literal(a, typ) + ') ' + op + ' A(' + literal(b, typ) + '))'
                        if context == 'checked':
                            cases.append('        bool c' + str(n) + ' = false; try { ' + typ + ' r = ' + expr + '; } catch (OverflowException) { c' + str(n) + ' = true; } catch (Exception) { } Check(c' + str(n) + ', "case-' + str(n) + '");')
                        else:
                            cases.append('        Check(' + expr + ' == ' + literal(wrapped(arithmetic(section, a, b), width, signed), typ) + ', "case-' + str(n) + '");')
                    slugs = ['integer-checked-overflow'] if context == 'checked' else ['integer-unchecked-truncation', 'integer-unchecked-no-report']
                    emit(section, slugs, typ + '-' + context, typ, cases, 'arithmetic.template.txt', typ + ' ' + context + ' arithmetic')
            else:
                expr = 'A(' + literal(19, typ) + ') ' + op + ' A(' + literal(0, typ) + ')'
                cases = ['        bool c0 = false; try { ' + typ + ' r = ' + expr + '; } catch (DivideByZeroException) { c0 = true; } catch (Exception) { } Check(c0, "case-0");']
                emit(section, ['integer-zero-divisor'], typ + '-zero', typ, cases, 'arithmetic.template.txt', typ + ' division exceptions')
        if signed:
            for context in ('checked', 'unchecked'):
                expr = context + '(A(' + literal(lo, typ) + ') / A(' + literal(-1, typ) + '))'
                success = 'false' if context == 'checked' else 'r == ' + literal(lo, typ)
                cases = ['        bool c0 = false; try { ' + typ + ' r = ' + expr + '; c0 = ' + success + '; } catch (ArithmeticException) { c0 = true; } catch (Exception) { } Check(c0, "case-0");']
                emit(3, ['integer-' + context + '-minimum'], typ + '-' + context, typ, cases, 'arithmetic.template.txt', typ + ' minimum divided by minus one; either permitted unchecked result')

    for typ in ['int', 'uint', 'long', 'ulong', 'float', 'double', 'decimal']:
        for section, op in OPS.items():
            expr = 'A(' + literal(19, typ) + ') ' + op + ' A(' + literal(4, typ) + ')'
            # All operands are exactly representable; 19/4 is exactly 4.75 for nonintegers.
            value = '4.75' if section == 3 and typ in ('float', 'double', 'decimal') else str(arithmetic(section, 19, 4))
            expected = value + {'uint': 'U', 'long': 'L', 'ulong': 'UL', 'float': 'F', 'double': 'D', 'decimal': 'M'}.get(typ, '')
            cases = ['        Check(' + expr + ' == ' + expected + ' && Kind(' + expr + ') == 1, "case-0");',
                     '        Check(!(A(null) ' + op + ' A(' + literal(4, typ) + ')).HasValue, "case-1");',
                     '        Check(!(A(' + literal(19, typ) + ') ' + op + ' A(null)).HasValue, "case-2");',
                     '        Check(!(A(null) ' + op + ' A(null)).HasValue, "case-3");']
            emit(section, ['lifted'], typ, typ, cases, 'nullable.template.txt', 'nullable ' + typ + ' arithmetic')

    for typ, width, signed in ENUM:
        lo, hi = bounds(width, signed)
        for form in ('enum-plus-underlying', 'enum-enum', 'enum-underlying'):
            section = 5 if form == 'enum-plus-underlying' else 6
            slugs = ['enum-plus-underlying', 'underlying-plus-enum', 'enum-value'] if section == 5 else [form + '-predefined', form + '-value', form + '-result-type']
            samples = [(19, 4), (lo, 1), (hi, 1)]
            cases = []
            for n, (a, b) in enumerate(samples):
                op = OPS[section]
                right = ('V' if form == 'enum-enum' else 'A') + '(' + literal(b, typ) + ')'
                expr = 'unchecked(V(' + literal(a, typ) + ') ' + op + ' ' + right + ')'
                expected = literal(wrapped(arithmetic(section, a, b), width, signed), typ)
                kind = '2' if form == 'enum-enum' else '1'
                extra = ''
                if section == 5:
                    reverse = 'unchecked(A(' + literal(b, typ) + ') + V(' + literal(a, typ) + '))'
                    extra = ' && (' + typ + ')' + reverse + ' == ' + expected + ' && Kind(' + reverse + ') == 1'
                cases.append('        Check((' + typ + ')' + expr + ' == ' + expected + ' && Kind(' + expr + ') == ' + kind + extra + ', "case-' + str(n) + '");')
            emit(section, slugs, typ, typ, cases, 'enumeration.template.txt', 'enum underlying ' + typ + ' unchecked arithmetic')

    stream = io.StringIO(newline='')
    index = normalize_case_rows(output, index)
    writer = csv.DictWriter(stream, fieldnames=['test_id', 'case_id', 'rule_ids', 'prerequisites', 'checks'], delimiter='\t', lineterminator='\n')
    writer.writeheader()
    writer.writerows(index)
    write(output / FOLDER / 'generators' / 'arithmetic.cases.tsv', stream.getvalue())

if __name__ == '__main__':
    main()
