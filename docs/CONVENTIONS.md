# Test contract

This page is the contract that every test, rule and ledger entry follows. Read
it before you add or review a rule, a test program, a generator or a departure
record.

## Sources and authority

Tests are written clean-room from a registered standard or feature
specification. Clean-room means that you write each test from its rule and the
rule's registered sources, without copying or adapting examples or tests from
the standard, compilers or other suites. A registered source is one that the
standard's `source-registry.json` pins (see
[The standard directory](ARCHITECTURE.md#the-standard-directory)).

- Never copy or adapt another compiler's tests, another suite's tests, or the
  standard's examples.
- Use short, unchanged quotations to identify predicates. A predicate is one
  testable rule taken from the source's text; see [Rule ledgers](#rule-ledgers).
- Comments cite subclauses and printed pages, with PDF pages where useful, or
  a committee markdown file at its pinned commit. One such file is
  `proposals/csharp-9.0/native-integers.md` in the registered `csharplang`
  reference.
- Secondary references explain interpretation; they do not replace the
  primary authority.
- Do not include full standards or text extracts.

When sources disagree or are unclear:

- Where a standard and csc disagree, the standard wins, and the disagreement
  is a recorded departure (see [Departures](#departures)).
- Where literal wording is evidently mistaken, test its intended meaning.
  Explain the interpretation in a source comment with registered evidence.
- For later features not yet covered by an ECMA edition, the registered pinned
  csc is the authority, and feature specifications supply the rule text.

## Names and ledger ownership

### Names and IDs

| Item | Form | Example |
| --- | --- | --- |
| Standard directory | `ecma-<number>` | `ecma-334` |
| Clause directory | `<NN>-<slug>` | `10-conversions` |
| Rule ID | `E<clause>[-<subclause>...]-<predicate-slug>` | `E10-1-representation` |
| Later-feature rule ID | `P<version>-<predicate-slug>` | `P09-native-sbyte-nint` |
| Later-feature rule ID, preview | `Ppreview-<predicate-slug>` | `Ppreview-unsafe-preview-delegate-context` |
| Test file | `clauses/<clause>/tests/<primary-rule-id>/<file-stem>.cs` | `clauses/10-conversions/tests/E10-1-representation/implicit-long.cs` |
| Test ID | `<clause>--<primary-rule-id>--<file-stem>` | `10-conversions--E10-1-representation--implicit-long` |

Slugs are lowercase words separated by hyphens.

Rules:

- Each rule has one meaning and one owning ledger.
- Retire an obsolete ID with its reason. Never reuse it for another meaning.

Tests:

- A test's first rule ID is its primary rule. The test lives in the clause
  that owns its primary rule. Extra rule IDs express additional coverage.
- Preserve IDs and relative paths when the meaning remains stable.
- Fixture and witness files end in `.cs.part` and cannot silently become
  standalone tests.
- A generator lives in a clause's `generators/` folder, but the tests it
  writes may belong to other clauses. For example,
  `clauses/10-conversions/generators/standard-matrices.py` also writes tests
  in `12-expressions`.

### Rule ledgers

Each clause keeps a ledger: tab-separated (TSV) files in the clause directory
that record the clause's rules and how they are covered.

| File | Contents |
| --- | --- |
| `rules.tsv` | The predicates, each with an exact quotation in `quote_json`. |
| `coverage.tsv` | A map from each inventoried text block to rules, or to an explained disposition. |
| `untested.tsv` | The reason for each rule that has no test. |
| `retired-rules.tsv` | Optional. Retired rules: each row has the columns of `rules.tsv` plus a `retirement_reason`. |
| `version-witnesses.tsv` | Optional; today only `10-conversions` has one. It pairs later-feature rules with an existing test that serves as a positive witness, and records the language version before the rule's version (`previous_version`), a `mode` (`feature-unavailable`, `predecessor-rejection` or `accepted-predecessor`) and a `reason` that cites the source. No published tool reads it. |

For example, the rule `E10-1-representation` in
`clauses/10-conversions/rules.tsv` quotes "change in representation" from
subclause 10.1 (printed page 117, PDF page 145).

A text block is a piece of the standard's text that the inventory tracks, such
as the block `10.1:p1`. A block's disposition says how it is covered: `rules`
when the block maps directly to rules, `covered-by` when it points to existing
rules, or a reason why it needs no rule, for example because it is a note or
an example.

- Every rule has a test or an `untested.tsv` reason.
- A `covered-by` disposition points to existing rules.
- Retired rules are recorded separately, in `retired-rules.tsv`. The ledger
  audit, which `check-ledger.py` and `check-publishing.py` run, requires a
  reason for each retired ID. It rejects a retired ID that is listed twice or
  reused by an active rule, a test, a coverage row or an `untested.tsv` entry,
  and it checks a retired rule's quotation like an active one's.
- `ledger-scope.json` declares available and partial scope, and its text-block
  inventory. Never infer behavioral completeness from that inventory.
- `manifest.tsv`, `versions/index.json` and its clause/bucket shards are
  generated, not hand edited. The stable placement and hash contracts are
  documented in [Architecture](ARCHITECTURE.md), under
  [The manifest](ARCHITECTURE.md#the-manifest) and
  [Version data](ARCHITECTURE.md#version-data).

## Headers

Every test file starts with a header: a C# block comment that holds the test's
metadata. Its bytes are, in order:

1. `/*` and an LF;
2. the metadata lines, each written as `Key: value`;
3. an LF, `*/` and an LF.

Each key occurs once, in the order of the table below. Omit the optional keys
that do not apply.

Here is a complete handwritten test,
[implicit-long.cs](../ecma-334/clauses/10-conversions/tests/E10-1-representation/implicit-long.cs):

```csharp
/*
Rules: E10-1-representation; E10-1-type-wide; E10-2-3-int; E10-2-3-exact
Authority: ECMA-334 7th ed 10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: long result = input;
Into: long result = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int input = -197;
        long result = input;
        Check(result == -197L, "implicit-long/value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
```

The header keys, in their required order:

| Key | Required | Contract |
| --- | --- | --- |
| `Rules` | Yes | Existing IDs separated by `; `, primary first. |
| `Authority` | Yes | Registered standard edition and subclause, or the registered csc feature authority. See [Authority and Version](#authority-and-version). |
| `Version` | Yes | Default language level for a run. It does not claim the feature's earliest level. |
| `Expected` | Yes | `run` or `reject`. |
| `Stdout` | For `run` | `OK <count>`; execution must append exactly one LF. Omit it for `reject`. |
| `Diagnostic` | No | Only on `run`: `warning` requires a program warning; `none` forbids one. |
| `Requirements` | No | Neutral names separated by `; `: `unsafe-disabled` or `updated-memory-safety`. |
| `Fixture` | No | Compact JSON compilation graph, arguments and target capabilities. See [Fixtures](#fixtures). |
| `Source-Diagnostic` | No | Compact JSON array of required source locations and literal directive payloads. See [Source diagnostics](#source-diagnostics). |
| `Version-Witness` | For departures | Clause-relative positive `.cs.part` construct for a confirmed departure. See [Departures](#departures). |
| `Generated` | For generated tests | The generator's path, relative to the standard's directory, such as `clauses/06-lexical-structure/generators/line-locations.py`. It replaces the mutation keys. |
| `Mutate` | For handwritten tests | The handwritten test's exact body text to replace once. See [Causal mutations](#causal-mutations). |
| `Into` | For handwritten tests | Replacement text, distinct from `Mutate`. It may be empty. |
| `Csc` | No | Only on `reject`: informational `CSdddd` codes separated by `; `, audited on the original at `Version`. |

Notes on the table:

- A neutral requirement name belongs to no single compiler. Each compiler
  configuration maps the names it supports to its own switches; a name
  without a mapping gives an `unsupported` result.
- `Csc` codes are information only; [Results](RESULTS.md#result-rows) explains
  how they are used.
- Unknown keys, invalid order and ambiguous mutation replacements are errors.

### Authority and Version

An `Authority` header takes one of two forms:

| Authority | Form | Example | Its `Version` |
| --- | --- | --- | --- |
| A standard edition | The edition's registered prefix, followed by the primary subclause | `ECMA-334 7th ed 10.8` | The edition's registered language level (`7.3` for the 7th edition) |
| A later feature | `csc <version> (C# <level>)`, matching the source registry and the test's `Version` | `csc 5.11.0-1.26425.128 (C# 9.0)` | `<level>` |

These headers are defaults for a run, not claims about the earliest version in
which a construct applies. `Since` and `Until` are not header keys: they
belong in source-keyed generated metadata (see [Bounds](#bounds)). A source
edit, fixture edit, witness edit or measurement-identity change requires new
bounds.

### Language level spellings

Language spellings are case-insensitive. The accepted spellings are:

- `ISO-1` or `1`, and `ISO-2` or `2`;
- `3` through `6`;
- `7` or `7.0`, then `7.1`, `7.2` and `7.3`;
- `8` or `8.0` through `15` or `15.0`;
- the symbolic names `default`, `latest`, `latestMajor` and `preview`.

Configurations declare which levels they support, and they resolve the
symbolic names. `--langversion all` is a selection directive, not a level: it
selects every supported explicit level, and `preview` where the configuration
supports it. No `-subset` spellings are accepted.

## Programs and causal changes

### Keep programs small

- Use only the library surface needed for the predicate. Programs are
  intended to run on small runtimes and microcontrollers.
- Avoid culture-dependent formatting, unnecessary LINQ and reflection.
- Isolate unrelated prerequisites.
- Bound generated programs to at most 16 cases that share the same
  prerequisites, and record their case maps. A case map is the
  `<generator>.cases.tsv` file beside a generator that lists each generated
  program's cases, such as
  `clauses/10-conversions/generators/sample-matrix.cases.tsv`.
- Keep negative tests (tests whose `Expected` is `reject`) focused on one
  forbidden construct, so that unrelated errors cannot satisfy them.

### What to check

- Check values, evaluation order, identity and exception behavior.
- For unspecified or implementation-defined rules, accept every permitted
  result, and reject only results outside the allowed set.
- Use typed catch clauses for exception checks. Require the exact runtime type
  only where the rule requires it.
- Compare floating point bit patterns where a rule fixes them.

### Counted checks

A run test passes only when it exits with code 0 and prints exactly the
`OK <count>` line its `Stdout` header declares. Count each check, and print
that line only when every check succeeds.

Run tests accumulate counted checks and failures:

1. Each `Check` call names a stable case, such as `implicit-long/value`.
2. Every check increments `checks`.
3. A failed check increments `failures` and prints `FAIL <case>`, without
   stopping later checks.

Diagnostic-only programs may use `OK 0`. Expected stdout must be
deterministic.

### Causal mutations

A handwritten test's mutation changes the predicate's cause. The runner
replaces the `Mutate` text, which must occur exactly once in the body, with
the `Into` text. The changed program is the mutant; a reject test's mutant is
its repair. In the example above, `Into: long result = 0;` removes the
implicit conversion from `input`, so the check `implicit-long/value` fails.

A mutation shows the test's sensitivity: that its outcome depends on the
predicate's cause.

- A reject repair must compile.
- A run mutant must fail a relevant check.
- A warning mutant must compile with warning presence toggled.
- A mutant that is `unsupported`, or that hits a `compiler-error` or
  `infrastructure` result, is inconclusive.
- When the original passes, `runner/tools/check-mutations.py` marks a run
  test's mutant `killed` on any runtime failure, timeouts and unhandled
  exceptions included, on a diagnostic failure, and on a rejection with a
  coded error. Such a kill is not, on its own, proof of causal sensitivity,
  and review must not accept it as proof.

For warning tests (tests with a `Diagnostic` header):

- Warning tests compile free of unrelated warnings.
- A particular warning code may be documented as information, but it cannot
  be required.
- Do not use warning-as-error flags as an oracle, that is, as the check that
  decides whether a test passed.

[Mutation results](RESULTS.md#mutation-results) lists what the mutation check
reports.

## Fixtures and source locations

### Fixtures

A fixture describes how to build and run a test. Without one, the test file
alone is compiled into one program. A fixture can declare libraries to compile
before the program, the source units and references of each library and of the
program, an entry point, arguments for the program and the target capabilities
the test requires. The optional `Fixture` header holds it as compact JSON,
with these keys:

| Key | Contract |
| --- | --- |
| `libraries` | Libraries with distinct names. They compile before the program. |
| `program` | The main program. It may specify `entry_point`. |
| `arguments` | Literal strings passed to the program. |
| `target_requires` | Required target capabilities, which include `framework-runtime` and `process-launch`. |

Inside `libraries` and `program`:

- Units have `source: self` or a clause-relative `.cs.part`, with optional
  identifier `defines`. A unit is one source file of a library or of the
  program, and `self` is the test file itself.
- References name an earlier `library` or a target `asset`, with an optional
  `alias`.

A missing compiler mapping or target capability is unsupported: the result is
`unsupported` (see [Unsupported reasons](RESULTS.md#unsupported-reasons)).

For example, one source can contain a conditional library and its caller:

```json
{"libraries":[{"name":"Fixture","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"Fixture"}]}}
```

The test `07-basic-concepts--E7-1-library-compilation--library-without-main`
uses this fixture. An extern alias adds `"alias":"Vendor"` to that reference.

How the runner uses a fixture:

- The runner prepends `#define` lines per unit, and applies the causal
  mutation to each `self` unit.
- Units receiving defines cannot be inventoried raw source or declare source
  diagnostic checks.
- Compile options belong in neutral requirements, not in sources or in
  per-test compiler switches.

### Source diagnostics

The optional `Source-Diagnostic` header lists diagnostics that the compiler
must report at given source locations. Each entry names:

| Field | Contract |
| --- | --- |
| `case_id` | The case. |
| `source` | One unique, complete body line. |
| `severity` | `error` or `warning`. |
| `file` | `physical`, or the rule's logical file. |
| `line` | `physical`, or the rule's logical line, a positive number. |
| `contains` | Optional. Only a literal `#error` or `#warning` payload. |

`physical` means the file or line where the `source` line actually is. For
example, the test
`06-lexical-structure--E6-5-8-grammar-pp-line-indicator-2--number-only-one-alpha-warning`
has this header line:

```text
Source-Diagnostic: [{"case_id":"number-only-one-alpha-warning","source":"#warning diagnostic-number-only-one-alpha-warning","severity":"warning","file":"alpha.origin","line":1,"contains":"diagnostic-number-only-one-alpha-warning"}]
```

The test's `#line` directives make `alpha.origin`, line 1, the logical
location of its `#warning` line.

- The suite checks missing locations and payloads as diagnostic failures.
- Physical C# line counting treats CRLF as one terminator and includes the
  language's Unicode terminators. Header parsing splits only on LF.
- Compiler message wording is never a test oracle.

## Bytes, departures and bounds

### Bytes and raw source

Normal text is ASCII with LF line ends, a final LF and no source tabs.

Raw source is a test file whose rule needs bytes that normal text forbids.
For example, `clauses/06-lexical-structure/tests/E6-1-utf8/four-byte.cs`
contains a four-byte UTF-8 character. Every raw-source exception must be:

1. inventoried in `raw-source.tsv`;
2. hashed;
3. justified by a registered rule (one that `source-registry.json` lists for
   raw source);
4. marked `-text` in `.gitattributes`.

Tools preserve the bytes of raw source. Only raw source uses `\xNN` mutation
decoding: in its `Mutate` and `Into` headers, `\xNN` stands for the byte with
the hexadecimal value `NN`. The verbatim legal block in `NOTICE` is also
preserved without text conversion.

### Departures

A departure is a recorded disagreement between the standard and the pinned
compiler or the hosted runtime that runs the programs. Departure records live
in the clause's `departures.tsv`. Each record holds:

- the kind: `compiler` or `hosted-runtime`;
- the exact source hash;
- the registered quotation;
- the compiler commit;
- the target;
- the levels;
- the observed behavior.

Explain the disagreement in neutral words.

- Confirmed records mark observed failures; pending ones prevent publishing.
- The `Version-Witness` file is a positive construct witness: it uses the
  construct in a valid way. It permits version measurement without claiming
  that the departure passed.
- Later conformity can end the mark with `conforms_since`.

For example, `10-conversions--E10-8-null-instance--null-receiver` is a
confirmed `compiler` departure. The standard requires a
`System.NullReferenceException` when a method group conversion has a null
target object. With the pinned csc, the program observes a
`System.ArgumentException` instead. Its witness is
`version-witnesses/null-receiver-6112aacd1c.cs.part`.

### Bounds

The bounds of a test are `Since` and `Until`: the lowest and the highest
language level of the contiguous passing interval that contains its
`Version`. `Until` is recorded only when that interval ends below the highest
measured level. Bounds are measured, not written by hand, and stored as
generated version data (see [Version data](ARCHITECTURE.md#version-data)).

- Any other passing levels are listed separately and are not applicable.
- Framework tests, the tests that require `framework-runtime`, run on
  `net481` for their original bounds.
- The predecessor, the level just below `Since`, records either a refusal or
  a meaning change.
- A refusal below `Since` requires rejection of the positive construct in an
  explicit-level run.
- Keep the measurement method and independent sample evidence with the
  generated metadata.

The basis names the program whose outcome at each level decides the bounds:

| Test | Basis |
| --- | --- |
| Ordinary run test | `original` |
| Reject test | `repair` |
| Generated reject test without a repair | `feature-free-rejection` |
| Departure | `departure-witness` |

With the `repair` basis, the test passes at a level only when the original is
also rejected there.

For example, the reject test
`11-patterns--E11-2-2-incompatible-types--sealed-unrelated` has the basis
`repair`. Its `Since` is 7, and its predecessor, level 6, records a refusal.
[Version data](ARCHITECTURE.md#how-the-files-are-named) walks through this
row.
