"""Join immutable, source-hash-keyed version observations into a derived manifest."""
from __future__ import annotations

import json
import hashlib
import re
from functools import lru_cache
from pathlib import Path

from suite_common import ROOT, checked_object, digest, inside, mutated_source, scan_tests, sha, standard_root
from suite_config import level_tuple, public_level

BASES = {"original", "repair", "feature-free-rejection", "departure-witness"}
METHODS = {"exhaustive", "monotonic-search"}
FILE_LIMIT = 20 * 1024 * 1024


def shard_path(test_id):
    """Placement depends only on the owning clause and stable test ID."""
    clause = test_id.split("--", 1)[0]
    if not re.fullmatch(r"[0-9]{2}-[a-z0-9]+(?:-[a-z0-9]+)*", clause):
        raise ValueError("Invalid version-row clause: " + test_id)
    bucket = hashlib.sha256(test_id.encode("ascii")).hexdigest()[:2]
    return clause + "/" + bucket + ".json"


def json_bytes(value):
    return (json.dumps(value, sort_keys=True, ensure_ascii=True, indent=2) + "\n").encode("ascii")


def unique_object(pairs):
    value = {}
    for key, item in pairs:
        if key in value:
            raise ValueError("Duplicate JSON key: " + key)
        value[key] = item
    return value


def read_version_files(directory):
    """Verify the complete shard inventory before validating logical metadata."""
    directory = Path(directory)
    index = json.loads((directory / "index.json").read_bytes(), object_pairs_hook=unique_object)
    fields = {"schema_version", "identity", "provenance", "levels", "sample", "row_shards", "implementation_revalidation"}
    checked_object(index, fields, fields - {"implementation_revalidation"})
    if index["schema_version"] != 2 or not isinstance(index["row_shards"], list):
        raise ValueError("Unsupported version index")
    rows, paths, test_ids = {}, [], set()
    for entry in index.pop("row_shards"):
        checked_object(entry, {"path", "sha256", "rows"}, {"path", "sha256", "rows"})
        relative = entry["path"]
        if (not isinstance(relative, str) or not re.fullmatch(r"[0-9]{2}-[a-z0-9]+(?:-[a-z0-9]+)*/[0-9a-f]{2}\.json", relative)
                or relative in paths or not isinstance(entry["sha256"], str)
                or not re.fullmatch(r"[0-9a-f]{64}", entry["sha256"])
                or type(entry["rows"]) is not int or entry["rows"] < 1):
            raise ValueError("Invalid version shard descriptor")
        path = inside(directory, relative)
        if sha(path) != entry["sha256"]:
            raise ValueError("Version shard hash differs: " + relative)
        shard = json.loads(path.read_bytes(), object_pairs_hook=unique_object)
        checked_object(shard, {"schema_version", "rows"}, {"schema_version", "rows"})
        if shard["schema_version"] != 2 or not isinstance(shard["rows"], dict):
            raise ValueError("Invalid version shard: " + relative)
        count = 0
        for source_hash, tests in shard["rows"].items():
            if not isinstance(tests, dict):
                raise ValueError("Invalid source-keyed shard rows")
            for test_id, row in tests.items():
                if test_id in test_ids or shard_path(test_id) != relative:
                    raise ValueError("Duplicate or misplaced version row: " + test_id)
                test_ids.add(test_id)
                rows.setdefault(source_hash, {})[test_id] = row
                count += 1
        if count != entry["rows"]:
            raise ValueError("Version shard row count differs: " + relative)
        paths.append(relative)
    actual = sorted(p.relative_to(directory).as_posix() for p in directory.rglob("*.json") if p != directory / "index.json")
    if paths != sorted(paths) or actual != paths:
        raise ValueError("Version shard inventory differs from the index")
    index["rows"] = rows
    return validate_metadata(index)


