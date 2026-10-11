"""Deterministic keyword aliases, integral boundaries, and enum domains."""
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
generator = base + '/generators/numeric-matrix.py'
index = []
helper = '''    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
'''

def emit(ids, name, checks, declarations='', statements='', reject=''):
    primary = ids[0]
    subclause = primary[1:].rsplit('-', 1)[0]
    # Rule slugs may contain dashes; take only the numeric prefix.
    import re
    subclause = re.match(r'E([0-9]+(?:-[0-9]+)*)-', primary)[1].replace('-', '.')
    path = f'{base}/tests/{primary}/{name}.cs'
    test_id = f'08-types--{primary}--{name}'
    expected = 'reject' if reject else 'run'
    header = f'/*\nRules: {"; ".join(ids)}\nAuthority: ECMA-334 7th ed {subclause}\nVersion: 7.3\nExpected: {expected}\n'
    if not reject:
        header += f'Stdout: OK {len(checks)}\n'
    header += f'Generated: {generator}\n*/\n'
    if reject:
        body = reject
        cases = ['reject-' + name]
    else:
        body = 'using System;\n' + declarations + 'unsafe class Program\n{\n' + helper
        body += '    static void Main()\n    {\n' + statements
        cases = []
        for expression, case in checks:
            body += f'        Check({expression}, "{case}");\n'
            cases.append(case)
        body += '        if (failures == 0) Console.WriteLine("OK " + checks);\n    }\n}\n'
    destination = root / path
    destination.parent.mkdir(parents=True, exist_ok=True)
    destination.write_text(header + body, encoding='ascii', newline='\n')
    for case in cases:
        index.append({'test_id': test_id, 'case_id': case, 'rule_ids': ';'.join(ids), 'prerequisites': 'numeric-' + name})

# size, signedness, decimal endpoints and a representable probe; integer literals include their suffix.
integrals = [
    ('sbyte', 'SByte', 1, True, '-128', '127', '36'),
    ('byte', 'Byte', 1, False, '0', '255', '36'),
    ('short', 'Int16', 2, True, '-32768', '32767', '36'),
    ('ushort', 'UInt16', 2, False, '0', '65535', '36'),
    ('int', 'Int32', 4, True, '-2147483648', '2147483647', '36'),
    ('uint', 'UInt32', 4, False, '0U', '4294967295U', '36U'),
    ('long', 'Int64', 8, True, '-9223372036854775808L', '9223372036854775807L', '36L'),
    ('ulong', 'UInt64', 8, False, '0UL', '18446744073709551615UL', '36UL'),
    ('char', 'Char', 2, False, "'\x00'", "'\uffff'", "'Q'"),
]
for typ, alias, size, signed, low, high, probe in integrals:
    if typ == 'char':
        low, high = "'\\u0000'", "'\\uffff'"
    ids = [f'E8-3-6-{typ}-range', f'E8-3-6-{typ}-format', f'E8-3-5-alias-{typ}',
           'E8-3-5-simple-system-aliases', 'E8-3-5-simple-type-members', f'E8-3-1-integral-form-{typ}',
           'E8-3-1-numeric-form-integral', 'E8-3-1-simple-form-numeric', 'E8-3-1-struct-form-simple',
           'E8-3-1-simple-types-keywords', 'E8-3-6-integral-types', 'E8-3-3-simple-default-bits',
           'E8-8-unmanaged-simple-types', 'E8-8-unmanaged-form-value']
    ids.append('E8-3-3-char-default' if typ == 'char' else 'E8-3-3-integral-default')
    if signed:
        ids.append('E8-3-6-signed-twos-complement')
    if typ == 'char':
        ids += ['E8-3-6-char-unicode', 'E8-3-6-char-integral-classification', 'E8-3-6-char-constant-spelling']
    statements = f'        {typ} low = {low}; {typ} high = {high}; {typ} empty = new {typ}();\n'
    statements += f'        System.{alias} alias = {probe}; {typ} same = alias;\n'
    statements += f'        byte* zeros = (byte*)&empty; bool allZeros = true;\n'
    statements += f'        for (int i = 0; i < sizeof({typ}); i++) if (zeros[i] != 0) allZeros = false;\n'
    statements += f'        {typ}* address = &same;\n'
    checks = [(f'sizeof({typ}) == {size}', typ + '-storage-width'),
              (f'low == {low} && high == {high}', typ + '-inclusive-endpoints'),
              (f'same == {probe}', typ + '-keyword-alias'),
              (f'empty == ({typ})0', typ + '-default-zero'),
              (f'empty.CompareTo(same) < 0', typ + '-aliased-members'),
              ('allZeros', typ + '-default-bits'), ('*address == same', typ + '-unmanaged-address')]
    if signed:
        statements += f'        {typ} negative = -1; byte* bytes = (byte*)&negative; bool allOnes = true;\n'
        statements += f'        for (int i = 0; i < sizeof({typ}); i++) if (bytes[i] != 255) allOnes = false;\n'
        checks.append(('allOnes', typ + '-twos-complement-negative-one'))
    if typ == 'char':
        statements += '        int promoted = high + 1; char castLiteral = (char)0x51;\n'
        checks += [('promoted == 65536 && castLiteral == same', 'char-integral-and-literal-cast')]
    emit(ids, 'generated-' + typ, checks, statements=statements)
    if typ != 'char':
        integer_low = int(low.rstrip('UL'))
        integer_high = int(high.rstrip('UL'))
        for direction, invalid in [('below', str(integer_low - 1)), ('above', str(integer_high + 1))]:
            # An ulong endpoint beyond the literal domain uses a constant conversion from decimal instead.
            if typ == 'ulong' and direction == 'above':
                line = 'const ulong value = (ulong)18446744073709551616m;'
            elif typ == 'long' and direction == 'below':
                line = 'const long value = (long)(-9223372036854775809m);'
            else:
                line = f'const {typ} value = {invalid};'
            emit([f'E8-3-6-{typ}-range'], 'generated-' + direction, [], reject=f'class Program {{ static void Main() {{ {line} }} }}\n')

