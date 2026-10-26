"""Registered edition conflicts and selection, independent of compiler verdicts."""
from __future__ import annotations

import json
import re

from suite_common import ROOT, checked_object, sha, source_registry, standard_root
from suite_config import resolve_level
from suite_versions import applicability, unique_object


def registered_editions(suite_id):
    """Only primary editions can supply a run's authority."""
    editions = {}
    prefixes = set()
    for entry in source_registry(suite_id)["editions"]:
        if entry["role"] != "primary":
            continue
        ordinal = re.fullmatch(r"([1-9][0-9]*)(?:st|nd|rd|th)", entry["edition"])
        if not ordinal:
            raise ValueError("Edition needs a numeric ordinal: " + entry["id"])
        number = int(ordinal[1])
        if number in editions or entry["authority_prefix"] in prefixes:
            raise ValueError("Duplicate edition number or authority prefix")
        editions[number] = entry
        prefixes.add(entry["authority_prefix"])
    if not editions:
        raise ValueError("No primary editions registered for " + suite_id)
    return editions


def authority_edition(test, editions):
    return next((number for number, entry in editions.items()
                 if test["authority"].startswith(entry["authority_prefix"] + " ")), None)


def validate_conflicts(table, suite_id, tests):
    """Enforce the schema and the authority of every referenced test ID."""
    fields = {"schema_version", "edition", "base_edition", "conflicts"}
    checked_object(table, fields, fields)
    if type(table["schema_version"]) is not int or table["schema_version"] != 1:
        raise ValueError("Unsupported edition conflict schema")
    editions = registered_editions(suite_id)
    number, base = table["edition"], table["base_edition"]
    if (type(number) is not int or type(base) is not int or number not in editions
            or number == max(editions) or base != max(editions)):
        raise ValueError("Conflict table must pair an older registered edition with the latest edition")
    if not isinstance(table["conflicts"], list):
        raise ValueError("Edition conflicts must be an array")
    inventory = {test["test_id"]: test for test in tests if test["suite_id"] == suite_id}
    pairs, actions = set(), {}
    prefix = editions[number]["authority_prefix"]
    citation = re.compile(re.escape(prefix) + r" [0-9]+(?:\.[0-9]+)*, p\. [0-9]+ \(PDF p\. [0-9]+\)(?:, [^\r\n]+)?\Z")
    for row in table["conflicts"]:
        required = {"action", "test_id", "authority"}
        checked_object(row, required | {"replacement_test_id"}, required)
        if row["action"] not in {"replace", "leave-out"}:
            raise ValueError("Unknown edition conflict action")
        replacement = row.get("replacement_test_id")
        if (row["action"] == "replace") != ("replacement_test_id" in row):
            raise ValueError("Only replace rows require a replacement test ID")
        for test_id in [row["test_id"], *([replacement] if row["action"] == "replace" else [])]:
            if not isinstance(test_id, str) or test_id not in inventory:
                raise ValueError("Unknown edition conflict test ID: " + str(test_id))
        target_edition = authority_edition(inventory[row["test_id"]], editions)
        if target_edition is None or target_edition == number:
            raise ValueError("Conflict target must have another registered edition's authority: " + row["test_id"])
        replacement_edition = authority_edition(inventory[replacement], editions) if replacement else None
        if row["action"] == "replace" and replacement_edition in {None, base}:
            raise ValueError("Replacement must have a registered older edition's authority: " + replacement)
        if not isinstance(row["authority"], str) or not citation.fullmatch(row["authority"]):
            raise ValueError("Conflict authority needs a registered clause and printed/PDF pages")
        if replacement_edition == number and row["authority"].split(",", 1)[0] != inventory[replacement]["authority"]:
            raise ValueError("Conflict citation disagrees with replacement authority: " + replacement)
        pair = (row["test_id"], replacement)
        if pair in pairs:
            raise ValueError("Duplicate edition conflict pair")
        if row["test_id"] in actions and actions[row["test_id"]] != row["action"]:
            raise ValueError("A test cannot be both replaced and left out")
        pairs.add(pair)
        actions[row["test_id"]] = row["action"]
    for _, replacement in pairs:
        if replacement in actions:
            raise ValueError("Replacement cannot be itself replaced or left out: " + replacement)
    return table


def load_conflicts(suite_id, number, tests):
    path = standard_root(suite_id) / "edition-conflicts" / (str(number) + ".json")
    table = validate_conflicts(json.loads(path.read_bytes(), object_pairs_hook=unique_object), suite_id, tests)
    if table["edition"] != number:
        raise ValueError("Edition conflict file name disagrees with its edition")
    return table