def write_version_files(directory, metadata):
    """Generate fixed-format LF JSON; update the index after its shards."""
    validate_metadata(metadata)
    if metadata["schema_version"] != 2:
        raise ValueError("Only current metadata may be published")
    directory = Path(directory)
    shards = {}
    for source_hash, tests in metadata["rows"].items():
        for test_id, row in tests.items():
            shards.setdefault(shard_path(test_id), {}).setdefault(source_hash, {})[test_id] = row
    index = {key: value for key, value in metadata.items() if key != "rows"}
    index["row_shards"] = []
    outputs = {}
    for relative, rows in sorted(shards.items()):
        data = json_bytes({"schema_version": 2, "rows": rows})
        outputs[relative] = data
        index["row_shards"].append({"path": relative, "sha256": hashlib.sha256(data).hexdigest(),
                                    "rows": sum(map(len, rows.values()))})
    outputs["index.json"] = json_bytes(index)
    if any(len(data) * 3 > FILE_LIMIT for data in outputs.values()):
        raise ValueError("Generated version data lacks threefold file-size headroom")
    for relative, data in outputs.items():
        path = directory / relative
        path.parent.mkdir(parents=True, exist_ok=True)
        if not path.is_file() or path.read_bytes() != data:
            path.write_bytes(data)
    # Remove only formerly generated shards, never unrelated files.
    for path in directory.glob("*/*.json"):
        if path.relative_to(directory).as_posix() not in outputs and re.fullmatch(r"[0-9a-f]{2}\.json", path.name):
            path.unlink()


def revalidated_files(metadata):
    """An audited implementation update leaves the measured identity unchanged."""
    files = dict(metadata.get("identity", {}).get("suite_files", {}))
    certificate = metadata.get("implementation_revalidation")
    if certificate is None:
        return files
    fields = {"schema_version", "metadata_sha256", "suite_files", "audit_sha256", "evidence_sha256", "reconstructed_rows_sha256"}
    checked_object(certificate, fields, fields)
    if certificate["schema_version"] != 1 or not isinstance(certificate["suite_files"], dict) or not certificate["suite_files"]:
        raise ValueError("Invalid implementation revalidation")
    for field in fields - {"schema_version", "suite_files"}:
        if not isinstance(certificate[field], str) or not re.fullmatch(r"[0-9a-f]{64}", certificate[field]):
            raise ValueError("Invalid implementation revalidation hash")
    if certificate["evidence_sha256"] != metadata.get("provenance", {}).get("evidence_sha256"):
        raise ValueError("Implementation revalidation names another measurement state")
    for relative, expected in certificate["suite_files"].items():
        if (relative not in files or not re.fullmatch(r"runner/(?:run-suite|tools/[A-Za-z0-9_-]+)\.py", relative)
                or not isinstance(expected, str) or not re.fullmatch(r"[0-9a-f]{64}", expected) or expected == files[relative]):
            raise ValueError("Only changed, already measured Python implementation files may be revalidated")
        files[relative] = expected
    return files


def measurement_identity(context, suite_id, other_contexts=()):
    """Ship hashes and relative paths; local compiler/runtime locations stay in external evidence."""
    files = dict(context.identity["suite_files"])
    files.update({relative: sha(inside(ROOT, relative)) for relative in
                  ["configs/compilers/csc.json", "configs/targets/dotnet.json", "configs/targets/net481.json", suite_id + "/source-registry.json"]})
    for relative in ["runner/tools/compute-versions.py", "runner/tools/suite_measurements.py", "runner/tools/suite_version_schedule.py"]:
        implementation = ROOT / relative
        if implementation.is_file():
            files[relative] = sha(implementation)
    assets = lambda identity: {name: value["sha256"] for name, value in identity["assets"].items()}
    targets = {}
    for current in (context, *other_contexts):
        files.update(current.identity["suite_files"])
        identity = current.identity["target_identity"]
        target = {"assets": assets(identity), "config_sha256": identity["config_sha256"],
                  "capabilities": current.target_config["capabilities"]}
        if "runtime" in identity:
            runtime = identity["runtime"]
            target["runtime"] = {k: runtime[k] for k in ["kind", "architecture", "release", "version"]}
            target["runtime"]["assets"] = {name: {k: value[k] for k in ["sha256", "version"]}
                                          for name, value in runtime["assets"].items()}
        targets[current.target_config["id"]] = target
    return {"compiler_id": context.config["id"], "compiler_commit": context.config["commit"],
            "compiler_version": context.config["version"], "compiler_assets": assets(context.identity["compiler_identity"]),
            "target_id": context.target_config["id"], "target_assets": assets(context.identity["target_identity"]), "targets": targets,
            "compile_timeout": context.compile_timeout, "run_timeout": context.run_timeout, "suite_files": files}


