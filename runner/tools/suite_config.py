"""Validate pinned compiler/target configurations and expand argv without a shell."""
from __future__ import annotations

import json
import os
import platform
import re
import shutil
import struct
import string
import sys
from pathlib import Path

from suite_common import canonical, checked_object, digest, public_level, sha

EXPLICIT_LEVELS = ["1", "2", "3", "4", "5", "6", "7", "7.1", "7.2", "7.3", "8", "9", "10", "11", "12", "13", "14", "15"]
SYMBOLS = ["default", "latest", "latestmajor", "preview"]
CODE = re.compile(r"[A-Za-z][A-Za-z0-9_-]*\Z")
HEX = re.compile(r"[0-9a-f]{64}\Z")
NAME = re.compile(r"[a-z][a-z0-9_-]*\Z")
HOST_RIDS = {("win32", "x64"): "win-x64", ("linux", "x64"): "linux-x64",
             ("darwin", "arm64"): "osx-arm64", ("linux", "arm64"): "linux-arm64"}


def host_rid():
    machine = platform.machine().lower()
    architecture = {"amd64": "x64", "x86_64": "x64", "aarch64": "arm64", "arm64": "arm64"}.get(machine)
    rid = HOST_RIDS.get((sys.platform, architecture))
    if rid is None or struct.calcsize("P") != 8:
        raise ValueError("No pinned assets for this host: " + sys.platform + "/" + machine)
    return rid


def validate_platforms(config, check_host):
    if "platforms" in config:
        strings(config["platforms"], nonempty=True, distinct=True)
        if check_host and sys.platform not in config["platforms"]:
            raise ValueError("This configuration does not support host platform " + sys.platform)


def asset_entries(config, rid=None):
    """Select one complete pin set; never fall back to another platform's pins."""
    selected = {}
    for name, entry in config["files"].items():
        if "variants" in entry:
            rid = rid or host_rid()
            if rid not in entry["variants"]:
                raise ValueError("No pinned asset variant for " + rid + ": " + name)
            selected[name] = {"root": entry["root"], **entry["variants"][rid]}
        else:
            selected[name] = entry
    return selected


def strings(value, nonempty=False, distinct=False):
    if not isinstance(value, list) or (nonempty and not value) or any(
            not isinstance(v, str) or "\0" in v for v in value) or (distinct and len(value) != len(set(value))):
        raise ValueError("Expected an array of strings: " + repr(value))
    return value


def argv_template(value, scalars, arrays=()):
    strings(value, nonempty=True)
    formatter = string.Formatter()
    for token in value:
        for _, name, spec, conversion in formatter.parse(token):
            if name is None:
                continue
            if spec or conversion or name not in set(scalars) | set(arrays):
                raise ValueError("Unknown argv placeholder: " + token)
            if name in arrays and token != "{" + name + "}":
                raise ValueError("List argv placeholders must occupy an entire token: " + token)


def expand(template, values, arrays=None):
    arrays = arrays or {}
    result = []
    for token in template:
        if token in {"{" + key + "}" for key in arrays}:
            result.extend(arrays[token[1:-1]])
        else:
            result.append(token.format_map(values))
    return result


def validate_discovery(config):
    roots = config["discovery"]
    if not isinstance(roots, dict) or not roots:
        raise ValueError("Discovery must name at least one asset root")
    for name, root in roots.items():
        if not NAME.fullmatch(name):
            raise ValueError("Invalid discovery root name")
        checked_object(root, {"kind", "environment"}, {"kind"})
        if root["kind"] not in {"config", "dotnet", "environment", "netframework-reference"}:
            raise ValueError("Unknown discovery kind")
        variables = strings(root.get("environment", []), distinct=True)
        if any(not re.fullmatch(r"[A-Z][A-Z0-9_]*", v) for v in variables):
            raise ValueError("Discovery environment names must be uppercase")
        if root["kind"] == "environment" and not variables:
            raise ValueError("Environment discovery needs an environment variable")
    files = config["files"]
    if not isinstance(files, dict) or not files:
        raise ValueError("A configuration must pin its executable/assets")
    variant_rids = None
    for name, entry in files.items():
        if not NAME.fullmatch(name):
            raise ValueError("Invalid asset name")
        variant = "variants" in entry
        fields = {"root", "variants"} if variant else {"root", "path", "sha256"}
        checked_object(entry, fields, fields)
        if entry["root"] not in roots:
            raise ValueError("Invalid pinned asset root")
        if variant:
            variants = entry["variants"]
            if not isinstance(variants, dict) or not variants or set(variants) - set(HOST_RIDS.values()):
                raise ValueError("Asset variants must name supported host RIDs")
            if variant_rids is not None and set(variants) != variant_rids:
                raise ValueError("Every asset variant matrix must cover the same host RIDs")
            variant_rids = set(variants)
            for pin in variants.values():
                checked_object(pin, {"path", "sha256"}, {"path", "sha256"})
        else:
            variants = {"common": entry}
        for pin in variants.values():
            if not isinstance(pin["path"], str) or not pin["path"] or "\0" in pin["path"]:
                raise ValueError("Invalid pinned asset path")
            if Path(pin["path"]).is_absolute() or re.match(r"(?:[A-Za-z]:|[/\\])", pin["path"]):
                raise ValueError("Pinned assets must use paths relative to their discovery root")
            if not isinstance(pin["sha256"], str) or not HEX.fullmatch(pin["sha256"]):
                raise ValueError("Pinned assets require a lowercase SHA-256")


