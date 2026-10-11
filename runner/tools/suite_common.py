"""Portable source contract and evidence helpers, shared by the runner and maintainer tools."""
from __future__ import annotations

import csv
import hashlib
import io
import json
import os
import re
import subprocess
import sys
import time
from datetime import datetime, timezone
from functools import lru_cache
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
# The default standard root also keeps clause generators independent of repository placement.
SUITE = ROOT / "ecma-334"
RULE_FIELDS = ["rule_id", "source_id", "locator", "quote_json", "kind", "requirement", "version", "notes"]
MANIFEST_FIELDS = ["suite_id", "test_id", "path", "rule_ids", "authority", "version", "expected", "stdout_json",
                   "origin", "mutation_old", "mutation_new", "csc_codes", "generator", "source_sha256",
                   "diagnostic", "requirements_json", "fixture_json", "source_diagnostic_json", "version_witness",
                   "fixture_sha256", "version_status", "since", "until", "versions_row_sha256"]
HEADER_KEYS = ["Rules", "Authority", "Version", "Expected", "Stdout", "Diagnostic", "Requirements", "Fixture",
               "Source-Diagnostic", "Version-Witness", "Generated", "Mutate", "Into", "Csc"]
RULE_ID = re.compile(r"(?:E\d+(?:-\d+)*|P(?:\d+|preview))-[a-z0-9]+(?:-[a-z0-9]+)*\Z")
IDENTIFIER = re.compile(r"[A-Za-z_][A-Za-z_0-9]*\Z")
KINDS = {"permits", "forbids", "behavior", "implementation-defined", "unspecified"}
REQUIREMENTS = {"unsafe-disabled", "updated-memory-safety"}
RAW_FIELDS = ["path", "byte_sequences_json", "rule_id", "reason", "source_sha256"]


def sha(path):
    return hashlib.sha256(Path(path).read_bytes()).hexdigest()


def digest(value):
    return hashlib.sha256(json.dumps(value, sort_keys=True, ensure_ascii=True, separators=(",", ":")).encode()).hexdigest()


def utc():
    return datetime.now(timezone.utc).isoformat()


def canonical(path):
    return Path(path).resolve()


def writable(path):
    """Outputs are explicit paths; the suite need not sit beneath a writable repository root."""
    return canonical(path)


def standard_root(suite_id="ecma-334"):
    if not re.fullmatch(r"ecma-[0-9]+", suite_id):
        raise ValueError("Invalid suite ID: " + suite_id)
    root = ROOT / suite_id
    if not (root / "source-registry.json").is_file():
        raise ValueError("Uninstalled suite: " + suite_id)
    return root


def installed_suites():
    return sorted(p.name for p in ROOT.iterdir() if p.is_dir() and re.fullmatch(r"ecma-[0-9]+", p.name)
                  and (p / "source-registry.json").is_file())


def inside(root, relative):
    if (not isinstance(relative, str) or Path(relative).is_absolute() or ".." in Path(relative).parts
            or "\\" in relative or re.match(r"(?:[A-Za-z]:|[/\\])", relative)):
        raise ValueError("Expected a contained relative path: " + str(relative))
    path = canonical(root / relative)
    if not path.is_relative_to(canonical(root)):
        raise ValueError("Path escapes source root: " + relative)
    return path


def suite_path(value, suite_id="ecma-334"):
    return inside(standard_root(suite_id), value)


def write_bytes(path, value):
    path = writable(path)
    path.parent.mkdir(parents=True, exist_ok=True)
    temporary = path.with_name(path.name + ".tmp")
    temporary.write_bytes(value)
    temporary.replace(path)


def write_text(path, value):
    write_bytes(path, value.encode("utf-8"))


def write_json(path, value):
    write_text(path, json.dumps(value, indent=2, ensure_ascii=True) + "\n")


def read_tsv(path, fields=None):
    with Path(path).open(encoding="utf-8", newline="") as stream:
        reader = csv.DictReader(stream, delimiter="\t")
        if fields is not None and reader.fieldnames != fields:
            raise ValueError(f"Wrong TSV columns in {path}: {reader.fieldnames}")
        rows = list(reader)
    if any(None in row or any(v is None for v in row.values()) for row in rows):
        raise ValueError("Malformed TSV: " + str(path))
    return rows


