# Architecture

This page explains how the runner, the configurations and the generated data
fit together. Read it if you change the runner, write a compiler or target
configuration, or want to know how results and version data are checked.

## Overview

One runner combines three inputs:

- a standard's **test contract**: the rules that every test and ledger follows
  (see [Test contract](CONVENTIONS.md));
- a **compiler configuration**: the compiler builds the programs, and its
  configuration supplies the rules for parsing the compiler's diagnostics;
- a **target configuration**: the target supplies reference assemblies,
  runtime capabilities and a batch execution adapter.

Reference assemblies are the libraries that test programs compile against. A
runtime capability is a named feature that a target offers, such as
`framework-runtime`. A batch execution adapter runs a batch of compiled
programs and reports what each one did; see [Target adapters](#target-adapters).

All tooling uses only the Python standard library. It passes argument arrays
(argv) directly to processes, without shell interpretation.

## Layout and identities

### The standard directory

Each installed standard occupies its own directory, named `ecma-<number>/`,
which contains the entries below. Today the only installed standard is
ECMA-334, in `ecma-334/`.

| Path | Contents |
| --- | --- |
| `source-registry.json` | The registered sources: the standard's editions, the references and the compiler authority. It also lists the rules that may justify raw source. |
| `ledger-scope.json` | The scope of each clause and its text-block inventory. |
| `raw-source.tsv` | Optional. The inventory of raw-source exceptions; see [Bytes and raw source](CONVENTIONS.md#bytes-and-raw-source). |
| `reference-notes.tsv` | Optional. Reference notes, which record where the pinned csc disagrees with the rule text of a test whose authority is csc. They use the columns of departure records; see [Departures](CONVENTIONS.md#departures). |
| `manifest.tsv` and `manifest/` | The derived manifest; see [The manifest](#the-manifest). |
| `versions/` | Generated version data, indexed by `versions/index.json`; see [Version data](#version-data). |
| `clauses/<NN>-<slug>/` | One directory per clause. |

A clause directory is named after a clause of ECMA-334: the two-digit clause
number, then a short form of the clause title. For example,
`clauses/10-conversions/` holds clause 10, Conversions. The ledgers cover
clauses 6 to 23, from `06-lexical-structure` to `23-unsafe-code`, and
`ledger-scope.json` records that scope. The standard's clauses 1 to 5 are
outside it. In the 7th edition, their titles are Scope, Normative references,
Terms and definitions, General description and Conformance.

A clause owns its rules, coverage, untested reasons, departure records, tests,
generators and optional fixture parts. The [test contract](CONVENTIONS.md)
describes each of them.

When the suite grows:

- Adding another edition adds a registered primary source and edition-specific
  rules.
- Adding another standard adds its own standard directory.
- The runner's default selection includes every installed standard.

### Paths and test IDs

- Paths in the public tree are relative and use `/`.
- Tests keep stable IDs of the form
  `<clause-folder>--<primary-rule-id>--<file-stem>`. For example, the test
  `ecma-334/clauses/10-conversions/tests/E10-1-representation/implicit-long.cs`
  has the ID `10-conversions--E10-1-representation--implicit-long`.
- A result's identity also includes the standard, the resolved language level
  and the check mode. The check mode says how the test was checked at that
  level. For example, it ran as an ordinary test or as a version-gating check
  (see [Explicit language levels](RESULTS.md#explicit-language-levels)).
- Artifact directories are named with compact hashes. These hashes do not
  replace the public IDs.

### The manifest

The manifest lists every test of a standard, one row per test. A row holds the
test's ID, its path, the values from its header and the state of its version
data. The manifest is derived: `runner/tools/build-manifest.py` builds it from
the test headers and the version data. Nobody edits it by hand.

The manifest is split into shards: smaller files that together hold the whole
data set. There is one shard per clause:

- `manifest.tsv` is a sorted TSV (tab-separated values) index with the columns
  `path`, `sha256` and `rows`, one line per shard.
- Each `manifest/<NN>-<slug>.tsv` holds the complete derived rows of one
  clause, in source inventory order, with the usual manifest columns.
- The hashes in the index cover the exact bytes of each shard.

Readers check the full shard inventory, the hashes, the row counts and the
clause ownership, then concatenate the clauses in index order. This storage
layout does not change the resulting rows.

Writers enforce threefold headroom under the same file cap as the version
shards: each file must stay under 20 MiB even if its size triples. Archived
full TSV manifests, which hold every row in one file, remain readable for
evidence.

### Configurations

Configurations need not live under `configs/`. Discovery finds the pinned
assets, such as the compiler and the runtime, through documented environment
variables or configured defaults. It verifies their hashes before the controls
run. A pinned asset is a file whose SHA-256 hash the configuration records;
[Run targets](TARGETS.md) lists the environment variables.

A compiler configuration declares:

| Declaration | What it gives the runner |
| --- | --- |
| Explicit language arguments | The argument passed to the compiler for each explicit language level. |
| Symbolic resolutions | What `default`, `latest`, `latestMajor` and `preview` resolve to. |
| Unsupported levels | The levels the compiler cannot provide. |
| Neutral requirement mappings | The compiler switches for each neutral requirement name, such as `unsafe-disabled`. |
| Rejection exit codes | The exit codes that mean the compiler rejected the program. |
| Diagnostic rules | How to parse the compiler's diagnostics, and which codes count as command-line errors, feature refusals or feature-version errors. |

A target configuration declares:

| Declaration | What it gives the runner |
| --- | --- |
| Reference assemblies | The assemblies that test programs compile against. |
| Platforms | The platforms the target runs on. |
| Build settings | How programs are built for the target. |
| Capabilities | The runtime capabilities the target provides. |
| Execution protocol | The adapter, the command that runs the programs and the batch size. |

The schemas in `configs/schemas/` document these contracts. The shared
validators enforce them and reject unknown fields.

## Modules and execution

The runner is `runner/run-suite.py`. The other modules live in
`runner/tools/`.

| Module | Responsibility |
| --- | --- |
| `run-suite.py` | Selection, level resolution, controls, scheduling and summaries |
| `suite_common.py` | Exact source bytes, headers, registries, fixtures and derived inventory |
| `suite_config.py` | Config validation, discovery, asset pins and argv expansion |
| `suite_engine.py` | Compile stages, preflight checks, immutable attempts and departure annotations |
| `suite_diagnostics.py` | Diagnostic parsing, source checks and compiler/runtime verdicts |
| `suite_targets.py` | Artifact verification and batch execution adapters |
| `suite_netframework.py` | Framework discovery and observed serviced-runtime identity |
| `suite_evidence.py` | Replay of saved commands, sources, streams, artifacts and verdicts |
| `suite_versions.py` | Source-keyed version metadata, applicability and gating source |
| `suite_measurements.py` | Witness selection, per-level observations, intervals and registered contexts |
| `suite_version_schedule.py` | Verified resume, rate policy and independent exhaustive sample |
| `suite_audits.py` | Ledger, raw-source and pinned csc evidence audits |

### How a test is compiled and run

An attempt is one try at compiling, and possibly running, one test at one
language level in one check mode. Each attempt gets a new directory and is
immutable. The engine compiles the fixture libraries in declaration order,
then the main program. Fixtures are described in
[Fixtures](CONVENTIONS.md#fixtures). Each of these compilations is a stage.
For each stage, the engine works in this order:

1. The stage's sources are copied byte for byte into the attempt. Per-unit
   defines are prepended only where the contract allows it.
2. The stage is compiled.
3. Its diagnostics are parsed. Diagnostics keep their compilation stage, so a
   library's diagnostics stay apart from the program's.

A library prerequisite must succeed before the program's rejection can count.
Successful programs are then sent to the target as a batch. The target returns
one observation per requested artifact.

### Controls

Controls are small programs in `runner/controls/` whose outcomes are known in
advance. `positive.cs` must pass. The others are deliberately broken; for
example, `hang.cs` never ends, so it must fail with a timeout. Every run
verifies its controls before any test result counts, and a failed control
makes the run void.

- Controls run at their declared language level when the compiler supports
  it.
- For older compilers, they use the highest supported explicit level below
  that declaration.
- Their sources and expected outcomes are the same at every supported level.
- Ordinary tests keep their declared or requested language level.

### Target adapters

| Adapter | How it runs programs |
| --- | --- |
| `dotnet` | One process per program, with bounded parallelism. |
| `netframework` | One process per program, with bounded parallelism. |
| `external-batch` | Receives a JSON request file and writes a JSON response file, through a configured command. |

The `external-batch` protocol works like this:

- The configured command receives `{request}` and `{response}`, which the
  runner replaces with the paths of the two files.
- The request lists the programs to run. Each entry includes an ID, the entry
  assembly, the hashed artifacts, the arguments and a timeout.
- The response must return each ID exactly once, with an integer exit or
  `timeout`/`launch-error`, stdout, stderr and the elapsed seconds.
- The runner checks the artifact hashes before dispatch.
- `configs/schemas/batch-request.schema.json` and
  `configs/schemas/batch-response.schema.json` describe the two files.

This protocol lets an emulator execute a batch without changing the test or
compiler contracts.

## Version data

A test applies to a range of C# language levels. The suite measures that range
for every test and stores it as generated version data in `ecma-334/versions/`.
This section explains what the files hold, what their names mean and how they
are checked. The rules a test's range follows are in
[Bounds](CONVENTIONS.md#bounds).

### What the files hold

`versions/` holds `index.json` and one folder per clause. The folders have the
same names as the clause directories, from `06-lexical-structure` to
`23-unsafe-code`; [The standard directory](#the-standard-directory) explains
which clauses the ledgers cover. Each JSON file in a clause folder holds
generated version data, one row per test. Among other fields, a row records:

- `since`: the lowest language level of the test's measured interval;
- `until`: the highest level of that interval, recorded only when the interval
  ends below the highest measured level;
- `below_since`: the level just below `since`, whether csc refused the test's
  construct there or accepted it with a different outcome (a meaning change),
  and the diagnostic codes;
- `other_passing_levels`: passing levels outside the interval;
- the observation at each measured level, and hashes of the evidence behind
  the observations.

The rows are measured with the registered pinned csc.
`runner/tools/compute-versions.py` generates the files, and
`runner/tools/check-versions.py` validates them. The runner uses them for
explicit-level runs, which pass `--langversion`. Nobody edits them by hand.

### How the files are named

Version data is split into shards, one file per clause and bucket:
`versions/<NN>-<slug>/<hh>.json`.

- `<NN>-<slug>` is the clause, taken from the stable test ID.
- `<hh>` is the bucket: the first byte of the SHA-256 hash of the test ID,
  written as two lowercase hexadecimal digits.

Only nonempty buckets exist. Placement does not depend on the source hash, the
row count or other tests, so adding unrelated tests never relocates an
existing row. Bucketing also keeps every file small.

A worked example:

1. The SHA-256 hash of the test ID
   `11-patterns--E11-2-2-incompatible-types--sealed-unrelated` begins with
   `5b`.
2. So its row is in `versions/11-patterns/5b.json`, under the hash of its
   source file.
3. The row's `since` is `7`, so the test applies from C# 7 on. The row has no
   `until`.
4. Its `below_since` records that at level `6`, csc refuses the construct the
   test needs (diagnostic `CS8059`).
5. In an explicit-level run, the test is therefore checked as an ordinary test
   at level 7 and above. At level 6 and below, the run makes a version-gating
   check instead (see
   [Explicit language levels](RESULTS.md#explicit-language-levels)).

`versions/index.json` lists every bucket file with its hash and row count.

### Index and shard format

`versions/index.json` and its indexed shards are committed generated data.
Rows are keyed by source hash and test ID.

- Each shard contains `schema_version: 2` and `rows`, keeping the
  source-hash/test-ID nesting.
- The index carries shared metadata and a sorted `row_shards` list. Each
  entry holds a shard's relative path, the SHA-256 of its exact bytes and its
  row count.
- Loading checks every hash, count and placement. It rejects duplicate keys
  and rows, and it rejects missing or unindexed JSON shards, before it
  reassembles the complete logical metadata.

Generation sorts every object key and uses two-space indentation, ASCII JSON
escapes, LF line ends and one final LF. Unchanged data produces identical
bytes, and a row edit changes its own shard and that shard's digest in the
index.

The writer requires every generated file to fit under 20 MiB even if its size
triples. The tracked-file gate, `runner/tools/check-file-sizes.py`, enforces
the same cap and growth headroom across the tree. Both the index and the
shards are generated, never edited by hand.

### Measuring bounds

A test's bounds are `Since` and `Until`, the measured edges of its interval.
Bounds are measured with the registered pinned csc. At each level, a test
passes when:

| Test | Passes at a level when |
| --- | --- |
| Ordinary run test | The program runs successfully. |
| Rejection test with a repair | The original is rejected and the positive repair compiles. |
| Generated rejection without a repair | It is rejected without any configured feature-version error. |
| Confirmed departure | Its declared positive construct witness compiles. |

A repair is a reject test's mutated program (see
[Causal mutations](CONVENTIONS.md#causal-mutations)). A positive construct
witness is a program that uses the construct in a valid way (see
[Departures](CONVENTIONS.md#departures)). Tests requiring `framework-runtime`
run on `net481` at every measured level.

The measurement scheduler works like this:

1. It begins exhaustively: it measures every level.
2. An optional UTC deadline can switch the remaining tests to a monotonic
   search. That happens when the rate measured on the first tests (the
   prefix) projects that exhaustive measurement would finish too late. A
   monotonic search finds the edges of the passing interval by bisection, so
   it measures fewer levels.
3. Each row records its method.
4. A separate fixed-seed sample measures every level with fresh executions.
   This independent sample checks the rows.
5. A counterexample from the sample invalidates all search rows and requires
   exhaustive refinement.

Disconnected passing levels remain recorded. The published interval is the
contiguous interval that contains the header `Version`.

### Row contents and states

Rows include witness and fixture hashes, the target identity, the predecessor
behavior, the method, the observations and evidence hashes. The predecessor
is the level just below `Since`; see [Bounds](CONVENTIONS.md#bounds).

The manifest joins this data and marks each test's row with one of three
states:

| State | Meaning |
| --- | --- |
| `current` | The row matches the test's present source, fixture, witness and measurement identity. |
| `stale` | A row exists, but one of those has changed. |
| `missing` | No row exists for the test. |

Header-Version runs, which run every test at its own `Version` header, report
these states and may run before bounds exist. Explicit-level runs and
publishing require current rows.

### Revalidating after an implementation change

An implementation change makes bounds stale. The implementation is the set of
the suite's Python files whose hashes the measurement identity records.

A complete independent replay of the original observations and of the
exhaustive sample can certify that the changed Python implementation preserves
those bounds. The certificate is the optional `implementation_revalidation`
entry. It binds:

- the logical metadata, with reassembled rows, excluding the certificate
  itself;
- the measurement-state hash;
- the compatibility audit;
- the reconstructed rows, keyed by test ID;
- the changed implementation hashes.

Two kinds of hash are involved. Canonical hashes use sorted keys, ASCII
escapes and compact JSON separators. Shard hashes instead cover the exact
formatted file bytes. The index transitively binds all shard bytes, and the
certificate binds their complete logical content.

The certificate leaves the original measurement identity and every observed
row unchanged. It cannot override compiler, target, control, source or fixture
pins. A further implementation edit makes the certificate stale as well.

Implementation identities use relative file paths and content hashes, so a
publication does not depend on repository history. Scheduling projections and
cutoffs stay in external measurement evidence; they are not published
metadata.

## Evidence

Evidence is the saved record of an execution: its commands, sources, output
streams, artifacts and verdicts. It lives in external result directories,
outside the published tree. These directories preserve:

- compiler and target identities;
- implementation hashes;
- argv;
- limits;
- source contracts;
- diagnostics;
- runtime streams;
- artifacts.

Rules for evidence:

- Framework provenance observes servicing identity instead of pinning runtime
  files (see [The net481 target](TARGETS.md#the-net481-target)).
- Historical reuse requires an explicit metadata binding and a replay of its
  controls and observations.
- When header-Version evidence combines several runs, a combined header
  inventory declares every leaf context (each original run) and every
  record's origin. It keeps each original fingerprint and source hash.
- Evidence-only contexts, which are rebuilt from saved evidence, cannot
  execute processes or replace observations.

## Publication

The public tree holds portable metadata. Machine paths and execution logs
belong in external result directories.

Before publication, the published script `runner/tools/check-publishing.py`
runs as the last of the [required checks](CONTRIBUTING.md#required-checks).
It validates the public text, the legal notices, the ledgers and their
quotations of the registered sources (the standard and the feature
specifications), the raw-source inventory, the version data and the pinned csc
evidence, including the tests' informational `Csc` headers. It also checks
that the required public documents exist and that the manifests and bounds are
current.
