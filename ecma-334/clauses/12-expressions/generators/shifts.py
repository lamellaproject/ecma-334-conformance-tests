"""Generate integer-width, signedness, direction, count-boundary and null-state witnesses.

The oracle uses arbitrary-precision integers and masks the count and result width.
It is independent of compiler outputs. Authority: ECMA-334 12.11.
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
GENERATOR = FOLDER + '/generators/shifts.py'
TYPES = [('int', 32, True), ('uint', 32, False), ('long', 64, True), ('ulong', 64, False)]
COUNTS = [-65, -64, -33, -32, -1, 0, 1, 31, 32, 33, 63, 64, 65, 127, 2147483647, -2147483648]

def literal(n, typ):
    return str(n) + {'int': '', 'uint': 'U', 'long': 'L', 'ulong': 'UL'}[typ]

def shift(value, count, width, signed, left):
    count &= width - 1
    result = value << count if left else value >> count
    result %= 1 << width
    return result - (1 << width) if signed and result >= 1 << (width - 1) else result

def write(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(value, encoding='ascii', newline='\n')

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--output-root', type=Path, default=SUITE)
    output = parser.parse_args().output_root
    index = []

    def emit(slugs, name, typ, cases, template_name, prerequisites):
        rules = '; '.join('E12-11-' + slug for slug in slugs)
        primary = rules.split('; ')[0]
        header = '\n'.join(['/*', 'Rules: ' + rules, 'Authority: ECMA-334 7th ed 12.11', 'Version: 7.3',
                            'Expected: run', 'Stdout: OK ' + str(len(cases)), 'Generated: ' + GENERATOR, '*/'])
        template = (HERE / template_name).read_text(encoding='ascii')
        write(output / FOLDER / 'tests' / primary / (name + '.cs'),
              template.replace('{header}', header).replace('{type}', typ).replace('{cases}', '\n'.join(cases)))
        for n in range(len(cases)):
            index.append({'test_id': '12-expressions--' + primary + '--' + name, 'case_id': 'case-' + str(n),
                          'rule_ids': rules.replace('; ', ';'), 'prerequisites': prerequisites})

    for typ, width, signed in TYPES:
        lo = -(1 << (width - 1)) if signed else 0
        hi = (1 << (width - (1 if signed else 0))) - 1
        for left, direction, op in [(True, 'left', '<<'), (False, 'right', '>>')]:
            slugs = ['predefined-' + direction, 'count-' + ('int' if width == 32 else 'long'),
                     'zero-count', 'no-overflow', 'context-independent']
            slugs += ['left-direction', 'left-discard', 'left-fill'] if left else (
                ['right-signed-discard', 'right-signed-direction', 'right-nonnegative-fill', 'right-negative-fill', 'arithmetic-right']
                if signed else ['right-unsigned-discard', 'right-unsigned-direction', 'right-unsigned-fill', 'logical-right'])
            for group, samples in [('counts', [(lo + 13 if signed else hi - 12, count) for count in COUNTS]),
                                   ('values', [(13, 2), (hi, 1), (lo, 3), (0, -1)] + ([(-7, 2), (-1, 1)] if signed else []))]:
                cases = []
                for n, (value, count) in enumerate(samples):
                    expression = 'A(' + literal(value, typ) + ') ' + op + ' B(' + str(count) + ')'
                    expected = literal(shift(value, count, width, signed, left), typ)
                    cases.append('        Check(checked(' + expression + ') == ' + expected + ' && unchecked(' + expression + ') == ' + expected + ' && Kind(' + expression + ') == 1, "case-' + str(n) + '");')
                emit(slugs, typ + '-' + group, typ, cases, 'shifts.template.txt', typ + ' ' + direction + ' runtime shift in both overflow contexts')
            expr = 'A(' + literal(13, typ) + ') ' + op + ' B(2)'
            cases = ['        Check(' + expr + ' == ' + literal(shift(13, 2, width, signed, left), typ) + ', "case-0");',
                     '        Check(!(A(null) ' + op + ' B(2)).HasValue, "case-1");',
                     '        Check(!(A(' + literal(13, typ) + ') ' + op + ' B(null)).HasValue, "case-2");',
                     '        Check(!(A(null) ' + op + ' B(null)).HasValue, "case-3");']
            emit(['lifted'], typ + '-' + direction, typ, cases, 'shifts-lifted.template.txt', 'nullable ' + typ + ' ' + direction + ' with nullable int count')

    stream = io.StringIO(newline='')
    index = normalize_case_rows(output, index)
    writer = csv.DictWriter(stream, fieldnames=['test_id', 'case_id', 'rule_ids', 'prerequisites', 'checks'], delimiter='\t', lineterminator='\n')
    writer.writeheader()
    writer.writerows(index)
    write(output / FOLDER / 'generators' / 'shifts.cases.tsv', stream.getvalue())

if __name__ == '__main__':
    main()
