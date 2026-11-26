# Contributing

This page explains how to contribute to the suite. It covers the license
agreement, what an addition must contain, how review works and the checks to
run before you open a pull request.

Pull requests are welcome. Before a pull request is merged, its contributor signs
Lamella LLC's Contributor License Agreement so contributions remain free to use
under the suite's dual licenses. Maintainers provide the agreement and its signing
instructions. We may adapt a contribution to the suite's conventions during
review and will work with you to keep its intent clear.

Write each test clean-room, from its rule and the rule's registered sources.
Never copy or adapt another compiler's or suite's tests or the standard's
examples. Consult the [test contract](CONVENTIONS.md) before adding a rule,
program, generator or departure record.

## Additions and review

### Adding a rule

1. Add the predicate to its owning clause ledger, the clause's `rules.tsv`,
   with a short exact quotation and a registered source locator. A locator
   says where the quotation is, such as
   `10.1; p. 117 (PDF p. 145); blocks p1`.
2. Add tests beneath its stable primary rule ID, in
   `tests/<primary-rule-id>/`, or explain in `untested.tsv` why it cannot be
   tested.
3. Update coverage and case maps.

The [test contract](CONVENTIONS.md) defines each of these files.

A library member receives a suite test only where a C# construct's meaning
depends on that member.

### Larger additions

