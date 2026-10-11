# Run targets

This page lists what each target and each older compiler profile needs, how
the runner finds it and what each one can run. Read it before your first run.

A target is the runtime environment that runs the compiled test programs. A
compiler profile is a compiler configuration, such as
`configs/compilers/csc.json`.

- The compiler configuration controls language arguments and diagnostics.
- The target configuration supplies reference assemblies, execution and
  runtime capabilities.
- Use `--target` with `runner/run-suite.py` or
  `runner/tools/check-mutations.py`.
- Every run verifies its controls before any test result counts (see
  [Controls](ARCHITECTURE.md#controls)).

## Targets at a glance

| | `dotnet` | `net481` |
| --- | --- | --- |
| Configuration | `configs/targets/dotnet.json` | `configs/targets/net481.json` |
| How programs run | One process per program, in parallel up to `--jobs` | Compiled to `.exe` files and launched directly, one process per program, in parallel up to `--jobs` |
| Capabilities | `process-launch`, but not `framework-runtime` | `framework-runtime` and `process-launch` |

## The dotnet target

The `dotnet` target discovers the pinned SDK, runtime and reference assemblies.
It looks in this order:

1. `CONFORMANCE_DOTNET_ROOT`;
2. `DOTNET_ROOT`;
3. `dotnet` on `PATH`.

Its exact versions and hashes are in `configs/targets/dotnet.json`. It runs
one process per program, in parallel up to `--jobs`. It does not provide
`framework-runtime`.

## The net481 target

### Requirements

The `net481` target requires:

- Windows x64;
- an x64 Python process;
- .NET Framework 4.8.1 or later;
- the .NET Framework 4.8 targeting pack, which the .NET Framework 4.8
  Developer Pack installs.

### Reference assemblies

The target finds its reference assemblies in this order:

1. through `CONFORMANCE_NETFRAMEWORK_REF_ROOT`;
2. under the standard
   `Reference Assemblies/Microsoft/Framework/.NETFramework/v4.8` directory
   below the system's Program Files (x86) directory.

Each assembly is pinned by SHA-256.

On .NET Framework, the available APIs from the `dotnet` target's reference
subset are consolidated into `mscorlib`, `System`, `System.Core` and
`Microsoft.CSharp`. APIs absent from the Framework targeting pack remain
portability limitations. Adding a package to work around them would change the
target, and it requires a separate configuration.

### Running programs

Framework programs are compiled to `.exe` files and launched directly, one
process per program, in parallel up to `--jobs`. The target provides
`framework-runtime` and `process-launch`.

### Runtime identity

Framework servicing replaces runtime files in place. The target observes the
runtime files instead of pinning them. Each run records:

- the installed release;
- the registry version;
- the file versions and hashes of `mscorlib`, `clr` and `clrjit`.

The target refuses a runtime below the minimum Framework 4.8.1 release value.

### Running the suite on net481

To run every test at its own `Version` on the Framework target:

```text
python runner/run-suite.py --compiler configs/compilers/csc.json --target configs/targets/net481.json --results ../results/csc-net481 --jobs 12
```

Use `--select` to limit the scope.

A Framework compliance result covers only tests whose header `Version` is at
most 7.3, the newest language version Microsoft supports on .NET Framework.
Newer tests lie outside that result's scope.

A missing runtime feature is a target capability limitation; an incidental
missing API is a portability finding. Neither implies that a different
compiler would satisfy the standard on that runtime.

### Bounds for Framework tests

Bounds for tests requiring `framework-runtime` are measured by running the
original program on `net481` at every supported csc level. Their source-keyed
version rows record the measurement target. On `dotnet`, those tests remain
`unsupported` for `target-capability`.

## Older compiler profiles

The `csc-framework` and `mcs` profiles cover older compiler language levels
on the `net481` target.

| | `csc-framework` | `mcs` |
| --- | --- | --- |
| Configuration | `configs/compilers/csc-framework.json` | `configs/compilers/mcs.json` |
| Compiler | The pre-Roslyn Microsoft compiler | The official Windows Mono 6.12.0.206 distribution |
| Discovery | Under `WINDIR`, in `Microsoft.NET/Framework64/v4.0.30319` | Through `CONFORMANCE_MONO_ROOT` |
| Reported version | Serviced binary version 4.8.9221.0 | The compiler banner reports 6.12.0.0 |
| Source commit | Unavailable | Unavailable |
| Pinned files | The compiler and its configuration and diagnostic resources | Its executable, Mono host, execution dependencies and configuration, pinned separately |
| Explicit levels | 1 through 5, using `ISO-1` and `ISO-2` for the first two | 1 through 6 |

For `mcs`, set `CONFORMANCE_MONO_ROOT` to the directory containing
`bin/mono.exe` and `lib/mono/4.5/mcs.exe`.

Neither older profile assigns symbolic modes, such as `latest`, an unmeasured
effective level.

Both profiles compile against the references pinned by `net481` and run their
output on the Framework target. Mono libraries are dependencies of the mcs
compiler process; they are not references of the compiled test programs.

Run the same inventory at each explicit level, including rejection checks for
newer constructs:

```text
python runner/run-suite.py --compiler configs/compilers/csc-framework.json --target configs/targets/net481.json --langversion 1,2,3,4,5 --suite ecma-334 --results ../results/csc-framework-chosen-versions --jobs 12

python runner/run-suite.py --compiler configs/compilers/mcs.json --target configs/targets/net481.json --langversion 1,2,3,4,5,6 --suite ecma-334 --results ../results/mcs-chosen-versions --jobs 12
```

Levels above each profile's highest supported level are outside that
compiler's scope. Failed outcomes remain findings about the compiler,
diagnostic behavior or target portability. They do not change the standard's
expected result.