def validate_compiler(config, check_host=True):
    checked_object(config, {"schema_version", "id", "version", "commit", "discovery", "files", "command",
        "arguments", "requirements", "language", "diagnostics", "rejection_exit_codes", "artifact_extension", "platforms"},
        {"schema_version", "id", "version", "commit", "discovery", "files", "command", "arguments", "requirements",
         "language", "diagnostics", "rejection_exit_codes", "artifact_extension"})
    if type(config["schema_version"]) is not int or config["schema_version"] != 1:
        raise ValueError("Unsupported compiler schema version")
    for key in ("id", "version", "commit"):
        if not isinstance(config[key], str) or not config[key]:
            raise ValueError("Missing compiler identity: " + key)
    validate_platforms(config, check_host)
    validate_discovery(config)
    argv_template(config["command"], [*config["files"], "level", "output"],
                  ["sources", "references", "requirements", "kind", "entry_point"])
    if config["command"][0] not in {"{" + name + "}" for name in config["files"]}:
        raise ValueError("Compiler executable must be a pinned asset placeholder")
    for token in ("{sources}", "{references}", "{requirements}", "{kind}", "{entry_point}"):
        if config["command"].count(token) != 1:
            raise ValueError("Compiler command needs one " + token)
    if not any("{level}" in token for token in config["command"]) or not any("{output}" in token for token in config["command"]):
        raise ValueError("Compiler command must set level and output")
    args = config["arguments"]
    checked_object(args, {"kinds", "entry_point", "reference", "alias_reference"}, {"kinds", "entry_point", "reference", "alias_reference"})
    checked_object(args["kinds"], {"exe", "library"}, {"exe", "library"})
    for value in args["kinds"].values():
        if value is not None:
            argv_template(value, [])
    for key, names in [("entry_point", ["name"]), ("reference", ["path"]), ("alias_reference", ["alias", "path"])]:
        if args[key] is not None:
            argv_template(args[key], names)
    if not isinstance(config["requirements"], dict):
        raise ValueError("Requirements must be a mapping")
    from suite_common import REQUIREMENTS
    for name, value in config["requirements"].items():
        if name not in REQUIREMENTS:
            raise ValueError("Unknown compiler requirement: " + name)
        strings(value)
        if any("{" in v or "}" in v for v in value):
            raise ValueError("Requirement mappings contain literal argv only")
    language = config["language"]
    checked_object(language, {"explicit", "symbolic", "unsupported", "probe"}, {"explicit", "symbolic", "unsupported", "probe"})
    if not isinstance(language["explicit"], dict) or set(language["explicit"]) - set(EXPLICIT_LEVELS):
        raise ValueError("Language explicit versions must be canonical numeric names")
    if any(not isinstance(v, str) or not v for v in language["explicit"].values()):
        raise ValueError("Language argument names must be strings")
    strings(language["unsupported"], distinct=True)
    if set(language["unsupported"]) != set(EXPLICIT_LEVELS) - set(language["explicit"]):
        raise ValueError("Every explicit level must be supported or declared unsupported")
    checked_object(language["symbolic"], SYMBOLS, SYMBOLS)
    for name, mapping in language["symbolic"].items():
        if mapping is None:
            continue
        checked_object(mapping, {"level", "argument", "mode"}, {"level", "argument", "mode"})
        if mapping["level"] not in language["explicit"] or mapping["mode"] not in {"explicit", "preview"}:
            raise ValueError("Symbolic mapping must name a supported base level and mode")
        if not isinstance(mapping["argument"], str) or not mapping["argument"]:
            raise ValueError("Symbolic mapping needs an argument spelling")
        if name != "preview" and mapping["mode"] != "explicit":
            raise ValueError("Only preview may enable preview semantics")
    if not isinstance(language["probe"], dict) or not language["probe"]:
        raise ValueError("Language mappings need probe or source provenance")
    diagnostics = config["diagnostics"]
    checked_object(diagnostics, {"patterns", "information_pattern", "feature_refusal_codes", "version_feature_codes", "command_line_codes"},
                   {"patterns", "information_pattern", "feature_refusal_codes", "version_feature_codes", "command_line_codes"})
    for pattern in strings(diagnostics["patterns"], nonempty=True):
        compiled = re.compile(pattern, re.IGNORECASE)
        if not {"severity", "code", "message"} <= set(compiled.groupindex):
            raise ValueError("Diagnostic patterns must name severity, code and message")
    if diagnostics["information_pattern"] is not None:
        re.compile(diagnostics["information_pattern"])
    for key in ("feature_refusal_codes", "version_feature_codes", "command_line_codes"):
        if any(not CODE.fullmatch(code) for code in strings(diagnostics[key], distinct=True)):
            raise ValueError("Invalid diagnostic code list")
    exits = config["rejection_exit_codes"]
    if not isinstance(exits, list) or not exits or len(exits) != len(set(exits)) or any(type(v) is not int or v <= 0 for v in exits):
        raise ValueError("Rejection exit codes must be positive integers")
    if not re.fullmatch(r"\.[a-z0-9]+", config["artifact_extension"]):
        raise ValueError("Invalid artifact extension")


