"""Generate independent float/double witnesses for the normative arithmetic table cells.

Authority: pinned ECMA PDF, printed pages 235-240, table blocks recorded in coverage.tsv.
The oracle below states each table result explicitly. It never uses csc or host arithmetic
to choose an infinity, NaN, or signed-zero result. Finite witnesses use exact small integers.
"""
import argparse
import csv
import io
import struct
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

HERE = Path(__file__).resolve().parent
SUITE = HERE.parents[2]
FOLDER = 'clauses/12-expressions'
GENERATOR = FOLDER + '/generators/floating.py'
LABELS7 = ['positive-finite', 'negative-finite', 'positive-zero', 'negative-zero',
           'positive-infinity', 'negative-infinity', 'nan']
LABELS6 = ['finite', 'positive-zero', 'negative-zero', 'positive-infinity', 'negative-infinity', 'nan']
# Each row/column is in LABELS7 or LABELS6 order. z is the exact finite result.
TABLES = {
    2: ['+z -z +0 -0 +I -I N', '-z +z -0 +0 -I +I N',
        '+0 -0 +0 -0 N N N', '-0 +0 -0 +0 N N N',
        '+I -I N N +I -I N', '-I +I N N -I +I N', 'N N N N N N N'],
    3: ['+z -z +I -I +0 -0 N', '-z +z -I +I -0 +0 N',
        '+0 -0 N N +0 -0 N', '-0 +0 N N -0 +0 N',
        '+I -I +I -I N N N', '-I +I -I +I N N N', 'N N N N N N N'],
    4: ['+z +z N N +x +x N', '-z -z N N -x -x N',
        '+0 +0 N N +0 +0 N', '-0 -0 N N -0 -0 N',
        'N N N N N N N', 'N N N N N N N', 'N N N N N N N'],
    5: ['z x x +I -I N', 'y +0 +0 +I -I N', 'y +0 -0 +I -I N',
        '+I +I +I +I N N', '-I -I -I N -I N', 'N N N N N N'],
    6: ['z x x -I +I N', '-y +0 +0 -I +I N', '-y -0 +0 -I +I N',
        '+I +I +I N +I N', '-I -I -I -I N N', 'N N N N N N'],
}
OPS = {2: '*', 3: '/', 4: '%', 5: '+', 6: '-'}

def raw(value, dialect):
    width = 'f' if dialect == 'single' else 'd'
    packed = struct.pack('>' + width, value)
    return '0x' + packed.hex().upper() + ('U' if dialect == 'single' else 'UL')

def operand(label, magnitude, dialect):
    if label == 'positive-finite':
        value = magnitude
    elif label == 'negative-finite':
        value = -magnitude
    elif label == 'finite':
        value = magnitude
    else:
        value = {'positive-zero': 0.0, 'negative-zero': -0.0,
                 'positive-infinity': float('inf'), 'negative-infinity': -float('inf'), 'nan': float('nan')}[label]
    return ('F' if dialect == 'single' else 'D') + '(' + raw(value, dialect) + ')'

def oracle(token, section, x, y, dialect):
    values = {'+0': 0.0, '-0': -0.0, '+I': float('inf'), '-I': -float('inf'),
              '+x': x, '-x': -x, 'x': x, 'y': y, '-y': -y}
    # Exact witnesses: these computations never overflow and require no host rounding.
    finite_z = {2: 10.0, 3: 2.5, 4: 1.0}.get(section)
    if token in {'+z', '-z'}:
        value = finite_z if token == '+z' else -finite_z
    elif token == 'z':
        value = x + y if section == 5 else x - y
        if value == 0:
            value = 0.0  # The standard fixes positive zero for exact finite cancellation.
    else:
        value = values[token]
    return raw(value, dialect)

def write(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(value, encoding='ascii', newline='\n')

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--output-root', type=Path, default=SUITE)
    args = parser.parse_args()
    template = (HERE / 'floating.template.txt').read_text(encoding='ascii')
    cells = []
    for section, table in TABLES.items():
        labels = LABELS7 if section < 5 else LABELS6
        for row, left in enumerate(labels):
            for column, right in enumerate(labels):
                token = table[row].split()[column]
                rid = 'E12-10-' + str(section) + '-floating-cell-' + left + '-' + right
                prerequisites = 'unsafe IEEE single/double arithmetic; no library bit conversion'
                cases = []
                # An unsigned finite table entry permits either sign: witness both signs independently.
                samples = [(5.0, 2.0)] if section < 5 else [(5.0, 2.0), (-5.0, -2.0), (5.0, -5.0), (-5.0, 5.0)]
                if 'finite' not in (left, right):
                    samples = samples[:1]
                for sample, (x, y) in enumerate(samples):
                    for dialect in ('single', 'double'):
                        case = dialect + '-' + str(sample)
                        expression = operand(left, x, dialect) + ' ' + OPS[section] + ' ' + operand(right, y, dialect)
                        condition = 'Nan(' + expression + ')' if token == 'N' else 'Bits(' + expression + ', ' + oracle(token, section, x, y, dialect) + ')'
                        cases.append('        Check(' + condition + ', "' + case + '");')
                        cells.append({'test_id': '12-expressions--' + rid + '--matrix', 'case_id': case,
                                      'rule_ids': rid, 'prerequisites': prerequisites})
                header = '\n'.join(['/*', 'Rules: ' + rid, 'Authority: ECMA-334 7th ed 12.10.' + str(section),
                                    'Version: 7.3', 'Expected: run', 'Stdout: OK ' + str(len(cases)),
                                    'Generated: ' + GENERATOR, '*/'])
                write(args.output_root / FOLDER / 'tests' / rid / 'matrix.cs',
                      template.replace('{header}', header).replace('{cases}', '\n'.join(cases)))
    stream = io.StringIO(newline='')
    fields = ['test_id', 'case_id', 'rule_ids', 'prerequisites', 'checks']
    cells = normalize_case_rows(args.output_root, cells)
    writer = csv.DictWriter(stream, fieldnames=fields, delimiter='\t', lineterminator='\n')
    writer.writeheader()
    writer.writerows(cells)
    write(args.output_root / FOLDER / 'generators' / 'floating.cases.tsv', stream.getvalue())

if __name__ == '__main__':
    main()
