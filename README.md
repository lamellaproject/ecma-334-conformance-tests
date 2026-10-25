# ecma-334-conformance-tests

An unofficial conformance suite for C# (ECMA-334).
This suite is not affiliated with or endorsed by Ecma International.

Small, standalone programs check rules of the C# language against a compiler and
runtime. Rule ledgers quote the standard and connect each predicate to its tests
or an explicit reason it remains untested. Passing the suite establishes the
recorded observations, not complete language conformance.

The standard under test is [ECMA-334](https://ecma-international.org/publications-and-standards/standards/ecma-334/). Tests for C# features newer than the latest
published ECMA-334 edition take their rules from the C# feature specifications,
and the pinned reference compiler decides their expected results. The source
registry pins its editions, secondary references and compiler authority for
later language features. Tests, ledgers and compiler
configurations can grow without changing the runner.

## Status

This suite is currently a draft, but you can use it to help validate conformance of
an ECMA-334 (C#) compiler today. Additional tests will be published incrementally;
tests, rule ledgers and expected results are subject to change.

## Run

Use Python 3.10 or later and the exact compiler and runtime assets named in the
configurations. The `dotnet` target supports Windows x64, Linux x64, macOS arm64
and Linux arm64. The `net481` target requires Windows x64. See
[target prerequisites](docs/TARGETS.md) for discovery variables and runtime pins.
Run the commands below from the repository root, using your Python interpreter
(`python3` on systems that use that name).

### Run tests at the version you choose

```text
python runner/run-suite.py --compiler configs/compilers/csc.json --target configs/targets/dotnet.json --results ../results/csc-7.3 --langversion 7.3 --jobs 12
```

This runs the suite once at C# 7.3, the version the ECMA-334 7th edition
describes. It leaves out tests whose authority is an older edition, as
explained below. Each test's measured range decides whether it runs normally,
checks rejection of a newer feature, or is `not-applicable`, as described
below. Results are written to the folder named by `--results` (any folder
works), and `--jobs 12` runs up to 12 tests at a time. A run must name its
language selection; without `--langversion` or `--edition` it stops and lists
the choices.

### Run tests at several versions

```text
python runner/run-suite.py --compiler configs/compilers/csc.json --target configs/targets/dotnet.json --results ../results/csc-chosen-versions --langversion 1,2,3,7.3,latest --jobs 12
```

This runs the version selection at each version you list: here C# 1, 2 and 3,
C# 7.3 (the version the latest ECMA-334 edition describes), and `latest`, which each
compiler configuration maps to a version. Each test has a measured range of
versions: the unbroken run of versions, including its own, at which the
reference compiler passes it. At a version inside that range, the test runs
normally. Below the range, where the reference compiler refuses the feature, the
test checks that your compiler refuses it too. Otherwise the test is reported as
`not-applicable`. `--langversion 5..7.3` selects an inclusive range, in the
compiler configuration's level order. `--langversion all` selects every version
the configuration lists, including its supported preview mode.
`--langversion earliest-per-test` runs each test once, at the first level of
its measured range. These runs require current measured ranges. If you name a
version the compiler does not support, the run stops.

Version runs use the latest standard edition's answers and compiler-authority
tests. They exclude tests whose authority is an older standard edition.

### Run an older edition

```text
python runner/run-suite.py --compiler configs/compilers/csc.json --target configs/targets/dotnet.json --results ../results/csc-edition-1 --edition 1 --jobs 12
```

An edition run checks a registered older edition at its fixed language level.
`--edition 1` runs the ECMA-334 1st edition at ISO-1 (C# 1). It includes
every test with that edition's authority, plus other tests whose current
measured interval contains that level. The edition's conflict table removes
tests it replaces or leaves out. These runs require current bounds, and results
name the edition and level. `--edition` and `--langversion` cannot be combined.

### Running part of the suite

Add `--suite ecma-334`, `--select` with a regular expression on test IDs, or
`--origin handwritten|generated|post-ecma`. `post-ecma` selects tests for
features newer than the latest ECMA-334 edition. Their rules come from the C#
feature specifications, and the pinned reference compiler decides each expected
result.

### Other compilers and runtimes

To test another compiler or runtime, pass its configuration to `--compiler` or
`--target`; configurations may live outside the repository. The `csc-framework`
and `mcs` profiles are Windows-only. They cover older compiler language levels
on the `net481` target.
Their discovery prerequisites and commands are in
[target prerequisites](docs/TARGETS.md).

### Controls and results

Every run verifies controls first. A failed control makes the run void. Normal
results include `results.tsv`, `summary.json`, `summary.md` and `run.json` under
the chosen results directory, with saved sources, diagnostics and artifacts.
`--resume` reuses verified passes; `--resume-completed` also retains verified
completed failures. Both run fresh controls. Stop with `--stop-file` or bound an
invocation with `--max-new`; incomplete runs are marked explicitly.

## Contributing

Read [result categories](docs/RESULTS.md), the [test contract](docs/CONVENTIONS.md),
[architecture](docs/ARCHITECTURE.md) and [contribution workflow](docs/CONTRIBUTING.md).
Confirmed compiler and hosted-runtime departures remain visible as failures with
departure annotations. Unsupported features, missing target capabilities and
tests outside their measured intervals are reported separately.

Everything a pull request needs is documented in docs/, in enough detail that an AI coding
assistant can check one against it. Before you open a pull request, please ask an AI
assistant to review your change against those requirements; it's a quick way to catch small
problems early. We also ask that you review the change yourself and submit it in your own
name, as an individual contributor rather than from a bot account.

The ledgers contain short, unchanged quotations from the standard. Its notice and
license are included in [NOTICE](NOTICE). Full standards and extracted texts are
external audit inputs and are not distributed with the suite.

## How this repo is managed

This conformance suite is maintained by humans using traditional software engineering
practices, working with frontier AI models. To help ensure thorough and correct coverage
of the standard under test, AI coding agents help define, write and review the tests in
this suite. @lamella-mel, AI co-author for this project, will likewise support contributors
who submit pull requests.

## License

Dual licensed under either of

- MIT license ([LICENSE-MIT](LICENSE-MIT))
- Apache License, Version 2.0 ([LICENSE-APACHE](LICENSE-APACHE))

at your option.