def validate_target(config, check_host=True):
    fields = {"schema_version", "id", "description", "adapter", "platforms", "discovery", "files", "references",
              "capabilities", "build", "command", "batch_size"}
    checked_object(config, fields | {"architectures", "runtime"}, fields)
    if type(config["schema_version"]) is not int or config["schema_version"] != 1 or config["adapter"] not in {"dotnet", "netframework", "external-batch"}:
        raise ValueError("Unsupported target schema/adapter")
    if any(not isinstance(config[k], str) or not config[k] for k in ("id", "description")):
        raise ValueError("Target needs an identity and description")
    validate_platforms(config, check_host)
    if "architectures" in config:
        if strings(config["architectures"], nonempty=True, distinct=True) != ["x64"]:
            raise ValueError("Only the x64 target architecture is supported")
        if check_host and (platform.machine().lower() not in {"amd64", "x86_64"} or struct.calcsize("P") != 8):
            raise ValueError("This target requires an x64 host and an x64 Python process")
    if config["adapter"] == "netframework":
        runtime = config.get("runtime", {})
        checked_object(runtime, {"kind", "minimum_release"}, {"kind", "minimum_release"})
        if (config["platforms"] != ["win32"] or config.get("architectures") != ["x64"]
                or runtime["kind"] != "netframework" or type(runtime["minimum_release"]) is not int
                or runtime["minimum_release"] < 533320):
            raise ValueError("Framework targets require Windows x64 and at least .NET Framework 4.8.1")
    elif "runtime" in config:
        raise ValueError("Serviced runtime discovery is only supported by the Framework adapter")
    validate_discovery(config)
    strings(config["capabilities"], distinct=True)
    if any(not re.fullmatch(r"[a-z][a-z0-9]*(?:-[a-z0-9]+)*", v) for v in config["capabilities"]):
        raise ValueError("Target capabilities must be kebab-case")
    if not isinstance(config["references"], dict):
        raise ValueError("Target references must map filenames to pinned assets")
    for name, asset in config["references"].items():
        if Path(name).name != name or not name.endswith(".dll") or asset not in config["files"]:
            raise ValueError("Invalid target reference asset")
    build = config["build"]
    checked_object(build, {"kinds", "framework", "runtime_version", "tfm", "runtimeconfig", "artifact_extension"}, {"kinds", "runtimeconfig"})
    if any(k not in {"exe", "library"} for k in strings(build["kinds"], nonempty=True, distinct=True)):
        raise ValueError("Invalid target build kinds")
    if type(build["runtimeconfig"]) is not bool:
        raise ValueError("Runtimeconfig must be a boolean")
    if "artifact_extension" in build and not re.fullmatch(r"\.[a-z0-9]+", build["artifact_extension"]):
        raise ValueError("Invalid target artifact extension")
    if config["adapter"] == "netframework" and (build["runtimeconfig"] or build.get("artifact_extension") != ".exe"):
        raise ValueError("Framework programs must be direct executables without a runtimeconfig")
    if build["runtimeconfig"] and any(not isinstance(build.get(k), str) or not build[k]
                                       for k in ("framework", "runtime_version", "tfm")):
        raise ValueError("Runtimeconfig target must pin framework, runtime version and TFM")
    if type(config["batch_size"]) is not int or config["batch_size"] < 1:
        raise ValueError("Target batch_size must be positive")
    direct = config["adapter"] in {"dotnet", "netframework"}
    argv_template(config["command"], [*config["files"], "entry"] if direct
                  else [*config["files"], "request", "response"], ["arguments"] if direct else [])
    if config["command"][0] not in ({"{entry}"} if config["adapter"] == "netframework" else {"{" + name + "}" for name in config["files"]}):
        raise ValueError("Target executable must be a pinned asset placeholder")
    required = ["{entry}", "{arguments}"] if direct else ["{request}", "{response}"]
    if any(config["command"].count(token) != 1 for token in required):
        raise ValueError("Target command is missing required adapter placeholders")


