"""Schedule source measurements, resume verified prefixes, and check an independent sample."""
from __future__ import annotations

import argparse
import json
import random
import re
import time
import uuid
from concurrent.futures import ThreadPoolExecutor
from datetime import datetime, timedelta, timezone
from pathlib import Path

from suite_common import ROOT, digest, load_manifest, sha, standard_root, utc, write_json
from suite_config import level_tuple, resolve_level
from suite_engine import Context, run_controls
from suite_measurements import Measurement, ObservationRegistry
from suite_versions import measurement_identity, validate_metadata, write_version_files


def framework_test(test):
    return "framework-runtime" in json.loads(test["fixture_json"]).get("target_requires", [])


def mismatches(results, sampled, sample_rows):
    differences = []
    for test, actual in zip(sampled, sample_rows):
        predicted = results[test["test_id"]]["row"]
        for field in ["since", "until", "below_since", "other_passing_levels", "basis", "witness_sha256", "measurement_target"]:
            if predicted.get(field) != actual["row"].get(field):
                differences.append({"test_id": test["test_id"], "field": field,
                                    "measured": predicted.get(field), "independent": actual["row"].get(field)})
    return differences


def replay_prefix(tests, prefix, measurement_of, expected_methods, refined_ids, jobs):
    """Check rows concurrently, then yield them in inventory order."""
    def replay_one(pair):
        test, item = pair
        measurement = measurement_of(test)
        path = measurement.saved_row_path(test)
        if item["test_id"] != test["test_id"] or Path(item["row_path"]).resolve() != path or sha(path) != item["row_sha256"]:
            raise ValueError("A resumed row differs from its ordered inventory")
        result = measurement.replay(test, json.loads(path.read_text()))
        expected_method = "exhaustive" if framework_test(test) or test["test_id"] in refined_ids else expected_methods[test["test_id"]]
        if result["row"]["method"] != item["method"] or item["method"] != expected_method:
            raise ValueError("A resumed row has another method")
        return test, item, result

    # Bound submitted work too: a failure never queues the entire saved prefix.
    # map returns in input order, so the first failing row remains the same.
    with ThreadPoolExecutor(max_workers=jobs) as pool:
        for offset in range(0, len(prefix), jobs):
            group = zip(tests[offset:offset + jobs], prefix[offset:offset + jobs])
            yield from pool.map(replay_one, group)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--compiler", type=Path, default=ROOT / "configs/compilers/csc.json")
    parser.add_argument("--target", type=Path, default=ROOT / "configs/targets/dotnet.json")
    parser.add_argument("--framework-target", type=Path, default=ROOT / "configs/targets/net481.json")
    parser.add_argument("--suite", default="ecma-334")
    parser.add_argument("--results", type=Path, required=True)
    parser.add_argument("--header-results", type=Path)
    parser.add_argument("--framework-header-results", type=Path)
    parser.add_argument("--mutation-results", type=Path)
    parser.add_argument("--reuse-measurements", type=Path, action="append", default=[])
    parser.add_argument("--select", help="Measure a pilot selection; only a complete suite can install public bounds")
    parser.add_argument("--jobs", type=int, default=1)
    parser.add_argument("--resume", action="store_true")
    parser.add_argument("--stop-file", type=Path)
    parser.add_argument("--max-tests", type=int, help="Maximum new prefix rows this invocation; leave the sample pending")
    parser.add_argument("--exhaustive-deadline", help="UTC projection cutoff after the first 500 unique exhaustive rows")
    parser.add_argument("--sample", type=int, default=200)
    parser.add_argument("--seed", type=int, default=1009)
    args = parser.parse_args()
    if not 1 <= args.jobs <= 12 or args.sample < 200 or (args.max_tests is not None and args.max_tests < 1):
        parser.error("jobs must be 1..12; sample must be at least 200; max-tests must be positive")
    deadline = datetime.fromisoformat(args.exhaustive_deadline) if args.exhaustive_deadline else None
    if deadline is not None:
        if deadline.tzinfo is None:
            parser.error("The projection cutoff must include a UTC offset")
        deadline = deadline.astimezone(timezone.utc)
    all_tests = load_manifest(suite_id=args.suite)
    tests = [t for t in all_tests if args.select is None or re.search(args.select, t["test_id"])]
    if args.sample > len(tests):
        parser.error("The independent sample exceeds the selected inventory")
    output = args.results.resolve()
    state_path = output / "state.json"
    if state_path.exists() and not args.resume:
        raise ValueError("An existing measurement state requires --resume or a fresh directory")
    previous = json.loads(state_path.read_text()) if state_path.exists() else {}
    contexts = {"dotnet": Context(args.compiler, args.target, output),
                "net481": Context(args.compiler, args.framework_target, output / "targets/net481")}
    if contexts["dotnet"].target_config["id"] != "dotnet" or contexts["net481"].target_config["id"] != "net481":
        raise ValueError("General bounds use dotnet and the mandatory net481 target")
    from suite_common import source_registry
    for context in contexts.values():
        if context.config["id"] != "csc" or context.config["commit"] != source_registry(args.suite)["csc_commit"]:
            raise ValueError("Bounds require the registered pinned csc authority")
    levels = sorted(contexts["dotnet"].config["language"]["explicit"], key=level_tuple)
    preview = resolve_level(contexts["dotnet"].config, "preview")
    if preview:
        levels.append(preview["level"])
    identity = measurement_identity(contexts["dotnet"], args.suite, [contexts["net481"]])
    selection = digest([[t["source_sha256"], t["test_id"]] for t in tests])
    policy = {"select": args.select, "sample": args.sample, "seed": args.seed,
              "projection_cutoff_utc": deadline.isoformat() if deadline else "", "exhaustive_prefix": 500}
    if previous and (previous.get("schema_version") != 2 or previous["identity"] != identity
                     or previous["selection"] != selection or previous["levels"] != levels or previous["policy"] != policy):
        raise ValueError("Measurement state is stale; use a fresh result directory")
    registry = ObservationRegistry(args.compiler, {"dotnet": args.target, "net481": args.framework_target})
    registry.restore(previous.get("observation_contexts", []))
    for context in contexts.values():
        registry.live(context, "bounds")
    headers, mutation_contexts, reusable = {}, [], {}

    def register_run(directory, filename, kind, target_id):
        context, data = registry.add(directory, directory / filename, kind)
        if (not data["complete"] or data.get("void", False) or data.get("errors", [])
                or context.target_config["id"] != target_id):
            raise ValueError("Only complete nonvoid matching-target observations may be reused")
        registry.controls(context, data["controls"])
        return context, data

    for directory, target_id in [(args.header_results, "dotnet"), (args.framework_header_results, "net481")]:
        if directory:
            directory = directory.resolve()
            context, data = register_run(directory, "run.json", "header", target_id)
            if data["version_mode"] != "header-Version":
                raise ValueError("Header reuse requires header-Version observations")
            headers[target_id] = registry.header(context, data)
    if args.mutation_results:
        context, data = register_run(args.mutation_results.resolve(), "summary.json", "mutations", "dotnet")
        if data["provenance"]["mutation_tool_sha256"] != sha(ROOT / "runner/tools/check-mutations.py"):
            raise ValueError("Mutation witness reuse requires the recorded mutation implementation")
        mutation_contexts.append(context)
    for directory in args.reuse_measurements:
        directory = directory.resolve()
        _, data = register_run(directory, "summary.json", "bounds", "net481")
        if data["levels"] != levels:
            raise ValueError("Historical Framework bounds omit a configured language level")
        for item in data["rows"]:
            if item["test_id"] in reusable or sha(item["row_path"]) != item["row_sha256"]:
                raise ValueError("Historical measurement inventory repeats or changes a row")
            reusable[item["test_id"]] = json.loads(Path(item["row_path"]).read_text())
    measurements = {key: Measurement(context, tests, levels, identity, headers.get(key), registry=registry,
                                      reuse_contexts=mutation_contexts if key == "dotnet" else ())
                    for key, context in contexts.items()}
    target_of = lambda test: "net481" if framework_test(test) else "dotnet"
    measurement_of = lambda test: measurements[target_of(test)]
    started, start = utc(), time.perf_counter()
    invocation_id = uuid.uuid4().hex[:12]

    def fresh_controls(parent, kind):
        observed = {}
        for key, target_path in [("dotnet", args.target), ("net481", args.framework_target)]:
            control_context = Context(args.compiler, target_path, parent / "controls" / invocation_id / key)
            registry.live(control_context, kind)
            control_start = time.perf_counter()
            summary = run_controls(control_context, args.jobs)
            registry.controls(control_context, summary)
            path = control_context.output / "controls.json"
            write_json(path, {"provenance": control_context.provenance(), "controls": summary})
            observed[key] = {"output": str(control_context.output), "controls": summary,
                             "metadata_path": str(path), "metadata_sha256": sha(path),
                             "elapsed_seconds": time.perf_counter() - control_start}
        return observed

    # Current controls precede reuse; every older context's controls were also replayed.
    controls = fresh_controls(output, "bounds-controls")
    results, row_bindings, errors = {}, [], []
    batches = list(previous.get("batches", []))
    rate_check = dict(previous.get("rate_check", {}))
    sample = dict(previous.get("sample", {"complete": False, "independent": True, "seed": args.seed,
                        "tests": args.sample, "levels": levels, "mismatches": []}))
    sample_bindings = list(previous.get("sample_rows", []))
    sample_controls = previous.get("sample_controls", {})
    refined_ids = list(previous.get("refined_test_ids", []))
    invocation_rows, resumed_rows = 0, 0
    prefix = previous.get("rows", [])
    if len(prefix) != previous.get("tests", 0) or len(prefix) > len(tests):
        raise ValueError("The resumed prefix count differs")
    batch_ids = [tid for batch in batches for tid in batch["test_ids"]]
    if batch_ids != [t["test_id"] for t in tests[:len(prefix)]]:
        raise ValueError("Completed batches do not cover the ordered prefix exactly once")
    expected_methods = {}
    offset = 0
    for batch in batches:
        if (batch["tests"] != len(batch["test_ids"]) or not batch["tests"] or batch["elapsed_seconds"] < 0
                or batch["method_for_general"] not in {"exhaustive", "monotonic-search"}
                or (offset < 500 and (offset + batch["tests"] > 500 or batch["method_for_general"] != "exhaustive"))):
            raise ValueError("The saved batch methods, sizes or rate timings differ")
        expected_methods.update({tid: batch["method_for_general"] for tid in batch["test_ids"]})
        offset += batch["tests"]
    if len(prefix) >= 500:
        first = []
        count = 0
        for batch in batches:
            if count >= 500:
                break
            first.append(batch)
            count += batch["tests"]
        elapsed = sum(batch["elapsed_seconds"] for batch in first)
        if (count != 500 or not rate_check or rate_check["tests"] != 500
                or rate_check["elapsed_seconds"] != elapsed or rate_check["tests_per_second"] != 500 / elapsed
                or rate_check["projection_cutoff_utc"] != policy["projection_cutoff_utc"]):
            raise ValueError("The rate check is not bound to the first 500 unique exhaustive rows")
    elif rate_check:
        raise ValueError("A rate check precedes the exhaustive prefix")
    for test, item, result in replay_prefix(tests, prefix, measurement_of, expected_methods, refined_ids, args.jobs):
        results[test["test_id"]] = result
        row_bindings.append(item)
        resumed_rows += 1

    def binding(test, measurement, result):
        path = measurement.saved_row_path(test)
        return {"test_id": test["test_id"], "row_path": str(path), "row_sha256": sha(path),
                "method": result["row"]["method"], "measurement_target": target_of(test)}

    def publish(complete=False):
        data = {"schema_version": 2, "provenance": contexts["dotnet"].provenance(), "identity": identity,
                "selection": selection, "policy": policy, "levels": levels, "controls": controls,
                "tests": len(results), "complete": complete, "errors": errors, "rate_check": rate_check,
                "sample": sample, "sample_rows": sample_bindings, "sample_controls": sample_controls,
                "started_utc": started, "elapsed_seconds": time.perf_counter() - start, "batches": batches,
                "rows": row_bindings, "observation_contexts": registry.exported(), "refined_test_ids": refined_ids,
                "invocation": {"new_rows": invocation_rows, "resumed_rows": resumed_rows}}
        write_json(state_path, data)
        print(json.dumps({key: data[key] for key in ["tests", "complete", "elapsed_seconds", "errors", "invocation"]}), flush=True)
        return data

    def stopped():
        return bool(args.stop_file and args.stop_file.exists())

    with ThreadPoolExecutor(max_workers=args.jobs) as pool:
        while len(results) < len(tests):
            if stopped():
                break
            count = min(args.jobs, len(tests) - len(results), 500 - len(results) if len(results) < 500 else args.jobs)
            if args.max_tests is not None:
                count = min(count, args.max_tests - invocation_rows)
            if count <= 0:
                break
            group = tests[len(results):len(results) + count]
            method = "exhaustive" if len(results) < 500 else rate_check.get("method_for_remaining", "exhaustive")
            batch_start = time.perf_counter()

            def measure_one(test):
                measurement = measurement_of(test)
                current_method = "exhaustive" if framework_test(test) else method
                try:
                    if test["test_id"] in reusable:
                        result = measurement.replay(test, reusable[test["test_id"]], historical=True)
                        if result["row"]["method"] != current_method:
                            raise ValueError("A reused mandatory Framework row is not exhaustive")
                        write_json(measurement.saved_row_path(test), result)
                    else:
                        result = measurement.measure(test, current_method, args.resume)
                    return result, None
                except (ValueError, OSError, KeyError, TypeError) as error:
                    return None, test["test_id"] + ": " + str(error)

            measured = list(pool.map(measure_one, group))
            errors.extend(error for _, error in measured if error)
            if errors:
                publish()
                return 1
            for test, (result, _) in zip(group, measured):
                results[test["test_id"]] = result
                row_bindings.append(binding(test, measurement_of(test), result))
            invocation_rows += len(group)
            batches.append({"test_ids": [t["test_id"] for t in group], "tests": len(group),
                            "elapsed_seconds": time.perf_counter() - batch_start, "method_for_general": method, "ended_utc": utc(),
                            "command": contexts["dotnet"].provenance()["command"]})
            if len(results) == 500 and not rate_check:
                elapsed = sum(b["elapsed_seconds"] for b in batches)
                rate = 500 / elapsed
                projected_at = datetime.now(timezone.utc)
                projected = projected_at + timedelta(seconds=(len(tests) - 500) / rate)
                rate_check = {"tests": 500, "elapsed_seconds": elapsed, "tests_per_second": rate,
                              "projected_at_utc": projected_at.isoformat(), "projected_end_utc": projected.isoformat(), "projection_cutoff_utc": policy["projection_cutoff_utc"],
                              "method_for_remaining": "monotonic-search" if deadline and projected > deadline else "exhaustive"}
                print(json.dumps({"rate_check": rate_check}), flush=True)
            publish()
    if len(results) != len(tests) or args.max_tests is not None or stopped():
        publish()
        return 2

    sampled = sorted(random.Random(args.seed).sample(tests, args.sample), key=lambda t: t["test_id"])
    sample_root = output / "sample"
    sample_contexts = {key: Context(args.compiler, path, sample_root / key)
                       for key, path in [("dotnet", args.target), ("net481", args.framework_target)]}
    for context in sample_contexts.values():
        registry.live(context, "sample")
    sample_controls = fresh_controls(sample_root, "sample-controls")
    independent = {key: Measurement(context, tests, levels, identity, fresh=True, registry=registry)
                   for key, context in sample_contexts.items()}
    sampled_results = []
    if len(sample_bindings) > len(sampled):
        raise ValueError("Independent sample prefix exceeds its fixed selection")
    for test, item in zip(sampled, sample_bindings):
        measurement = independent[target_of(test)]
        path = measurement.saved_row_path(test)
        if item["test_id"] != test["test_id"] or Path(item["row_path"]).resolve() != path or sha(path) != item["row_sha256"]:
            raise ValueError("The independent sample prefix differs from its fixed selection")
        sampled_results.append(measurement.replay(test, json.loads(path.read_text()), independent=True))
    with ThreadPoolExecutor(max_workers=args.jobs) as pool:
        while len(sampled_results) < len(sampled):
            if stopped():
                publish()
                return 2
            group = sampled[len(sampled_results):len(sampled_results) + args.jobs]
            def sample_one(test):
                return independent[target_of(test)].measure(test, "exhaustive")
            measured = list(pool.map(sample_one, group))
            for test, result in zip(group, measured):
                sampled_results.append(result)
                sample_bindings.append(binding(test, independent[target_of(test)], result))
            print(json.dumps({"sample_tests": len(sampled_results)}), flush=True)
            publish()
    sample["test_ids"] = [t["test_id"] for t in sampled]
    sample["mismatches"] = mismatches(results, sampled, sampled_results)
    if sample["mismatches"]:
        sample.setdefault("initial_mismatches", sample["mismatches"])
        # A counterexample invalidates every search row, not just the sampled test.
        rate_check["assumption_invalidated"] = True
        rate_check["method_for_remaining"] = "exhaustive"
        needs_refinement = [t for t in tests if results[t["test_id"]]["row"]["method"] == "monotonic-search"]
        with ThreadPoolExecutor(max_workers=args.jobs) as pool:
            for index in range(0, len(needs_refinement), args.jobs):
                if stopped():
                    publish()
                    return 2
                group = needs_refinement[index:index + args.jobs]
                for test in group:
                    path = measurement_of(test).saved_row_path(test)
                    archived = path.with_name("searched-" + sha(path) + ".json")
                    if not archived.exists():
                        write_json(archived, json.loads(path.read_text()))
                refined = list(pool.map(lambda t: measurement_of(t).measure(t, "exhaustive"), group))
                for test, result in zip(group, refined):
                    results[test["test_id"]] = result
                    position = next(i for i, t in enumerate(tests) if t["test_id"] == test["test_id"])
                    row_bindings[position] = binding(test, measurement_of(test), result)
                    refined_ids.append(test["test_id"])
                publish()
        sample["mismatches"] = mismatches(results, sampled, sampled_results)
    sample["complete"] = not sample["mismatches"]
    sample_path = output / "sample.json"
    write_json(sample_path, {"provenance": contexts["dotnet"].provenance(), "controls": sample_controls,
                             "sample": sample, "rows": sample_bindings, "observation_contexts": registry.exported()})
    sample["evidence_sha256"] = sha(sample_path)
    state = publish(sample["complete"])
    if not sample["complete"]:
        return 1
    metadata = {"schema_version": 2, "identity": identity, "levels": levels, "rows": {},
                "sample": sample, "provenance": {"tool": "runner/tools/compute-versions.py",
                    "compiler_commit": contexts["dotnet"].config["commit"],
                    "targets": {key: c.target_config["description"] for key, c in contexts.items()},
                    "version_feature_codes": sorted(measurements["dotnet"].feature_codes), "evidence_sha256": sha(state_path)}}
    for test in tests:
        metadata["rows"].setdefault(test["source_sha256"], {})[test["test_id"]] = results[test["test_id"]]["row"]
    validate_metadata(metadata)
    if len(tests) == len(all_tests):
        write_version_files(standard_root(args.suite) / "versions", metadata)
    else:
        write_json(output / "pilot-versions.json", metadata)
    return 0