def tsv_text(rows, fields):
    stream = io.StringIO(newline="")
    writer = csv.DictWriter(stream, fieldnames=fields, delimiter="\t", lineterminator="\n")
    writer.writeheader()
    writer.writerows(rows)
    return stream.getvalue()


def write_tsv(path, rows, fields):
    write_text(path, tsv_text(rows, fields))


@lru_cache(maxsize=None)
def source_registry(suite_id="ecma-334"):
    registry = json.loads((standard_root(suite_id) / "source-registry.json").read_text(encoding="utf-8"))
    fields = {"schema_version", "standard", "standard_version", "standard_sha256", "feature_commit", "csc_version",
              "csc_commit", "editions", "references", "compiler_authority"}
    checked_object(registry, fields | {"raw_source_rules"}, fields)
    if registry["schema_version"] != 1 or registry["standard"].lower() != suite_id:
        raise ValueError("Unsupported source registry version/standard")
    ids = set()
    for collection in ("editions", "references"):
        if not isinstance(registry[collection], list) or (collection == "editions" and not registry[collection]):
            raise ValueError("Registry editions/references must be arrays")
        for entry in registry[collection]:
            required = {"id", "standard", "edition", "role", "authority_prefix", "language_version", "asset", "sha256"} if collection == "editions" else {"id", "role", "repository", "commit"}
            allowed = required | ({"url", "version_proof", "text"} if collection == "editions" else {"branch", "assets"})
            checked_object(entry, allowed, required)
            if entry["id"] in ids or not re.fullmatch(r"[a-z][a-z0-9]*(?:-[a-z0-9]+)*", entry["id"]):
                raise ValueError("Invalid or duplicate source ID")
            ids.add(entry["id"])
            if entry["role"] not in {"primary", "secondary"}:
                raise ValueError("Source role must be primary or secondary")
            if collection == "editions":
                if entry["standard"].lower() != suite_id or not re.fullmatch(r"[0-9a-f]{64}", entry["sha256"]):
                    raise ValueError("Edition must name this standard and its immutable source hash")
                public_level(entry["language_version"])
                if Path(entry["asset"]).is_absolute() or ".." in Path(entry["asset"]).parts or "\\" in entry["asset"] or ":" in entry["asset"]:
                    raise ValueError("Source asset names must be relative")
                if "text" in entry:
                    checked_object(entry["text"], {"asset", "sha256"}, {"asset", "sha256"})
                    if not re.fullmatch(r"[0-9a-f]{64}", entry["text"]["sha256"]):
                        raise ValueError("Text extraction must have an immutable hash")
                    inside(standard_root(suite_id), entry["text"]["asset"])
            else:
                if not re.fullmatch(r"[0-9a-f]{40}", entry["commit"]) or not entry["repository"].startswith("https://"):
                    raise ValueError("Reference must name a public repository and pinned commit")
                paths = set()
                for asset in entry.get("assets", []):
                    checked_object(asset, {"path", "sha256"}, {"path", "sha256"})
                    if asset["path"] in paths or ".." in Path(asset["path"]).parts or "\\" in asset["path"] or ":" in asset["path"] or Path(asset["path"]).is_absolute() or not re.fullmatch(r"[0-9a-f]{64}", asset["sha256"]):
                        raise ValueError("Invalid or duplicate reference asset pin")
                    paths.add(asset["path"])
    checked_object(registry["compiler_authority"], {"id", "version", "commit"}, {"id", "version", "commit"})
    if registry["compiler_authority"] != {"id": "csc", "version": registry["csc_version"], "commit": registry["csc_commit"]}:
        raise ValueError("Compiler authority disagrees with its recorded identity")
    raw_rules = registry.get("raw_source_rules", [])
    if not isinstance(raw_rules, list) or len(set(raw_rules)) != len(raw_rules) or any(not isinstance(r, str) or not RULE_ID.fullmatch(r) for r in raw_rules):
        raise ValueError("Raw-source rules must be distinct registered rule IDs")
    return registry


def lf_lines(raw):
    """Keep every physical byte except LF delimiters; FF and VT do not split records."""
    return raw.decode("utf-8").split("\n")


def csharp_lines(raw):
    """Count C# physical terminators; CRLF is one terminator and FF/VT are whitespace."""
    return [line.decode("utf-8") for line in re.split(rb"\r\n|[\r\n]|\xc2\x85|\xe2\x80[\xa8\xa9]", raw)]