def edition_definition(suite_id, number, config, tests):
    editions = registered_editions(suite_id)
    if number not in editions or number == max(editions):
        raise ValueError("Choose a registered non-latest edition for " + suite_id + ": "
                         + ", ".join(str(n) for n in sorted(editions) if n != max(editions)))
    entry = editions[number]
    level = resolve_level(config, entry["language_version"])
    if level is None:
        raise ValueError("Compiler does not support edition " + str(number) + " at " + entry["language_version"])
    table = load_conflicts(suite_id, number, tests)
    path = standard_root(suite_id) / "edition-conflicts" / (str(number) + ".json")
    return {"edition": number, "source_id": entry["id"], "language_version": entry["language_version"],
            "level": level, "conflict_table": {"path": path.relative_to(ROOT).as_posix(), "sha256": sha(path)},
            "table": table}


def version_inventory(tests):
    """Version runs keep the latest standard edition and compiler authority."""
    registries = {suite_id: registered_editions(suite_id) for suite_id in {test["suite_id"] for test in tests}}
    return [test for test in tests
            if authority_edition(test, registries[test["suite_id"]]) in {None, max(registries[test["suite_id"]])}]


def edition_inventory(tests, definitions):
    """Keep own authority, then continuity inside measured intervals, minus conflicts."""
    decisions = {suite_id: {name: [] for name in ["own_test_ids", "continuity_test_ids", "replaced_test_ids",
                                                "left_out_test_ids", "outside_interval_test_ids"]}
                 for suite_id in definitions}
    registries = {suite_id: registered_editions(suite_id) for suite_id in definitions}
    actions = {suite_id: {row["test_id"]: row["action"] for row in definition["table"]["conflicts"]}
               for suite_id, definition in definitions.items()}
    selected = []
    for test in tests:
        suite_id = test["suite_id"]
        if test["version_status"] != "current":
            raise ValueError("Current bounds required for " + test["test_id"])
        definition, decision = definitions[suite_id], decisions[suite_id]
        action = actions[suite_id].get(test["test_id"])
        if action:
            decision["replaced_test_ids" if action == "replace" else "left_out_test_ids"].append(test["test_id"])
        elif authority_edition(test, registries[suite_id]) == definition["edition"]:
            decision["own_test_ids"].append(test["test_id"])
            selected.append(test)
        elif applicability(test, definition["level"]) == "test":
            decision["continuity_test_ids"].append(test["test_id"])
            selected.append(test)
        else:
            decision["outside_interval_test_ids"].append(test["test_id"])
    candidates = {(test["suite_id"], test["test_id"]) for test in tests}
    selected_ids = {(test["suite_id"], test["test_id"]) for test in selected}
    for suite_id, definition in definitions.items():
        for row in definition["table"]["conflicts"]:
            if (row["action"] == "replace" and (suite_id, row["test_id"]) in candidates
                    and (suite_id, row["replacement_test_id"]) not in selected_ids):
                raise ValueError("Replacement is not selected for edition " + str(definition["edition"])
                                 + ": " + row["replacement_test_id"])
    return selected, decisions


def edition_audit(suite_id, tests):
    editions = registered_editions(suite_id)
    expected = {str(number) + ".json" for number in editions if number != max(editions)}
    directory = standard_root(suite_id) / "edition-conflicts"
    actual = {path.relative_to(directory).as_posix() for path in directory.rglob("*") if path.is_file()}
    errors, tables = [], []
    if actual != expected:
        errors.append("Edition conflict inventory differs: missing=" + repr(sorted(expected - actual))
                      + "; extra=" + repr(sorted(actual - expected)))
    for number in sorted(editions):
        if number == max(editions):
            continue
        try:
            table = load_conflicts(suite_id, number, tests)
            tables.append({"edition": number, "base_edition": table["base_edition"],
                           "conflicts": len(table["conflicts"]),
                           "replacements": sum(row["action"] == "replace" for row in table["conflicts"]),
                           "left_out": sum(row["action"] == "leave-out" for row in table["conflicts"]),
                           "sha256": sha(directory / (str(number) + ".json"))})
        except (OSError, ValueError, KeyError, TypeError) as error:
            errors.append("Edition " + str(number) + ": " + str(error))
    return {"tables": tables, "errors": errors}
