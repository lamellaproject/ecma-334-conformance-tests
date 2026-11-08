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

- the declared source hash and, when execution applies, the executed hash;
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
| `pass` | A declared outcome was observed: a required or permitted rejection, a successful execution, or the refusal that a version-gating check requires. Declared diagnostic obligations were met as well. |
| `unsupported` | The compiler or target cannot provide a required feature, level, requirement or capability. |
| `unexpected-reject` | A program required to compile was rejected, an ordinary test's fixture prerequisite was rejected, or a rejection had no coded source error. |
| `unexpected-accept` | A program required to be rejected was accepted. |
| `runtime-fail` | An accepted program produced wrong output, a nonzero exit, an unhandled exception or a timeout. |
| `diagnostic-fail` | A declared diagnostic check failed: warning presence or absence, or a source diagnostic's location or payload. Source checks also apply to required rejections. |
| `compiler-error` | The compiler crashed, timed out, failed to produce an artifact or supplied no valid verdict. |
| `infrastructure` | The invocation produced a configured command-line error, or the target could not launch the program. Such a run needs repair before its counts establish results. |
| `not-applicable` | The test lies outside its measured interval and does not require a gating check at this level, or a required fixture library was refused below `Since`. |
| `superseded` | The governing ISO edition changes this older edition's requirement. Both clauses, short quotation spans and printed/PDF pages are recorded. The claim has no execution and is neither a pass nor a failure. |

These categories are a versioned public contract. Adding or changing one
requires a documented version change of the
[result schema](../configs/schemas/result.schema.json), rather than a
compiler-specific alias.

Ordinary tests require every fixture library to compile; refusal of a
prerequisite does not establish the program's outcome.