def header_body(raw):
    if not raw.startswith(b"/*\n") or b"\n*/\n" not in raw:
        raise ValueError("Missing opening metadata header")
    header, body = raw[3:].split(b"\n*/\n", 1)
    if not header.isascii() or any(c < 32 and c != 10 for c in header) or 127 in header:
        raise ValueError("Metadata header must be ASCII with LF and no other control bytes")
    return header.decode("ascii"), body


def normalize_case_rows(root, rows, source_texts=None):
    """Give every indexed case an explicit runtime check count; diagnostic-only cases have zero."""
    metadata = {}
    result = []
    for original in rows:
        row = dict(original)
        test_id = row["test_id"]
        if test_id not in metadata:
            clause, rule, stem = test_id.split("--")
            raw = (source_texts[test_id].encode("ascii") if source_texts and test_id in source_texts else
                   inside(Path(root), f"clauses/{clause}/tests/{rule}/{stem}.cs").read_bytes())
            header, _ = header_body(raw)
            values = dict(line.split(": ", 1) for line in header.split("\n"))
            observations = {o["case_id"] for o in json.loads(values.get("Source-Diagnostic", "[]"))}
            metadata[test_id] = (values["Expected"], observations)
        expected, observations = metadata[test_id]
        row.setdefault("checks", "0" if expected == "reject" or row["case_id"] in observations else "1")
        if not re.fullmatch(r"0|[1-9][0-9]*", row["checks"]):
            raise ValueError("Invalid case check count: " + test_id)
        result.append(row)
    return result


@lru_cache(maxsize=None)
def raw_sources(suite_id="ecma-334"):
    path = standard_root(suite_id) / "raw-source.tsv"
    rows = read_tsv(path, RAW_FIELDS) if path.exists() else []
    if len({r["path"] for r in rows}) != len(rows):
        raise ValueError("Duplicate raw-source path")
    allowed_rules = set(source_registry(suite_id).get("raw_source_rules", []))
    for row in rows:
        if row["rule_id"] not in allowed_rules or not row["reason"]:
            raise ValueError("Raw-source exception exceeds the declared vocabulary: " + row["path"])
        suite_path(row["path"], suite_id)
    return {r["path"]: r for r in rows}


def validate_raw_source(raw, entry):
    _, body = header_body(raw)
    body_start = len(raw) - len(body)
    if hashlib.sha256(raw).hexdigest() != entry["source_sha256"]:
        raise ValueError("Raw-source hash is stale: " + entry["path"])
    sequences = json.loads(entry["byte_sequences_json"])
    if not isinstance(sequences, list) or not sequences:
        raise ValueError("Raw-source inventory has no byte sequences")
    covered, eof = set(), False
    for sequence in sequences:
        if set(sequence) != {"hex", "offsets"}:
            raise ValueError("Raw-source sequence requires hex and offsets")
        value, offsets = bytes.fromhex(sequence["hex"]), sequence["offsets"]
        if not isinstance(offsets, list) or not offsets or any(type(n) is not int for n in offsets):
            raise ValueError("Raw-source offsets must be nonempty integer lists")
        if not value:
            if offsets != [len(raw)] or raw.endswith(b"\n"):
                raise ValueError("Invalid missing-final-newline inventory")
            eof = True
            continue
        if not any(c >= 128 or c in {9, 13, 26} for c in value):
            raise ValueError("Raw-source inventory lists no exceptional bytes")
        actual = [n for n in range(body_start, len(raw)) if raw.startswith(value, n)]
        if actual != offsets:
            raise ValueError("Raw-source positions differ from bytes: " + entry["path"])
        for n in offsets:
            covered.update(range(n, n + len(value)))
    exceptional = {n for n, c in enumerate(raw) if c >= 128 or c in {9, 13, 26}}
    if not exceptional <= covered or (not raw.endswith((b"\n", b"\x1a")) and not eof):
        raise ValueError("Unlisted exceptional bytes or missing final LF: " + entry["path"])
    body.decode("utf-8")


def mutation_bytes(value, raw_source=False):
    literal = value.encode("ascii")
    if not raw_source:
        return literal
    result, n = bytearray(), 0
    while n < len(literal):
        if literal[n:n + 2] == b"\\x":
            if not re.fullmatch(rb"[0-9a-fA-F]{2}", literal[n + 2:n + 4]):
                raise ValueError("Raw mutation \\x requires two hexadecimal digits")
            result.append(int(literal[n + 2:n + 4], 16))
            n += 4
        else:
            result.append(literal[n])
            n += 1
    return bytes(result)


