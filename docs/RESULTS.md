# Results

This page explains how to read the output of a run: result rows, result
categories, verdicts, summaries, departures and mutation results. Read it
before you interpret a failure.

## Result rows

A run writes one row to `results.tsv` for each combination of standard, test,
resolved language level and check mode. The check mode says how the test was
checked at that level. For example, it ran as an ordinary test or as a
version-gating check (see
[Explicit language levels](#explicit-language-levels)).

Each row records:

- both the declared and the executed source hashes;
- the compiler diagnostic codes;
- the failed checks;
- the target observations;
- any confirmed departure annotation (see [Departures](#departures)).

`Csc:` headers are information about the pinned csc at the original source's
`Version`. They never select an outcome, and they never require another
compiler to emit the same code.

## Result categories

Every row has one of these fixed categories:

| Category | Meaning |
| --- | --- |
| `pass` | The required outcome was observed: the required rejection, a successful execution, or the refusal that a version-gating check requires. Declared diagnostic obligations were met as well. |
| `unsupported` | The compiler or target cannot provide a required feature, level, requirement or capability. |
| `unexpected-reject` | A program required to compile was rejected, an ordinary test's fixture prerequisite was rejected, or a rejection had no coded source error. |
| `unexpected-accept` | A program required to be rejected was accepted. |
| `runtime-fail` | An accepted program produced wrong output, a nonzero exit, an unhandled exception or a timeout. |
| `diagnostic-fail` | A declared diagnostic check failed: warning presence or absence, or a source diagnostic's location or payload. Source checks also apply to required rejections. |
| `compiler-error` | The compiler crashed, timed out, failed to produce an artifact or supplied no valid verdict. |
| `infrastructure` | The invocation produced a configured command-line error, or the target could not launch the program. Such a run needs repair before its counts establish results. |
| `not-applicable` | The test lies outside its measured interval and does not require a gating check at this level, or a required fixture library was refused below `Since`. |

These categories are a versioned public contract. Adding or changing one
requires a documented version change of the
[result schema](../configs/schemas/result.schema.json), rather than a
compiler-specific alias.

Ordinary tests require every fixture library to compile; refusal of a
prerequisite does not establish the program's outcome.

### Unsupported reasons

An `unsupported` row also records one of these reasons:

| Reason | Meaning |
| --- | --- |
| `feature-refusal` | At least one configured feature-refusal error was reported. Other errors are preserved too. |
| `level` | The compiler configuration does not support this test's header level. |
| `requirement` | A declared requirement or compilation operation has no compiler mapping. |
| `target-capability` | The target lacks a declared runtime capability or reference asset. |

## How verdicts are decided

A configured error is one whose diagnostic code the compiler configuration
lists (see [Configurations](ARCHITECTURE.md#configurations)). A coded error is
a diagnostic that carries a code, such as `CS1012`.

When the compiler reports errors:

1. Any configured command-line error takes precedence over source verdicts.
2. Any configured feature-refusal error makes a coded source rejection
   `unsupported`, even if a rejection was expected or other source errors were
   also present.
3. A rejection without a coded source error cannot prove a required
   rejection.

Diagnostic codes and messages remain in the evidence regardless of category.
The evidence is the saved record of each attempt (see
[Evidence](ARCHITECTURE.md#evidence)).

When the program runs:

- Required stdout matches exactly, including its final LF.
- Runtime-fail reasons distinguish output mismatch, nonzero exit, unhandled
  exception and timeout.
- Target launch errors are `infrastructure`.
- `FAIL <case>` lines are retained even when the process later fails.

Source diagnostic checks use the test's declared location and any permitted
literal directive payload, not compiler-specific wording.

## Explicit language levels

Every version run names `--langversion`. It accepts one or more levels, an
inclusive range such as `5..7.3`, `all`, or `earliest-per-test`, which runs each
test at the first level of its measured range. Without a selector the invocation
stops before loading tests or creating results. Version runs exclude every test
whose authority is a non-latest standard edition.

An explicitly requested unsupported level aborts the
invocation. At supported explicit levels, the test's measured bounds, `Since`
and `Until` (see [Bounds](CONVENTIONS.md#bounds)), decide what happens:

| Requested level | What happens |
| --- | --- |
| From `Since` through `Until`, inclusive | The test runs as an ordinary test. |
| Below `Since`, where the measurement found a refusal | A version-gating check of the positive construct runs. |
| Below `Since`, where a required fixture library is itself refused | The test is `not-applicable`. |
| Below `Since`, where the measurement found a meaning change | The test is `not-applicable`. |
| Above `Until` | The test is `not-applicable`. |
| A recorded disconnected passing level | The test is `not-applicable`. |

A version-gating check passes when the compiler refuses the positive
construct. A disconnected passing level is a level where the test also
passed, outside the interval that contains its `Version`.

## Edition runs

`--edition N` chooses a registered non-latest edition and its registered
language level. It cannot be combined with `--langversion`. The compiler must
support that level, and all candidate tests need current bounds.

- Every test with the requested edition's authority runs as an ordinary test
  at the edition's level, even if its measured interval differs.
- Other tests run by continuity when their current measured interval contains
  that level.
- The edition's conflict table excludes tests that it replaces or leaves out.

Tests outside the interval or excluded by the table have no result rows and
produce no version-gating checks. `run.json` records the candidate inventory,
the table's path and hash, and the test IDs included or excluded for each
reason. `run.json` and both summaries name the edition and resolved level.

## Summaries and run records

`summary.json` and `summary.md` group the results by standard, level and
clause. Each group reports all rows, every category, departures and
unsupported reasons, and this count:

`applicable = all - unsupported - not-applicable - infrastructure`

This is an accounting denominator, not a claim that every rule is covered.
Clause scope and in-progress markers come from `ledger-scope.json`.

`run.json` records:

- the exact command;
- the suite and compiler commits;
- the pinned assets;
- the target identity;
- the controls;
- the selected inventory;
- the edition, its language level and its conflict-table selection, when used;
- the completion state;
- the version-row states.

A void or incomplete run does not establish a complete result. A run is void
when a control fails (see [Controls](ARCHITECTURE.md#controls)). Inspect
`results.tsv` and its per-attempt evidence before you interpret a failure.

## Departures

A departure is a recorded disagreement between the standard and the pinned
compiler or the hosted runtime (see [Departures](CONVENTIONS.md#departures)).

- A confirmed departure remains a failure, with `departure` and
  `departure_kind` set in its row.
- `compiler` names a compiler disagreement; `hosted-runtime` names a
  disagreement caused by runtime behavior.
- Marks apply only to the recorded compiler, target, source and levels.
- A later conforming level can end a mark without excluding a still-valid
  test.
- Pending departure records fail the publishing gate.

## Mutation results

`runner/tools/check-mutations.py` checks each handwritten test's causal
mutation (see [Causal mutations](CONVENTIONS.md#causal-mutations)). Each test
gets one of these results:

| Result | Meaning |
| --- | --- |
| `killed` | The mutant changed the outcome. Runtime or diagnostic failure can kill a run test's mutant. A warning test's mutant must compile with the warning cause toggled. |
| `repaired` | A reject test's repair compiled. Successful repair compilation proves a reject test's causal change. |
| `survived` | The mutation did not change the outcome as required. |
| `inconclusive-departure` | The test is a confirmed departure. Confirmed departures always remain inconclusive with that compiler. |
| `inconclusive-unsupported` | The original test was `unsupported`. |
| `inconclusive-original` | The original test did not pass. |
| `inconclusive-mutant` | The mutant gave no usable verdict: it was `unsupported` or hit an `infrastructure` or `compiler-error` result. A run test's mutant that was rejected without a coded error is also inconclusive; for a reject or warning test, that rejection gives `survived`. |

Feature refusals and uncoded rejections never kill a mutant; the table above
gives their results. But when the original passes, `check-mutations.py` marks
a run test's mutant `killed` on any runtime failure, timeouts and unhandled
exceptions included, on a diagnostic failure, and on a rejection with a coded
error. Such a kill is not, on its own, proof of causal sensitivity, and review
must not accept it as proof. Generated tests have no individual mutation
claim.

## Coverage and comparisons

- An untested reason, a secondary reference note or a target limitation is a
  coverage finding, not a pass.
- Text-block inventories establish bookkeeping coverage and never complete
  behavioral coverage.
- Tests can miss implementation bugs even when every recorded case and
  mutation behaves as intended.
- Compare only results whose scope, language resolution, compiler, target and
  source identities are stated.