For `Expected: run-or-reject`, source rule 6 leaves the compilation outcome
unresolved. A valid program-stage rejection passes with reason
`permitted-rejection`. If accepted, the program must execute with its declared
counted output. This permission does not cover unsupported capabilities,
compiler failures, fixture failures or runtime failures. Its positive version
witness supplies the construct used for bounds and version-gating checks.

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
inclusive range such as `5..7.3`, `all`, or `earliest-per-test`. The last
selector starts each eligible test at the first level of its measured range,
then applies the ISO tables as described below. Without a selector the invocation
stops before loading tests or creating results. A plan resolving to ISO-1 or
ISO-2 uses the governing edition table, as described in [Edition runs](#edition-runs).
At other levels, measured version runs exclude tests whose authority is an
older standard edition.

An explicitly requested unsupported level aborts the
invocation. At supported explicit levels outside the governing ISO plans,
the test's measured bounds, `Since` and `Until` (see
[Bounds](CONVENTIONS.md#bounds)), decide what happens. At ISO-1 and ISO-2,
the governing table selects claims first. An unlisted test outside that selection
gets a positive version-gating check when it is below `Since` and the reference
measurement records a coded refusal of the measured positive source at the
requested level. Own-authority claims and cited replacement
admissions retain their ordinary expectations. Superseded, replaced and
left-out tests produce no version-gating check.

| Requested level | What happens |
| --- | --- |
| From `Since` through `Until`, inclusive | The test runs as an ordinary test. |
| Below `Since`, where that level's positive observation records a coded refusal | A version-gating check of the same positive source runs. |
| Below `Since`, where a required fixture library is itself refused | The test is `not-applicable`. |
| Below `Since`, where the measurement found a meaning change | The test is `not-applicable`. |
| Above `Until` | The test is `not-applicable`. |
| A recorded disconnected passing level | The test is `not-applicable`. |

The predecessor observation describes only the level just below `Since`.
Each requested level uses its own observation. A generated reject with the
`feature-free-rejection` basis has no positive source and produces no
version-gating check. A refused positive source must have a parsed error code;
capability and invocation failures do not establish refusal.

A version-gating check passes when the compiler refuses the positive
construct. A disconnected passing level is a level where the test also
passed, outside the interval that contains its `Version`.

## Edition runs

`--edition N` runs the ECMA-334 Nth edition at its registered language level:
the 1st and 2nd editions at ISO-1, and the 3rd and 4th editions at ISO-2. It
cannot be combined with `--langversion`. The compiler must support that level,
and all candidate tests need current bounds.

An edition run tests that edition and no other:

- Every test with the edition's authority runs at the edition's level, even if
  its measured interval differs.
- A test with another authority runs only for a rule the edition shares, as the
  edition's own conflict table admits it: by continuity when its current
  measured interval contains that level, or as an explicitly cited older
  replacement.
- A test of a rule the edition does not have never runs in that edition's run.
- The edition's conflict table excludes the tests it replaces or leaves out.

The source registry assigns one governing edition to each ISO level: the 2nd
edition to ISO-1 and the 4th edition to ISO-2. Where the governing edition
changed a rule, an older edition's test of that rule is reported as
`superseded`, counted separately from passes and failures.

`--edition 2` and `--edition 4` are the claim runs for ISO-1 and ISO-2. An ISO
conformance claim names both its edition claim run and its explicit-level run:
`--edition 2` and `--langversion 1`, or `--edition 4` and `--langversion 2`.
The claim run checks the edition's rules; the explicit-level run also checks
refusal of newer constructs using their positive witnesses. Edition selection
metadata records the edition, its level and whether it is the level's claim run.

A language plan that resolves to an ISO level uses that level's governing
table (the 2nd edition's at ISO-1, the 4th edition's at ISO-2), including
`earliest-per-test` and header-level plans.

For `earliest-per-test`, a cited replacement runs at the ISO level of the test
it replaces. If its own earliest plan survives the governing tables at another
level, the run also records that plan. Both tests must belong to the candidate
selection; each test has at most one plan per level. A test whose initial
plan is replaced or left out can have no ordinary result row. A replacement
can have rows at different levels when both its own earliest plan and the
cited ISO plan survive.

A `leave-out` row with a `superseded` object preserves the older test as a
result row with status and mode `superseded`, even outside its measured
interval. The object contains `test` and `level` citation arrays: the older
test's requirement and the governing edition's changed requirement. Each
citation has the registered source, clause, a quotation of at most 30 words,
and printed/PDF pages. The quotation comparison follows
[Sources and authority](CONVENTIONS.md#sources-and-authority). The result,
`run.json`, `summary.json` and `summary.md` retain both
sets. No source is compiled or run, no departure is counted, and no
version-gating check is produced. An unchanged older requirement remains an
ordinary test when selected.

A `replace` row targets another registered edition's test. An ordinary
`leave-out` row can also target a test with the registry's pinned compiler
authority. The cited edition's text must justify excluding the program's
assertion or setup syntax from that level's claims. The excluded test produces
no result row or version-gating check. Compiler acceptance alone does not
admit an ISO claim. Supersession retains its older standard-authority requirement.

A replacement belongs to the requested edition or to another registered older edition.
For a target in the candidate selection, a cited `replace` row admits its
older replacement outside the replacement's measured interval when the
cited text requires its expected result at the requested level. It runs as
an ordinary test at that level, with unchanged measured bounds. It must be
selected, must not itself be excluded, and must form no cycle. Each row cites
the table edition's clause and printed/PDF pages. Table dispositions are
data with source citations; compiler verdicts do not change them. Measured
intervals decide continuity for tests without a table disposition and identify
positive constructs that need refusal checks. A contradictory compiler result
for an active edition requirement remains a confirmed departure failure citing
the table edition, never a pass.

In an edition run, tests outside the interval without own-authority selection,
a cited replacement admission or a superseded marker have no result rows.
Other tests excluded by the table also have no result rows. Edition runs
produce no version-gating checks. Explicit-level runs at 1 and 2 add the
unlisted below-`Since` refusal checks described above and record their IDs as
`version_gating_test_ids`. `run.json` records the candidate inventory,
the table's path and hash, and the test IDs included or excluded for each
reason, including outside-interval replacement admissions.
`run.json` and both summaries name the edition and resolved level. Language
plans also record their governing edition selections.

### Header checks

`--langversion declared-per-test` resolves each header `Version` and applies
the governing ISO table without requiring current bounds. Superseded claims
produce static rows; other table exclusions produce no row. `check-csc.py`
validates the cited superseded evidence without checking that claim's `Csc`
diagnostic codes. Raw certification observes every source at every configured
level, including superseded ones.

## Summaries and run records

`summary.json` and `summary.md` group the results by standard, level and
clause. Each group reports all rows, every category, departures and
unsupported reasons, and this count:

`applicable = all - unsupported - not-applicable - infrastructure - superseded`

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

An older-edition expectation can disagree with the raw observation while the
compiler conforms to the governing ISO edition. Such evidence belongs in the
clause's `superseded-observations.tsv`, with status `conforming`. Its source,
quotation and raw verdict describe the older expectation; the governing
table's `superseded` object identifies the changed rule at each listed level
with both editions' citations. The observation can support a measurement
witness, but cannot set `departure` or count as a confirmed departure. A claim
run reports the cited `superseded` outcome without execution. The ledger
check rejects a departure at a table-superseded level.

## Mutation results

`runner/tools/check-mutations.py` checks each selected handwritten claim's causal
mutation (see [Causal mutations](CONVENTIONS.md#causal-mutations)). Each test
gets one of these results:

| Result | Meaning |
| --- | --- |
| `killed` | The mutant changed the outcome. Runtime or diagnostic failure can kill a run test's mutant. A warning test's mutant must compile with the warning cause toggled. |
| `repaired` | A reject test's repair compiled. Successful repair compilation proves a reject test's causal change. |
| `survived` | The mutation did not change the outcome as required. |
| `inconclusive-departure` | The failed original execution has a confirmed departure matching its compiler, source, target and level, below any `conforms_since` boundary. |
| `inconclusive-unsupported` | The original test was `unsupported`. |
| `inconclusive-original` | The original test did not pass, or it passed only through a permitted rejection. |
| `inconclusive-mutant` | The mutant gave no usable verdict: it was `unsupported` or hit an `infrastructure` or `compiler-error` result. A run test's mutant that was rejected without a coded error is also inconclusive; for a reject or warning test, that rejection gives `survived`. |
| `superseded` | The governing ISO table changes the older claim. Both citation sets are recorded; neither the original nor its mutant executes, and no mutation pass or failure is claimed. |

A `run-or-reject` test's mutant uses the `run` expectation: it must contain a
valid, executable construct whose changed value fails the counted checks.
A permitted rejection of the original gives `inconclusive-original` regardless
of the mutant's outcome. A departure entry for another execution cannot excuse
a surviving mutant. Both programs execute at the governing plan's level and
retain its edition membership, including when that level differs from the
source header's `Version`.

Feature refusals and uncoded rejections never kill a mutant; the table above
gives their results. When a run test's original compiles and passes,
`check-mutations.py` marks its mutant `killed` on any runtime failure, timeouts and unhandled
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