def mutated_source(test, raw):
    _, body = header_body(raw)
    is_raw = test["path"] in raw_sources(test.get("suite_id", "ecma-334"))
    old, new = (mutation_bytes(test[k], is_raw) for k in ("mutation_old", "mutation_new"))
    if not old or old == new or body.count(old) != 1:
        raise ValueError("Mutation must occur once and change its byte span")
    return raw[:len(raw) - len(body)] + body.replace(old, new, 1)


def public_level(value):
    value = value.lower()
    aliases = {"iso-1": "1", "iso-2": "2", "7.0": "7"}
    aliases.update({str(n) + ".0": str(n) for n in range(8, 16)})
    value = aliases.get(value, value)
    if value not in {"1", "2", "3", "4", "5", "6", "7", "7.1", "7.2", "7.3", "8", "9", "10", "11", "12",
                     "13", "14", "15", "default", "latest", "latestmajor", "preview"}:
        raise ValueError("Unrecognized language version: " + value)
    return value


def checked_object(value, allowed, required=()):
    if not isinstance(value, dict) or set(value) - set(allowed) or set(required) - set(value):
        raise ValueError("Invalid object fields: " + repr(value))


def fixture_info(fixture, suite_id, clause, is_raw, source_diagnostics):
    checked_object(fixture, {"libraries", "program", "arguments", "target_requires"})
    libraries = fixture.get("libraries", [])
    if not isinstance(libraries, list):
        raise ValueError("Fixture libraries must be an array")
    previous, dependencies = set(), []
    stages = [*libraries, fixture.get("program", {})]
    for index, stage in enumerate(stages):
        library = index < len(libraries)
        checked_object(stage, {"name", "units", "references"} if library else {"units", "references", "entry_point"},
                       {"name", "units"} if library else ())
        name = stage.get("name", "program")
        if library and (not isinstance(name, str) or not IDENTIFIER.fullmatch(name) or name in previous or name == "program"):
            raise ValueError("Invalid or repeated fixture library name")
        units = stage.get("units", [{"source": "self"}])
        if not isinstance(units, list) or not units:
            raise ValueError("Fixture units must be a nonempty array")
        for unit in units:
            checked_object(unit, {"source", "defines"}, {"source"})
            defines = unit.get("defines", [])
            if not isinstance(defines, list) or len(set(defines)) != len(defines) or any(
                    not isinstance(d, str) or not IDENTIFIER.fullmatch(d) for d in defines):
                raise ValueError("Fixture defines must be distinct identifiers")
            source = unit["source"]
            if source != "self":
                if not isinstance(source, str) or not source.endswith(".cs.part"):
                    raise ValueError("Fixture sidecar must be a clause-relative .cs.part")
                path = inside(standard_root(suite_id) / "clauses" / clause, source)
                raw = path.read_bytes()
                if not raw.isascii() or b"\r" in raw or b"\t" in raw or not raw.endswith(b"\n"):
                    raise ValueError("Fixture sidecar must be ASCII, LF and without tabs")
                dependencies.append({"path": source, "sha256": sha(path)})
            if defines and (source_diagnostics or (is_raw and source == "self")):
                raise ValueError("Prepended defines cannot be used with Source-Diagnostic or inventoried raw source")
        references = stage.get("references", [])
        if not isinstance(references, list):
            raise ValueError("Fixture references must be an array")
        for reference in references:
            checked_object(reference, {"library", "asset", "alias"})
            if ("library" in reference) == ("asset" in reference):
                raise ValueError("A fixture reference names exactly one library or target asset")
            if "library" in reference and reference["library"] not in previous:
                raise ValueError("A fixture reference must name an earlier library")
            if "asset" in reference and (not isinstance(reference["asset"], str)
                                         or Path(reference["asset"]).name != reference["asset"]):
                raise ValueError("Target reference assets are simple filenames")
            if "alias" in reference and not IDENTIFIER.fullmatch(reference["alias"]):
                raise ValueError("Invalid extern alias")
        entry_point = stage.get("entry_point")
        if entry_point is not None and (not isinstance(entry_point, str) or not re.fullmatch(
                r"[A-Za-z_][A-Za-z_0-9]*(?:\.[A-Za-z_][A-Za-z_0-9]*)*", entry_point)):
            raise ValueError("Invalid fixture entry-point type")
        previous.add(name)
    for key in ("arguments", "target_requires"):
        values = fixture.get(key, [])
        if not isinstance(values, list) or any(not isinstance(v, str) or "\0" in v for v in values):
            raise ValueError("Fixture " + key + " must be an array of strings")
        if key == "target_requires" and any(not re.fullmatch(r"[a-z][a-z0-9]*(?:-[a-z0-9]+)*", v) for v in values):
            raise ValueError("Target capabilities must be kebab-case names")
    return digest({"fixture": fixture, "dependencies": dependencies})