- A new clause gets its own directory and an explicit scope inventory.
- A new edition gets a primary source entry and rules that distinguish its
  text where necessary. The source registry names one matching primary
  edition at each governed level. ISO-1 uses the 2nd edition and ISO-2 uses
  the 4th. Register the 5th and 6th editions with their governing entries
  at levels 5 and 6 respectively. Add the edition's conflict table to
  `ecma-334/edition-conflicts/`, using the edition number as the file name
  with a `.json` extension, following the
  [edition table contract](ARCHITECTURE.md#edition-selection).

  Review conflicts with every other registered edition. Pair each replaced
  test with a replacement from the table edition or another older
  registered edition. A cited `replace` row admits an older replacement
  outside its current measured interval when the cited requirement requires
  its expected result at the table edition's level. The replacement runs
  as an ordinary test unless governing supersession makes the admitted claim
  static. Its measured bounds stay unchanged.

  Within the edition's own table, a replacement must be selected, must not
  itself be excluded, and must form no cycle. Use `leave-out` when no
  replacement is justified. An ordinary exclusion can also name a test with
  the registry's pinned compiler authority. Audit the predicate and all setup
  syntax against the cited edition; compiler acceptance alone supplies no
  standard authority. Preserve each required primary predicate in a compatible test.

  Replacement targets and superseded claims retain their registered
  standard-edition authority requirements. Every row cites the table edition's
  clause and printed/PDF pages, including cross-edition pairs. Include an empty
  table if there are no conflicts, and run `check-editions.py`.

  Record a contradictory pinned-compiler result as a confirmed departure
  citing the governing edition; it remains a departure failure in that run.
  Maintain the other older editions' tables in
  `ecma-334/edition-conflicts/` for conflicting requirements.
  Compare each affected edition's selected inventory before and after the
  table data, naming each exclusion. Verify continuity in both directions
  for programs with compatible predicates and intervals. Adding a new latest
  edition also requires updating the older tables against that base.

  Each edition request uses that edition's own table. Admit other-authority
  tests only for shared requirements, by measured continuity or a cited older
  replacement. Exclude tests whose assertion or prerequisites require a rule
  the edition lacks. The governing table supplies supersession for admitted
  claims. Language-version plans at ISO-1, ISO-2, 5 and 6 take their
  membership from the 2nd, 4th, 5th and 6th editions' tables respectively.

  For every older requirement the governing edition changes, use a
  `leave-out` row with a `superseded` object in that governing table.
  Its `test` and `level` arrays cite both editions with registered source IDs,
  clauses, exact quotes and printed/PDF pages. Keep the older test and add
  coverage for the newer requirement, or give its ledger's untested reason.
  A superseded target must have an older standard authority and cannot also
  be replaced within the same table. Apply governing supersession to admitted
  edition claims and to governed language plans, header audits, summaries
  and mutation results.

  Exercise both valid and refused rows with runner tests. Raw certification measures every source,
  superseded sources included, without changing their measured bounds to
  express table membership.

  Exercise `earliest-per-test` with a cited replacement whose earliest level
  differs from the replaced test's. The replacement runs at the governed level
  it serves and can also retain its own earliest row. Keep both tests in the
  candidate selection and one plan per test and level.
- Later language features use the registered feature authority and
  feature-version IDs (`P<version>-<predicate-slug>`, or
  `Ppreview-<predicate-slug>` for a preview feature).
- Another standard gets a separate `ecma-<number>` directory.
- Retire IDs rather than changing their meanings or reusing them.

### Merging additions

- Keep every distinct test when merging additions.
- Identical duplicates may share one canonical test; record the mapping.
- Conflicting paths with distinct programs need distinct file names and IDs.
- Resolve ledger ownership deliberately, instead of overwriting predicates by
  import order.
- Preserve a record of source and ID changes, so that previous result
  inventories remain comparable.

### Commits and pull requests

- Use focused Git commits for predicates and their programs.
- Commit a generator with its reproducible output and case map.
- Keep derived manifest and bound changes with the additions they describe.

A pull request states:

- the source authority;
- the affected rules;
- the compiler and target commands;
- the results;
- the limitations.

### Review

Review preserves published IDs, verifies evidence and checks portability. Do
not weaken an oracle or an asset pin to make a failing check pass.

Review checks:

- the quotation;
- the predicate;
- minimal prerequisites;
- expected behavior;
- counted cases;
- the causal mutation.

Some additions need more:

- A confirmed compiler departure needs exact observations on the pinned
  compiler and target, and a positive version witness. It remains visible as a
  failure: review never silently changes the required behavior to make a
  compiler pass. A disagreement observed only outside a conforming test's
  header level can keep the ordinary measurement basis and causal repair;
  a departure at the header requires a declared positive witness.
- Generated programs need a reproducible generator and case map.
- Inventoried raw-source changes need byte and line-ending review.

## Required checks

Run commands from the repository root. Results and source caches are external
working artifacts, not additions to the published tree.

```text
python runner/tools/check-runner.py --report ../results/runner-check.json

python runner/tools/check-generated.py --report ../results/generated-check.json

python runner/tools/build-manifest.py --report ../results/manifest-build.json

python runner/tools/check-editions.py --source-map ../sources/source-map.json --report ../results/editions-check.json

python runner/tools/check-ledger.py --source-map ../sources/source-map.json --require-confirmed --report ../results/ledger-check.json

python runner/run-suite.py --compiler configs/compilers/csc.json --target configs/targets/dotnet.json --results ../results/csc-own-versions --langversion declared-per-test --jobs 12

python runner/tools/check-csc.py --results ../results/csc-own-versions --report ../results/csc-check.json

python runner/tools/check-mutations.py --compiler configs/compilers/csc.json --target configs/targets/dotnet.json --results ../results/mutations --jobs 12

python runner/tools/compute-versions.py --compiler configs/compilers/csc.json --target configs/targets/dotnet.json --framework-target configs/targets/net481.json --header-results ../results/csc-own-versions --mutation-results ../results/mutations --results ../results/versions --jobs 12

python runner/tools/build-manifest.py --report ../results/manifest-build-current.json

python runner/tools/build-manifest.py --check --report ../results/manifest-check.json

python runner/tools/check-versions.py --report ../results/versions-check.json

python runner/tools/check-file-sizes.py --report ../results/file-sizes-check.json

python runner/tools/check-publishing.py --csc-results ../results/csc-own-versions --source-map ../sources/source-map.json --report ../results/publishing-check.json
```

What each command does, in order:

`check-runner.py` first checks language and edition selection, platform pins,
the exhaustive measurement logic and external publishing patterns. It uses
synthetic observations and executes no compiler; the suite run below verifies
the real compiler and runtime controls.

| Step | Command | What it does |
| --- | --- | --- |
| 1 | `check-generated.py` | Regenerates the generated tests twice and verifies their source bytes and named cases. |
| 2 | `build-manifest.py` | Derives the manifest from the test headers and joins any existing version data. |
| 3 | `check-editions.py` | Checks each older edition's conflict table, its schema, registered authorities and every referenced test ID. |
| 4 | `check-ledger.py` | Validates ledger ownership, text-block inventories, test coverage and the quotations against the registered sources. With `--require-confirmed`, a pending departure is an error. |
| 5 | `run-suite.py` | Resolves header `Version` plans with `--langversion declared-per-test`, applies governing tables, and runs the active claims with the pinned csc on the `dotnet` target. Superseded claims have cited static rows. |
| 6 | `check-csc.py` | Replays the pinned csc evidence and checks the informational `Csc` headers on active claims at `Version`; validates superseded citations without execution or diagnostic obligations. |
| 7 | `check-mutations.py` | Proves the handwritten tests' causal changes. |
| 8 | `compute-versions.py` | Measures the bounds and the independent all-level sample. |
| 9 | `build-manifest.py` | Rebuilds the manifest, joining the bounds from step 8. |
| 10 | `build-manifest.py --check` | Checks that the manifest is current. |
| 11 | `check-versions.py` | Validates the current bounds and the independent sample. |
| 12 | `check-file-sizes.py` | Enforces the tracked-file size cap and its threefold headroom. |
| 13 | `check-publishing.py` | Validates the public text, legal notices, ledgers and their quotations, edition tables, the raw-source inventory, the version data and the pinned csc evidence, including the informational `Csc` headers. Checks that the required public documents exist and that the manifests and bounds are current. |

### What the checks must show

- The csc run is green, meaning every result passes, except confirmed
  departures and declared target capability gaps. Its controls must pass.
- Mutation evidence must prove the intended cause, or state an explained
  limitation.
- Compute bounds after the source and fixture bytes are final, including the
  original runtime measurement on `net481` for Framework tests.
- Commit the generated bounds and the rebuilt manifest.
- The independent bounds sample is required. Explicit-level consistency runs
  should use the resulting metadata.
- Preserve all commands, commits, compiler/target identities and reports for
  review.
- A publishing check does not replace review of coverage gaps.

The publishing check also accepts `--extra-forbidden-patterns <file>`. Each
nonblank line is a Python regular expression, matched case-insensitively
against every public file, including raw sources and legal notices. Lines
whose first nonspace character is `#` are comments. Invalid expressions fail
the check. Keep this optional policy file outside the published tree; the
report records its hash and the matching pattern's line number.

### File sizes

- Every tracked file must fit under 20 MiB with room for its size to triple.
- The file-size gate uses the Git index, so stage additions before running it.
- Version data uses generated clause/bucket shards. Never combine them into
  one large file.

### The source map

Three of the commands take `--source-map ../sources/source-map.json`. The
source map tells the audit tools where your copies of the registered sources
are. Obtain the registered assets and the exact text extraction outside the
repository.

- The source map is a JSON object with `schema_version: 1` and `sources`.
- Each key is a source-registry ID (or `reference-id:asset-path`). Its entry
  names `asset` and, for a standard edition, `text`.
- Paths resolve relative to the map file.
- Every file must match its registry hash.
- Quote auditing checks the registered page or feature file. An incomplete
  map fails rather than guessing a source.
- Include the older and governing editions used by superseded citations,
  even when their source programs do not execute in a claim run. Keep full
  source extracts outside the published tree.

For example, with the registered files placed next to the map, two entries
look like this. The example is incomplete on purpose: a working map names
every registered source that the ledgers quote.

```json
{
  "schema_version": 1,
  "sources": {
    "ecma-334-ed7": {"asset": "ECMA-334_7th_edition_december_2023.pdf", "text": "ecma334-raw.txt"},
    "csharplang:proposals/csharp-9.0/native-integers.md": {"asset": "native-integers.md"}
  }
}
```

### Rerunning after changes

- Every suite run names either `--edition N` or `--langversion`: one or more
  levels, an inclusive range such as `5..7.3`, `all`, or `earliest-per-test`.
  The selectors cannot be combined. Edition runs use the registered level and
  the requested edition's table, with governing supersession for admitted
  claims. Explicit levels, header plans and `earliest-per-test` use the
  governing edition wherever they resolve to ISO-1, ISO-2, 5 or 6. See
  [Edition runs](RESULTS.md#edition-runs).
- Use a fresh result directory for changed inputs.
- `--resume` on version computation accepts only the same measurement
  identity, selection and policy, and it replays its saved prefix.
- Bounds are exhaustive at every configured level. Keep the independent
  reproducibility check (`--sample 200 --seed 1009`); a mismatch fails the run.
- A pilot `--select`, which measures only selected tests, produces pilot
  metadata and cannot install full-suite bounds, even when the selection matches
  the full inventory. For a pilot smaller than 200 tests, set `--sample` to its
  complete inventory size; the independent sample still freshly measures every
  configured level.
- Measured version runs, edition runs and `check-versions.py` can read that
  external `pilot-versions.json` with `--pilot-versions` and the same `--select`. They
  require an exact source inventory, current measurement identity, fixture and
  witness bindings, and a complete independent sample. The public bounds and
  manifest stay unchanged. The pilot must match the candidate selection before
  edition or version filtering removes any tests.
- A source or witness edit invalidates its bounds. A measurement
  implementation or pinned-asset change can invalidate the complete metadata.
- The shared measurement identity binds the complete platform pin matrix;
  execution evidence binds the host's selected files. Check the same fixed-seed
  selection on each supported host before sharing bounds. Record any outcome
  difference and its cause without changing a test to hide it.
- Framework bounds remain original runtime observations on Windows. Their
  rows bind the observed serviced runtime. A pilot without Framework tests can
  run on any supported `dotnet` host; a selection containing them needs
  Windows and `net481`.
