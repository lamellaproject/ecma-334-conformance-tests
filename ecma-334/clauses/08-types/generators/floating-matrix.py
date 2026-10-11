"""Independent IEEE format and arithmetic matrices for float and double."""
import argparse
import csv
import io
from pathlib import Path

import sys
sys.path.insert(0, str(Path(__file__).resolve().parents[4] / "runner" / "tools"))
from suite_common import normalize_case_rows

parser = argparse.ArgumentParser()
parser.add_argument('--output-root', type=Path, default=Path(__file__).resolve().parents[3])
args = parser.parse_args()
root = args.output_root.resolve()
base = 'clauses/08-types'
generator = base + '/generators/floating-matrix.py'
index = []

def emit(typ, group, ids, statements, cases):
    primary = ids[0]
    name = f'generated-{typ}-{group}'
    test_id = f'08-types--{primary}--{name}'
    path = f'{base}/tests/{primary}/{name}.cs'
    header = f'/*\nRules: {"; ".join(ids)}\nAuthority: ECMA-334 7th ed 8.3.7\nVersion: 7.3\nExpected: run\nStdout: OK {len(cases)}\nGenerated: {generator}\n*/\n'
    body = 'using System;\nclass Program\n{\n    static int checks, failures;\n'
    body += '    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }\n'
    body += '    static void Main()\n    {\n' + statements
    for expression, label in cases:
        case = typ + '-' + label
        body += f'        Check({expression}, "{case}");\n'
        index.append({'test_id': test_id, 'case_id': case, 'rule_ids': ';'.join(ids), 'prerequisites': f'ieee-{typ}-{group}'})
    body += '        if (failures == 0) Console.WriteLine("OK " + checks);\n    }\n}\n'
    destination = root / path
    destination.parent.mkdir(parents=True, exist_ok=True)
    destination.write_text(header + body, encoding='ascii', newline='\n')

for typ, suffix, width, bits, onebits, negativezerobits, maxbits, edge, digits in [
    ('float', 'f', 4, 'SingleToInt32Bits', '0x3f800000', 'unchecked((int)0x80000000)', '0x7f7fffff', '16777216', '1234567'),
    ('double', 'd', 8, 'DoubleToInt64Bits', '0x3ff0000000000000L', 'unchecked((long)0x8000000000000000UL)', '0x7fefffffffffffffL', '9007199254740992', '123456789012345'),
]:
    zero = f'0.0{suffix}'
    one = f'1.0{suffix}'
    statements = f'        {typ} zero = {zero}; {typ} one = {one}; {typ} negativeZero = -zero;\n'
    statements += f'        {typ} max = {typ}.MaxValue; {typ} min = {typ}.Epsilon; {typ} exactDigits = {digits}.0{suffix};\n'
    statements += '        // Denormal support is optional; either flushing to zero or the IEC encoding is permitted.\n'
    cases = [(f'sizeof({typ}) == {width} && BitConverter.{bits}(one) == {onebits}', 'iec-width-and-one'),
             (f'BitConverter.{bits}(negativeZero) == {negativezerobits}', 'negative-zero'),
             ('zero == negativeZero && zero + one == negativeZero + one', 'zeros-usually-equivalent'),
             (f'BitConverter.{bits}(max) == {maxbits}', 'maximum-finite-bound'),
             (f'min == {zero} || BitConverter.{bits}(min) == 1', 'optional-denormal-minimum'),
             (f'(long)exactDigits == {digits}L', 'decimal-digits-retained'),
             (f'one + one / 2 == 1.5{suffix}', 'finite-binary-scaled-value')]
    ids = [f'E8-3-7-{typ}-format', 'E8-3-7-signed-zero-values', 'E8-3-7-signed-zero-usual-equivalence',
           'E8-3-7-finite-floating-form', f'E8-3-7-{typ}-finite-bounds', 'E8-3-7-denormalized-valid-values',
           'E8-3-7-denormalized-support-choice', f'E8-3-7-{typ}-approximate-range', f'E8-3-7-{typ}-decimal-precision']
    emit(typ, 'format', ids, statements, cases)

    statements = f'        {typ} zero = {zero}; {typ} one = {one}; {typ} max = {typ}.MaxValue;\n'
    statements += f'        {typ} positiveInfinity = one / zero; {typ} negativeInfinity = -one / zero; {typ} nan = zero / zero;\n'
    tiny, huge = ('1e-30f', '1e30f') if typ == 'float' else ('1e-300d', '1e300d')
    statements += f'        {typ} overflow = ({typ})(max * 2); {typ} tiny = {tiny}; {typ} huge = {huge};\n'
    statements += f'        {typ} underflow = ({typ})(tiny / huge); {typ} edge = {edge}.0{suffix};\n'
    statements += f'        {typ} rounded = ({typ})(edge + 3.0{suffix}); {typ} assignment = one; assignment /= zero;\n'
    statements += f'        {typ} promoted = one + 3; {typ} excess = (edge + one) - edge;\n'
    cases = [(f'positiveInfinity == {typ}.PositiveInfinity && negativeInfinity == {typ}.NegativeInfinity', 'division-infinities'),
             ('nan != nan', 'invalid-division-nan'), ('overflow == positiveInfinity', 'overflow-infinity'),
             (f'underflow == {zero}', 'underflow-zero'), ('nan + one != nan + one', 'nan-propagation-left'),
             ('one + nan != one + nan', 'nan-propagation-right'), ('positiveInfinity - positiveInfinity != positiveInfinity - positiveInfinity', 'invalid-infinity-operation'),
             (f'rounded == {int(edge) + 4}.0{suffix}', 'nearest-rounding'), ('assignment == positiveInfinity', 'assignment-no-exception'),
             (f'promoted == 4.0{suffix}', 'binary-numeric-promotion'),
             (f'excess == {zero} || excess == {one}', 'permitted-excess-precision')]
    ids = ['E8-3-7-infinity-production', 'E8-3-7-infinity-values', 'E8-3-7-nan-value', 'E8-3-7-nan-invalid-operation',
           'E8-3-7-floating-binary-promotion', 'E8-3-7-floating-binary-precision', 'E8-3-7-floating-no-exceptions',
           'E8-3-7-floating-exceptional-results', 'E8-3-7-floating-nearest-rounding', 'E8-3-7-floating-underflow-zero',
           'E8-3-7-floating-overflow-infinity', 'E8-3-7-floating-invalid-nan', 'E8-3-7-floating-nan-propagation',
           'E8-3-7-floating-excess-precision']
    emit(typ, 'arithmetic', ids, statements, cases)

buf = io.StringIO(newline='')
index = normalize_case_rows(root, index)
writer = csv.DictWriter(buf, ['test_id', 'case_id', 'rule_ids', 'prerequisites', 'checks'], delimiter='\t', lineterminator='\n')
writer.writeheader()
writer.writerows(index)
destination = root / (base + '/generators/floating-matrix.cases.tsv')
destination.parent.mkdir(parents=True, exist_ok=True)
destination.write_text(buf.getvalue(), encoding='ascii', newline='\n')