def validate_metadata(metadata):
    required = {"schema_version", "identity", "provenance", "levels", "rows", "sample"}
    if metadata.get("schema_version") == 1:
        required.add("rate_check")
    checked_object(metadata, required | {"implementation_revalidation"}, required)
    if metadata["schema_version"] not in {1, 2} or not isinstance(metadata["rows"], dict):
        raise ValueError("Unsupported version metadata")
    if metadata["schema_version"] == 2 and "suite_commit" in metadata["provenance"]:
        raise ValueError("Version provenance identifies implementation by content hashes")
    levels = metadata["levels"]
    if not isinstance(levels, list) or not levels or len(levels) != len(set(levels)):
        raise ValueError("Version measurement levels must be distinct")
    for level in levels:
        if public_level(level.removesuffix("-preview")) != level.removesuffix("-preview"):
            raise ValueError("Version measurements use canonical explicit levels")
    if sorted(levels, key=level_tuple) != levels:
        raise ValueError("Version measurement levels must be ordered")
    for source_hash, tests in metadata["rows"].items():
        if len(source_hash) != 64 or any(c not in "0123456789abcdef" for c in source_hash) or not isinstance(tests, dict):
            raise ValueError("Invalid source-hash-keyed version rows")
        for test_id, row in tests.items():
            checked_object(row, {"since", "until", "fixture_sha256", "declared_witness_sha256", "witness_sha256", "basis",
                                 "method", "measurement_target", "below_since", "other_passing_levels", "observations", "evidence_sha256"},
                           {"since", "fixture_sha256", "declared_witness_sha256", "witness_sha256", "basis", "method",
                            "measurement_target", "below_since", "other_passing_levels", "observations", "evidence_sha256"})
            if row["since"] not in levels or row["basis"] not in BASES or row["method"] not in METHODS:
                raise ValueError("Invalid bounds/basis/method: " + test_id)
            if row["measurement_target"] not in metadata["identity"].get("targets", {}):
                raise ValueError("Version row has no recorded measurement target: " + test_id)
            if row.get("until") and (row["until"] not in levels or level_tuple(row["until"]) < level_tuple(row["since"])):
                raise ValueError("Invalid upper bound: " + test_id)
            below = row["below_since"]
            checked_object(below, {"level", "behavior", "diagnostic_codes"}, {"level", "behavior", "diagnostic_codes"})
            index = levels.index(row["since"])
            if below["level"] != (levels[index - 1] if index else "") or below["behavior"] not in {"refuses", "meaning-change", "none"}:
                raise ValueError("Invalid predecessor observation: " + test_id)
            if (index == 0) != (below["behavior"] == "none"):
                raise ValueError("Missing/spurious predecessor behavior: " + test_id)
            other = row["other_passing_levels"]
            if not isinstance(other, list) or len(other) != len(set(other)) or any(v not in levels for v in other):
                raise ValueError("Invalid disconnected passing levels: " + test_id)
            if any(level_tuple(row["since"]) <= level_tuple(v) <= level_tuple(row.get("until") or levels[-1]) for v in other):
                raise ValueError("Disconnected levels overlap the selected interval: " + test_id)
            if not isinstance(row["observations"], dict) or not row["observations"] or set(row["observations"]) - set(levels):
                raise ValueError("Version row needs level observations: " + test_id)
            for level, observation in row["observations"].items():
                checked_object(observation, {"applicable", "witness_status", "original_status", "diagnostic_codes", "witness_diagnostic_codes",
                                             "witness_evidence_sha256", "original_evidence_sha256"},
                               {"applicable", "witness_status", "original_status", "diagnostic_codes", "witness_diagnostic_codes",
                                "witness_evidence_sha256", "original_evidence_sha256"})
                if type(observation["applicable"]) is not bool:
                    raise ValueError("Invalid applicability observation: " + test_id)
            if row["method"] == "exhaustive" and set(row["observations"]) != set(levels):
                raise ValueError("Exhaustive version row omits a level: " + test_id)
            if row["since"] not in row["observations"] or not row["observations"][row["since"]]["applicable"]:
                raise ValueError("Lower bound lacks passing evidence: " + test_id)
    revalidated_files(metadata)
    if "implementation_revalidation" in metadata:
        certificate = metadata["implementation_revalidation"]
        payload = {key: value for key, value in metadata.items() if key != "implementation_revalidation"}
        rows = {test_id: row for tests in metadata["rows"].values() for test_id, row in tests.items()}
        if (certificate["metadata_sha256"] != digest(payload) or certificate["reconstructed_rows_sha256"] != digest(rows)):
            raise ValueError("Implementation revalidation differs from the original metadata or reconstructed rows")
    return metadata


