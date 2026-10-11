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

### Larger additions

- A new clause gets its own directory and an explicit scope inventory.
- A new edition gets a primary source entry and rules that distinguish its
  text where necessary.
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
  compiler pass.
- Generated programs need a reproducible generator and case map.
- Inventoried raw-source changes need byte and line-ending review.

## Required checks

Run commands from the repository root. Results and source caches are external
working artifacts, not additions to the published tree.

```text
python runner/tools/check-generated.py --report ../results/generated-check.json

python runner/tools/build-manifest.py --report ../results/manifest-build.json

python runner/tools/check-ledger.py --source-map ../sources/source-map.json --require-confirmed --report ../results/ledger-check.json

python runner/run-suite.py --compiler configs/compilers/csc.json --target configs/targets/dotnet.json --results ../results/csc-own-versions --jobs 12

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

| Step | Command | What it does |
| --- | --- | --- |
| 1 | `check-generated.py` | Regenerates the generated tests twice and verifies their source bytes and named cases. |
| 2 | `build-manifest.py` | Derives the manifest from the test headers and joins any existing version data. |
| 3 | `check-ledger.py` | Validates ledger ownership, text-block inventories, test coverage and the quotations against the registered sources. With `--require-confirmed`, a pending departure is an error. |
| 4 | `run-suite.py` | Runs every test at its header `Version` with the pinned csc on the `dotnet` target. |
| 5 | `check-csc.py` | Replays the pinned csc evidence and checks the informational `Csc` headers at each test's `Version`. |
| 6 | `check-mutations.py` | Proves the handwritten tests' causal changes. |
| 7 | `compute-versions.py` | Measures the bounds and the independent all-level sample. |
| 8 | `build-manifest.py` | Rebuilds the manifest, which now joins the new bounds. |
| 9 | `build-manifest.py --check` | Checks that the manifest is current. |
| 10 | `check-versions.py` | Validates the current bounds and the independent sample. |
| 11 | `check-file-sizes.py` | Enforces the tracked-file size cap and its threefold headroom. |
| 12 | `check-publishing.py` | Validates the public text, legal notices, ledgers and their quotations, the raw-source inventory, the version data and the pinned csc evidence, including the informational `Csc` headers. Checks that the required public documents exist and that the manifests and bounds are current. |

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

### File sizes

- Every tracked file must fit under 20 MiB with room for its size to triple.
- The file-size gate uses the Git index, so stage additions before running it.
- Version data uses generated clause/bucket shards. Never combine them into
  one large file.

### The source map

Two of the commands take `--source-map ../sources/source-map.json`. The
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

- Use a fresh result directory for changed inputs.
- `--resume` on version computation accepts only the same measurement
  identity, selection and policy, and it replays its saved prefix.
- A pilot `--select`, which measures only selected tests, produces pilot
  metadata and cannot install full-suite bounds.
- A source or witness edit invalidates its bounds. A measurement
  implementation or pinned-asset change can invalidate the complete metadata.