def parse_test(path, suite_id="ecma-334"):
    path = canonical(path)
    relative = path.relative_to(standard_root(suite_id))
    if len(relative.parts) != 5 or relative.parts[0] != "clauses" or relative.parts[2] != "tests":
        raise ValueError("Wrong test location: " + str(relative))
    raw = path.read_bytes()
    entry = raw_sources(suite_id).get(relative.as_posix())
    if entry:
        validate_raw_source(raw, entry)
    elif not raw.isascii() or b"\r" in raw or b"\t" in raw or not raw.endswith(b"\n"):
        raise ValueError("Test must be ASCII, LF, without tabs, and end in LF: " + str(relative))
    header, body = header_body(raw)
    pairs = [line.partition(": ") for line in header.split("\n")]
    metadata = {key: value for key, _, value in pairs}
    keys = [key for key, _, _ in pairs]
    if any(not sep for _, sep, _ in pairs) or len(keys) != len(metadata) or any(k not in HEADER_KEYS for k in keys):
        raise ValueError("Malformed, duplicate or unknown header key: " + str(relative))
    if keys != [k for k in HEADER_KEYS if k in metadata] or keys[:4] != HEADER_KEYS[:4]:
        raise ValueError("Header order is invalid: " + str(relative))
    expected = metadata["Expected"]
    if expected not in {"run", "reject"}:
        raise ValueError("Expected must be run or reject")
    if expected == "run" and not re.fullmatch(r"OK (?:0|[1-9][0-9]*)", metadata.get("Stdout", "")):
        raise ValueError("Run Stdout must pin the count: " + str(relative))
    if expected == "reject" and "Stdout" in metadata:
        raise ValueError("A reject test cannot have Stdout")
    diagnostic = metadata.get("Diagnostic", "")
    if "Diagnostic" in metadata and (diagnostic not in {"warning", "none"} or expected != "run"):
        raise ValueError("Diagnostic requires a run test and warning or none")
    ids = metadata["Rules"].split("; ")
    if len(ids) != len(set(ids)) or any(not RULE_ID.fullmatch(i) for i in ids):
        raise ValueError("Invalid or repeated Rules")
    if relative.parts[3] != ids[0] or not re.fullmatch(r"[a-z0-9]+(?:-[a-z0-9]+)*", path.stem):
        raise ValueError("Invalid primary rule folder or source filename")
    if entry and entry["rule_id"] != ids[0]:
        raise ValueError("Raw-source inventory does not name the primary rule")
    public_level(metadata["Version"])
    authority = metadata["Authority"]
    registry = source_registry(suite_id)
    edition = next((e for e in registry["editions"] if e["role"] == "primary" and authority.startswith(e["authority_prefix"] + " ")), None)
    compiler = re.fullmatch(r"csc ([^ ]+) \(C# ([^)]+)\)", authority)
    if edition:
        subclause = authority.removeprefix(edition["authority_prefix"] + " ")
        if not re.fullmatch(r"\d+(?:\.\d+)*", subclause) or not ids[0].startswith("E" + subclause.replace(".", "-") + "-"):
            raise ValueError("Authority does not locate the primary rule")
        if public_level(metadata["Version"]) != public_level(edition["language_version"]):
            raise ValueError("Standard test has the wrong header Version")
    elif compiler:
        if compiler[1] != registry["csc_version"] or compiler[2] != metadata["Version"] or not ids[0].startswith("P"):
            raise ValueError("Feature authority is not the pinned compiler/version")
    else:
        raise ValueError("Unrecognized Authority: " + authority)
    generated = "Generated" in metadata
    old, new, generator = (metadata.get(k, "") for k in ("Mutate", "Into", "Generated"))
    if generated:
        script = suite_path(generator, suite_id)
        if "Mutate" in metadata or "Into" in metadata or not script.is_file() or script.suffix != ".py" or script.parent.name != "generators":
            raise ValueError("Generated test must name only its existing generator")
    elif "Into" not in metadata or not old or body.count(mutation_bytes(old, bool(entry))) != 1 or mutation_bytes(old, bool(entry)) == mutation_bytes(new, bool(entry)):
        raise ValueError("Mutation must replace a distinct body substring once: " + str(relative))
    csc = metadata.get("Csc", "")
    if "Csc" in metadata and (expected != "reject" or not re.fullmatch(r"CS\d{4}(?:; CS\d{4})*", csc)):
        raise ValueError("Csc is informational and allowed only on reject tests")
    requirements = metadata.get("Requirements", "").split("; ") if "Requirements" in metadata else []
    if len(set(requirements)) != len(requirements) or any(r not in REQUIREMENTS for r in requirements):
        raise ValueError("Unrecognized or duplicate requirement")
    observations = json.loads(metadata.get("Source-Diagnostic", "[]"))
    if not isinstance(observations, list) or ("Source-Diagnostic" in metadata and not observations):
        raise ValueError("Source-Diagnostic must be a nonempty array")
    names = set()
    for o in observations:
        checked_object(o, {"case_id", "source", "severity", "file", "line", "contains"},
                       {"case_id", "source", "severity", "file", "line"})
        if not isinstance(o["case_id"], str) or not o["case_id"] or o["case_id"] in names or o["severity"] not in {"error", "warning"}:
            raise ValueError("Invalid source diagnostic identity/severity")
        names.add(o["case_id"])
        if not isinstance(o["source"], str) or csharp_lines(body).count(o["source"]) != 1:
            raise ValueError("Source diagnostic must identify one complete body line")
        if o["line"] != "physical" and (type(o["line"]) is not int or o["line"] <= 0):
            raise ValueError("Source diagnostic line must be physical or positive")
        if not isinstance(o["file"], str) or not o["file"] or "\0" in o["file"]:
            raise ValueError("Source diagnostic file must be physical or a logical filename")
        if "contains" in o and (not isinstance(o["contains"], str) or not re.match(r"\s*#(?:error|warning)\b", o["source"])):
            raise ValueError("Only tested directive payloads may constrain a diagnostic message")
    fixture = json.loads(metadata.get("Fixture", "{}"))
    fixture_hash = fixture_info(fixture, suite_id, relative.parts[1], bool(entry), observations)
    witness = metadata.get("Version-Witness", "")
    if witness:
        if not witness.endswith(".cs.part") or not inside(standard_root(suite_id) / "clauses" / relative.parts[1], witness).is_file():
            raise ValueError("Version-Witness must be an existing clause-relative .cs.part")
    return dict(zip(MANIFEST_FIELDS, [suite_id, "--".join([relative.parts[1], ids[0], path.stem]), relative.as_posix(),
        ";".join(ids), authority, metadata["Version"], expected, json.dumps(metadata["Stdout"] + "\n" if expected == "run" else ""),
        "generated" if generated else "handwritten", old, new, csc, generator, sha(path), diagnostic,
        json.dumps(requirements), json.dumps(fixture, sort_keys=True), json.dumps(observations, sort_keys=True), witness,
        fixture_hash, "missing", "", "", ""]))