@lru_cache(maxsize=None)
def version_file(suite_id):
    path = standard_root(suite_id) / "versions"
    return read_version_files(path) if (path / "index.json").is_file() else None


@lru_cache(maxsize=None)
def identity_matches(identity_json):
    identity = json.loads(identity_json)
    files = identity.get("suite_files", {})
    required = {"configs/compilers/csc.json", "configs/targets/dotnet.json", "configs/targets/net481.json", "runner/tools/suite_versions.py"}
    if not files or not required <= files.keys():
        return False
    try:
        return all(sha(inside(ROOT, relative)) == expected for relative, expected in files.items())
    except OSError:
        return False


def identity_current(metadata):
    # validate_metadata checks the certificate's complete payload binding once
    # when the index and shards are loaded, rather than hashing rows per test.
    identity = {**metadata.get("identity", {}), "suite_files": revalidated_files(metadata)}
    return identity_matches(json.dumps(identity, sort_keys=True))


def version_row(test):
    metadata = version_file(test["suite_id"])
    if metadata is None:
        return None, "missing"
    rows = metadata.get("rows", {})
    row = rows.get(test["source_sha256"], {}).get(test["test_id"])
    if row is None:
        # A row for this ID under an obsolete source hash is stale, rather than missing.
        status = "stale" if any(test["test_id"] in values for values in rows.values()) else "missing"
        return None, status
    if not identity_current(metadata) or row.get("fixture_sha256") != test["fixture_sha256"]:
        return row, "stale"
    fixture = json.loads(test["fixture_json"])
    if "framework-runtime" in fixture.get("target_requires", []):
        if row["basis"] != "original" or row["measurement_target"] != "net481" or row["method"] != "exhaustive":
            raise ValueError("Framework tests require exhaustive runtime bounds on net481: " + test["test_id"])
    witness = test.get("version_witness", "")
    if witness:
        path = standard_root(test["suite_id"]) / "clauses" / test["path"].split("/")[1] / witness
        if not path.is_file() or sha(path) != row.get("declared_witness_sha256"):
            return row, "stale"
    return row, "current"


def joined_tests(suite_id):
    tests = scan_tests(suite_id)
    for test in tests:
        row, status = version_row(test)
        test["version_status"] = status
        if status == "current":
            test["since"], test["until"] = row["since"], row.get("until", "")
            test["versions_row_sha256"] = digest(row)
    return tests


def applicability(test, level):
    """Explicit runs require a current row; header-Version runs never call this function."""
    row, status = version_row(test)
    if status != "current":
        raise ValueError("Current bounds required for " + test["test_id"])
    if level["level"] in row.get("other_passing_levels", []):
        return "not-applicable"
    current = level_tuple(level["level"])
    if current < level_tuple(row["since"]):
        return "version-gating" if row["below_since"]["behavior"] == "refuses" else "not-applicable"
    if row.get("until") and current > level_tuple(row["until"]):
        return "not-applicable"
    return "test"


def gating_source(test):
    """Invalid originals cannot witness feature gating: use the declared/causal repair."""
    root = standard_root(test["suite_id"])
    raw = inside(root, test["path"]).read_bytes()
    if test.get("version_witness"):
        return inside(root / "clauses" / test["path"].split("/")[1], test["version_witness"]).read_bytes()
    if test["expected"] == "reject" and test["origin"] != "generated":
        return mutated_source(test, raw)
    return raw
