"""Tuple representation boundaries, with a separate program for each arity."""
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
generator = base + '/generators/tuple-arities.py'
index = []
for arity in [2, 3, 4, 5, 6, 7, 8, 9, 15, 16, 23]:
    if arity <= 7:
        ids = ['E8-3-11-tuple-direct-arities']
    else:
        ids = ['E8-3-11-large-tuple-rest-representation', 'E8-3-11-tuple-matching-arity-not-required',
               'E8-3-11-tuple-nesting-observability']
        if arity == 8:
            ids.append('E8-3-11-tuple-single-rest-representation')
        if arity > 14:
            ids.append('E8-3-11-tuple-recursive-rest')
    ids += ['E8-3-11-tuple-valuetuple-shorthand']
    primary = ids[0]
    name = f'generated-arity-{arity}'
    test_id = f'08-types--{primary}--{name}'
    path = f'{base}/tests/{primary}/{name}.cs'
    checks = [(f'tuple.Item1 == 11 && tuple.Item{arity} == {arity + 10}', f'arity-{arity}-ordered-fields')]
    statements = '        var tuple = (' + ', '.join(str(i + 10) for i in range(1, arity + 1)) + ');\n'
    if arity <= 7:
        statements += '        System.ValueTuple<' + ', '.join(['int'] * arity) + '> raw = tuple;\n'
        checks.append((f'raw.Item{arity} == {arity + 10}', f'arity-{arity}-direct-valuetuple'))
    else:
        remaining = arity
        rest = 'tuple'
        while remaining > 7:
            rest += '.Rest'
            remaining -= 7
        checks.append((f'{rest}.Item{remaining} == {arity + 10}', f'arity-{arity}-nested-rest'))
        if arity == 8:
            statements += '        System.ValueTuple<int> tail = tuple.Rest;\n'
            checks.append(('tail.Item1 == 18', 'arity-8-single-value-rest'))
    header = f'/*\nRules: {"; ".join(ids)}\nAuthority: ECMA-334 7th ed 8.3.11\nVersion: 7.3\nExpected: run\nStdout: OK {len(checks)}\nGenerated: {generator}\n*/\n'
    body = 'using System;\nclass Program\n{\n    static int checks, failures;\n'
    body += '    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }\n'
    body += '    static void Main()\n    {\n' + statements
    for expression, case in checks:
        body += f'        Check({expression}, "{case}");\n'
        index.append({'test_id': test_id, 'case_id': case, 'rule_ids': ';'.join(ids), 'prerequisites': f'tuple-arity-{arity}'})
    body += '        if (failures == 0) Console.WriteLine("OK " + checks);\n    }\n}\n'
    destination = root / path
    destination.parent.mkdir(parents=True, exist_ok=True)
    destination.write_text(header + body, encoding='ascii', newline='\n')
buf = io.StringIO(newline='')
index = normalize_case_rows(root, index)
writer = csv.DictWriter(buf, ['test_id', 'case_id', 'rule_ids', 'prerequisites', 'checks'], delimiter='\t', lineterminator='\n')
writer.writeheader()
writer.writerows(index)
destination = root / (base + '/generators/tuple-arities.cases.tsv')
destination.parent.mkdir(parents=True, exist_ok=True)
destination.write_text(buf.getvalue(), encoding='ascii', newline='\n')