def scan_tests(suite_id="ecma-334"):
    root = standard_root(suite_id)
    rows = [parse_test(p, suite_id) for p in sorted((root / "clauses").glob("*/tests/*/*.cs"))]
    actual = {canonical(p) for p in (root / "clauses").rglob("*.cs")}
    if actual != {suite_path(r["path"], suite_id) for r in rows} or len({r["test_id"] for r in rows}) != len(rows):
        raise ValueError("Unscanned C# file or duplicate derived test ID")
    return rows


def structural_provenance():
    try:
        commit = subprocess.check_output(["git", "-C", str(ROOT), "rev-parse", "HEAD"], stderr=subprocess.DEVNULL, text=True).strip()
    except (OSError, subprocess.SubprocessError):
        commit = None
    return {"command": [sys.executable, *sys.argv], "suite_commit": commit,
            "target": sys.platform + "; source-file audit; no compiler execution",
            "tool_sha256": sha(Path(sys.argv[0]).resolve()), "support_sha256": sha(Path(__file__))}


def load_manifest(path=None, suite_id="ecma-334", require_versions=False):
    from suite_versions import joined_tests
    path = Path(path or standard_root(suite_id) / "manifest.tsv")
    rows = read_manifest(path)
    expected = joined_tests(suite_id)
    if rows != expected:
        raise ValueError("Manifest is stale or was edited by hand: " + suite_id)
    if require_versions and any(r["version_status"] != "current" for r in rows):
        raise ValueError("Current version metadata is required for every selected test")
    return rows