for typ, alias, literal, default_rule, form in [
    ('float', 'Single', '3.25f', 'float', 'floating'),
    ('double', 'Double', '3.25d', 'double', 'floating'),
    ('decimal', 'Decimal', '3.25m', 'decimal', 'decimal'),
    ('bool', 'Boolean', 'true', 'bool', 'bool'),
]:
    ids = [f'E8-3-5-alias-{typ}', 'E8-3-5-simple-system-aliases', 'E8-3-5-simple-type-members', f'E8-3-3-{default_rule}-default',
           'E8-8-unmanaged-simple-types', 'E8-8-unmanaged-form-value']
    if form == 'floating':
        ids += [f'E8-3-1-floating-form-{typ}', 'E8-3-1-numeric-form-floating']
    elif form == 'decimal':
        ids.append('E8-3-1-numeric-form-decimal')
    else:
        ids += ['E8-3-1-simple-form-bool', 'E8-3-9-bool-values']
    zero = 'false' if typ == 'bool' else '0'
    statements = f'        System.{alias} named = {literal}; {typ} same = named; {typ} empty = new {typ}();\n'
    statements += f'        {typ}* address = &same;\n'
    emit(ids, 'generated-' + typ, [(f'same == {literal}', typ + '-keyword-alias'), (f'empty == {zero}', typ + '-default-value'),
                                 ('!empty.Equals(same)', typ + '-aliased-members'), ('*address == same', typ + '-unmanaged-address')], statements=statements)

for typ, alias, size, signed, low, high, probe in integrals[:-1]:
    ids = ['E8-3-10-enum-underlying-value-set', 'E8-3-10-enum-underlying-type-required', 'E8-3-10-enum-unnamed-values',
           'E8-3-10-enum-declaration-form', 'E8-3-1-value-type-categories', 'E8-3-1-nonnullable-form-enum',
           'E8-3-1-enum-form-name', 'E8-3-3-enum-default']
    statements = f'        Code low = (Code)({low}); Code high = (Code)({high}); Code empty = new Code();\n'
    checks = [(f'({typ})low == {low} && ({typ})high == {high}', 'enum-' + typ + '-full-domain'),
              ('empty == (Code)0', 'enum-' + typ + '-default')]
    emit(ids, 'generated-enum-' + typ, checks, declarations=f'enum Code : {typ} {{ Marker = 1 }}\n', statements=statements)
for typ in ['char', 'bool', 'float', 'double', 'decimal', 'string']:
    emit(['E8-3-10-enum-underlying-type-restriction'], 'generated-' + typ, [], reject=f'enum Code : {typ} {{ Marker }}\nclass Program {{ static void Main() {{ }} }}\n')

buf = io.StringIO(newline='')
index = normalize_case_rows(root, index)
writer = csv.DictWriter(buf, ['test_id', 'case_id', 'rule_ids', 'prerequisites', 'checks'], delimiter='\t', lineterminator='\n')
writer.writeheader()
writer.writerows(index)
destination = root / (base + '/generators/numeric-matrix.cases.tsv')
destination.parent.mkdir(parents=True, exist_ok=True)
destination.write_text(buf.getvalue(), encoding='ascii', newline='\n')