def dotnet_roots(variables):
    for name in variables:
        if os.environ.get(name):
            yield canonical(os.environ[name])
    executable = shutil.which("dotnet")
    if executable:
        yield canonical(executable).parent


def read_config(path, kind, *, check_host=True):
    config = json.loads(canonical(path).read_text(encoding="utf-8"))
    (validate_compiler if kind == "compiler" else validate_target)(config, check_host=check_host)
    return config


def load_config(path, kind):
    path = canonical(path)
    config = read_config(path, kind)
    entries = asset_entries(config)
    roots, files, identities = {}, {}, {}
    for name, discovery in config["discovery"].items():
        if discovery["kind"] == "config":
            candidates = [path.parent]
        elif discovery["kind"] == "dotnet":
            candidates = list(dotnet_roots(discovery.get("environment", [])))
        elif discovery["kind"] == "netframework-reference":
            from suite_netframework import reference_roots
            candidates = list(reference_roots(discovery.get("environment", [])))
        else:
            candidates = [canonical(os.environ[v]) for v in discovery["environment"] if os.environ.get(v)]
        required = {key: entry for key, entry in entries.items() if entry["root"] == name}
        root = next((p for p in candidates if all((p / e["path"]).is_file() for e in required.values())), None)
        if root is None:
            raise ValueError("Pinned assets not installed under discovery root " + name)
        roots[name] = root
    for name, entry in entries.items():
        asset = canonical(roots[entry["root"]] / entry["path"])
        actual = sha(asset)
        if actual != entry["sha256"]:
            raise ValueError("Pinned asset hash differs: " + str(asset))
        files[name] = str(asset)
        identities[name] = {"path": str(asset), "sha256": actual}
    identity = {"config_sha256": sha(path), "id": config["id"], "assets": identities}
    if any("variants" in entry for entry in config["files"].values()):
        identity["rid"] = host_rid()
    if kind == "target" and config["adapter"] == "netframework":
        from suite_netframework import runtime_identity
        identity["runtime"] = runtime_identity(config["runtime"]["minimum_release"])
    return config, files, identity


def resolve_level(config, spelling):
    name = public_level(spelling)
    language = config["language"]
    if name in SYMBOLS:
        row = language["symbolic"][name]
        return None if row is None else dict(row, requested=spelling,
            level=row["level"] + ("-preview" if row["mode"] == "preview" else ""))
    if name not in language["explicit"]:
        return None
    return {"level": name, "argument": language["explicit"][name], "mode": "explicit", "requested": spelling}


def select_levels(config, selectors):
    """Resolve explicit lists and inclusive ranges in configuration level order."""
    names = [name.strip() for item in selectors for name in item.split(",")]
    if not names or any(not name for name in names):
        raise ValueError("Choose at least one language selector")
    special = {"all", "earliest-per-test", "declared-per-test"}
    if any(name.lower() in special for name in names):
        if len(names) != 1:
            raise ValueError("all and per-test selectors cannot be combined with other language selectors")
        selection = names[0].lower()
        if selection != "all":
            return selection, []
    ordered = list(config["language"]["explicit"])
    preview = resolve_level(config, "preview")
    if preview:
        ordered.append("preview")
    resolutions = [resolve_level(config, name) for name in ordered]
    labels = [level["level"] for level in resolutions]

    def supported(name):
        level = resolve_level(config, name)
        if level is None:
            raise ValueError("Requested language level is unsupported: " + name)
        return level

    selected = []
    for name in ordered if names[0].lower() == "all" else names:
        if ".." in name:
            endpoints = name.split("..")
            if len(endpoints) != 2 or not all(part.strip() for part in endpoints):
                raise ValueError("A language range needs two endpoints: " + name)
            lower, upper = [labels.index(supported(part.strip())["level"]) for part in endpoints]
            if lower > upper:
                raise ValueError("Language range endpoints are reversed: " + name)
            levels = resolutions[lower:upper + 1]
        else:
            levels = [supported(name)]
        for level in levels:
            if level["level"] not in [item["level"] for item in selected]:
                selected.append(level)
    return "explicit", selected


def level_tuple(value):
    numbers = value.removesuffix("-preview").split(".")
    return (int(numbers[0]), int(numbers[1]) if len(numbers) > 1 else 0, int(value.endswith("-preview")))