def read_manifest(path):
    """Load a hashed clause inventory, or an archived full TSV manifest."""
    path = Path(path)
    with path.open(encoding="utf-8", newline="") as stream:
        fields = next(csv.reader(stream, delimiter="\t"))
    if fields == MANIFEST_FIELDS:
        return read_tsv(path, MANIFEST_FIELDS)
    entries = read_tsv(path, ["path", "sha256", "rows"])
    rows, paths = [], []
    for entry in entries:
        relative = entry["path"]
        if (not re.fullmatch(r"manifest/[0-9]{2}-[a-z0-9]+(?:-[a-z0-9]+)*\.tsv", relative)
                or relative in paths or not re.fullmatch(r"[0-9a-f]{64}", entry["sha256"])
                or not re.fullmatch(r"[1-9][0-9]*", entry["rows"])):
            raise ValueError("Invalid manifest shard descriptor")
        shard = inside(path.parent, relative)
        if sha(shard) != entry["sha256"]:
            raise ValueError("Manifest shard hash differs: " + relative)
        group = read_tsv(shard, MANIFEST_FIELDS)
        clause = shard.stem
        if len(group) != int(entry["rows"]) or any(row["path"].split("/")[1] != clause for row in group):
            raise ValueError("Manifest shard count or owning clause differs")
        paths.append(relative)
        rows.extend(group)
    actual = sorted(p.relative_to(path.parent).as_posix() for p in (path.parent / "manifest").glob("*.tsv"))
    if paths != sorted(paths) or actual != paths:
        raise ValueError("Manifest shard inventory differs from the index")
    return rows


def write_manifest(path, rows):
    """Generate stable clause TSVs and their exact-byte hash index."""
    path = Path(path)
    groups = {}
    for row in rows:
        clause = row["path"].split("/")[1]
        if not re.fullmatch(r"[0-9]{2}-[a-z0-9]+(?:-[a-z0-9]+)*", clause):
            raise ValueError("Invalid manifest clause")
        groups.setdefault("manifest/" + clause + ".tsv", []).append(row)
    entries, outputs = [], {}
    for relative, group in sorted(groups.items()):
        data = tsv_text(group, MANIFEST_FIELDS).encode("ascii")
        outputs[relative] = data
        entries.append({"path": relative, "sha256": hashlib.sha256(data).hexdigest(), "rows": len(group)})
    outputs[path.name] = tsv_text(entries, ["path", "sha256", "rows"]).encode("ascii")
    if any(len(data) * 3 > 20 * 1024 * 1024 for data in outputs.values()):
        raise ValueError("Generated manifest lacks threefold file-size headroom")
    for relative, data in outputs.items():
        shard = path.parent / relative
        if not shard.is_file() or shard.read_bytes() != data:
            write_bytes(shard, data)
    for shard in (path.parent / "manifest").glob("*.tsv"):
        if shard.relative_to(path.parent).as_posix() not in outputs:
            shard.unlink()


def read_rules(suite_id="ecma-334"):
    rules = {}
    for path in sorted((standard_root(suite_id) / "clauses").glob("*/rules.tsv")):
        for row in read_tsv(path, RULE_FIELDS):
            if row["rule_id"] in rules:
                raise ValueError("Duplicate rule ID: " + row["rule_id"])
            rules[row["rule_id"]] = dict(row, ledger=path.relative_to(standard_root(suite_id)).as_posix())
    return rules


def emit_audit(path, data, provenance=None):
    result = {"completed_utc": utc(), "provenance": provenance or structural_provenance(), **data}
    write_json(path, result)
    print(json.dumps({k: v for k, v in data.items() if k not in {"rows", "suites", "errors", "uncovered_rule_ids", "provenance"}}, sort_keys=True))
    errors = data.get("errors", [])
    for error in errors[:20]:
        print(error, file=sys.stderr)
    if len(errors) > 20:
        print(f"{len(errors) - 20} further errors are recorded in the report", file=sys.stderr)
    return result


def main_guard(action):
    try:
        return action()
    except (OSError, ValueError, KeyError, TypeError, subprocess.SubprocessError) as error:
        print("SUITE-ERROR " + str(error), file=sys.stderr)
        return 3
