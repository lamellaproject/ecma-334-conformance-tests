"""Registered edition conflicts and selection, independent of compiler verdicts."""
from __future__ import annotations

import json
import re

from suite_common import ROOT, checked_object, public_level, sha, source_registry, standard_root
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


def iso_edition(suite_id, language_version):
    """The registry assigns one primary edition to each ISO language level."""
    if language_version.endswith("-preview"):
        return None
    registry = source_registry(suite_id)
    level = public_level(language_version)
    source_id = next((source_id for label, source_id in registry["iso_editions"].items()
                      if public_level(label) == level), None)
    return next((entry for entry in registry["editions"] if entry["id"] == source_id), None)


def validate_supersession(row, test, editions, governing):
    """A changed rule needs explicit citations to the test and governing editions."""
    if row["action"] != "leave-out":
        raise ValueError("A superseded test must use leave-out, never replace")
    marker = row["superseded"]
    checked_object(marker, {"test", "level"}, {"test", "level"})
    own = authority_edition(test, editions)
    number = next((n for n, entry in editions.items() if entry["id"] == governing["id"]), None)
    if own is None or number is None or own >= number:
        raise ValueError("A superseded test must have an older edition's authority: " + test["test_id"])
    for side, source_id in [("test", editions[own]["id"]), ("level", governing["id"])]:
        citations = marker[side]
        if not isinstance(citations, list) or not citations:
            raise ValueError("Superseded needs both test and level citations")
        seen = set()
        for citation in citations:
            fields = {"source_id", "clause", "printed_pages", "pdf_pages", "quote"}
            checked_object(citation, fields, fields)
            if (citation["source_id"] != source_id or not isinstance(citation["clause"], str)
                    or not re.fullmatch(r"[1-9][0-9]*(?:\.[0-9]+)*", citation["clause"])
                    or not isinstance(citation["quote"], str) or not citation["quote"].strip()):
                raise ValueError("Superseded citation needs the registered source, clause and exact quote")
            for key in ["printed_pages", "pdf_pages"]:
                pages = citation[key]
                if (not isinstance(pages, list) or not pages
                        or any(type(page) is not int or page < 1 for page in pages)
                        or pages != sorted(set(pages))):
                    raise ValueError("Superseded citation needs positive distinct printed/PDF pages")
            if len(citation["printed_pages"]) != len(citation["pdf_pages"]):
                raise ValueError("Superseded citation needs matching printed/PDF page pairs")
            signature = json.dumps(citation, sort_keys=True)
            if signature in seen:
                raise ValueError("Duplicate superseded citation")
            seen.add(signature)
    own_clause = test["authority"].removeprefix(editions[own]["authority_prefix"] + " ")
    if not any(citation["clause"] == own_clause for citation in marker["test"]):
        raise ValueError("Superseded test citation disagrees with its header authority")
    clause = row["authority"].split(",", 1)[0].removeprefix(governing["authority_prefix"] + " ")
    pages = re.search(r", p\. ([0-9]+) \(PDF p\. ([0-9]+)\)", row["authority"])
    pair = tuple(map(int, pages.groups()))
    if not any(citation["clause"] == clause and pair in zip(citation["printed_pages"], citation["pdf_pages"])
               for citation in marker["level"]):
        raise ValueError("Superseded level citation disagrees with the conflict authority and pages")


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
    pairs, actions, superseded = set(), {}, set()
    prefix = editions[number]["authority_prefix"]
    citation = re.compile(re.escape(prefix) + r" [1-9][0-9]*(?:\.[0-9]+)*, p\. [1-9][0-9]* \(PDF p\. [1-9][0-9]*\)(?:, [^\r\n]+)?\Z")
    compiler = source_registry(suite_id)["compiler_authority"]
    compiler_authority = re.compile(re.escape(compiler["id"] + " " + compiler["version"]) + r" \(C# [^)]+\)\Z")
    for row in table["conflicts"]:
        required = {"action", "test_id", "authority"}
        checked_object(row, required | {"replacement_test_id", "superseded"}, required)
        if row["action"] not in {"replace", "leave-out"}:
            raise ValueError("Unknown edition conflict action")
        replacement = row.get("replacement_test_id")
        if (row["action"] == "replace") != ("replacement_test_id" in row):
            raise ValueError("Only replace rows require a replacement test ID")
        for test_id in [row["test_id"], *([replacement] if row["action"] == "replace" else [])]:
            if not isinstance(test_id, str) or test_id not in inventory:
                raise ValueError("Unknown edition conflict test ID: " + str(test_id))
        target_edition = authority_edition(inventory[row["test_id"]], editions)
        compiler_leave_out = (row["action"] == "leave-out" and "superseded" not in row
                              and compiler_authority.fullmatch(inventory[row["test_id"]]["authority"]))
        if ((target_edition is None and not compiler_leave_out)
                or (target_edition == number and "superseded" not in row)):
            raise ValueError("Conflict target needs another edition's authority or a pinned compiler ordinary exclusion: "
                             + row["test_id"])
        replacement_edition = authority_edition(inventory[replacement], editions) if replacement else None
        if row["action"] == "replace" and replacement_edition in {None, base}:
            raise ValueError("Replacement must have a registered older edition's authority: " + replacement)
        if not isinstance(row["authority"], str) or not citation.fullmatch(row["authority"]):
            raise ValueError("Conflict authority needs a registered clause and printed/PDF pages")
        if replacement_edition == number and row["authority"].split(",", 1)[0] != inventory[replacement]["authority"]:
            raise ValueError("Conflict citation disagrees with replacement authority: " + replacement)
        if "superseded" in row:
            governing = iso_edition(suite_id, editions[number]["language_version"])
            if governing is None or governing["id"] != editions[number]["id"]:
                raise ValueError("Superseded rows belong to the governing ISO edition's table")
            validate_supersession(row, inventory[row["test_id"]], editions, governing)
            if row["test_id"] in actions:
                raise ValueError("Duplicate disposition of a superseded test")
            superseded.add(row["test_id"])
        elif row["test_id"] in superseded:
            raise ValueError("A superseded test cannot also be replaced or left out")
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


def superseded_claims(suite_id, tests):
    """Return the cited changed claims at each registry-governed ISO level."""
    editions = registered_editions(suite_id)
    result = {}
    for label, source_id in source_registry(suite_id)["iso_editions"].items():
        number = next(n for n, entry in editions.items() if entry["id"] == source_id)
        table = load_conflicts(suite_id, number, tests)
        result[public_level(label)] = {row["test_id"]: row for row in table["conflicts"] if "superseded" in row}
    return result


def edition_definition(suite_id, number, config, tests):
    editions = registered_editions(suite_id)
    if number not in editions or number == max(editions):
        raise ValueError("Choose a registered non-latest edition for " + suite_id + ": "
                         + ", ".join(str(n) for n in sorted(editions) if n != max(editions)))
    entry = editions[number]
    level = resolve_level(config, entry["language_version"])
    if level is None:
        raise ValueError("Compiler does not support edition " + str(number) + " at " + entry["language_version"])
    governing = iso_edition(suite_id, entry["language_version"]) or entry
    effective_number = next(n for n, source in editions.items() if source["id"] == governing["id"])
    table = load_conflicts(suite_id, effective_number, tests)
    source_path = standard_root(suite_id) / "edition-conflicts" / (str(number) + ".json")
    path = standard_root(suite_id) / "edition-conflicts" / (str(effective_number) + ".json")
    return {"edition": number, "source_id": entry["id"], "language_version": entry["language_version"],
            "level_source_id": governing["id"], "level_edition": effective_number,
            "claim_run": governing["id"] == entry["id"],
            "level": level, "conflict_table": {"path": path.relative_to(ROOT).as_posix(), "sha256": sha(path)},
            "source_conflict_table": {"path": source_path.relative_to(ROOT).as_posix(), "sha256": sha(source_path)},
            "table": table}


def version_inventory(tests):
    """Version runs keep the latest standard edition and compiler authority."""
    registries = {suite_id: registered_editions(suite_id) for suite_id in {test["suite_id"] for test in tests}}
    return [test for test in tests
            if authority_edition(test, registries[test["suite_id"]]) in {None, max(registries[test["suite_id"]])}]


def edition_inventory(tests, definitions, *, header=False, gating=False, inventory=None):
    """Select claims and, for explicit levels, unlisted positive refusal checks."""
    decisions = {suite_id: {name: [] for name in ["own_test_ids", "continuity_test_ids", "replaced_test_ids",
                                                "left_out_test_ids", "replacement_test_ids", "outside_interval_test_ids",
                                                "superseded_test_ids", "version_gating_test_ids"]}
                 for suite_id in definitions}
    registries = {suite_id: registered_editions(suite_id) for suite_id in definitions}
    actions = {suite_id: {row["test_id"]: row["action"] for row in definition["table"]["conflicts"]}
               for suite_id, definition in definitions.items()}
    superseded = {suite_id: {row["test_id"] for row in definition["table"]["conflicts"] if "superseded" in row}
                  for suite_id, definition in definitions.items()}
    gating_exclusions = {suite_id: set().union(*superseded_claims(
        suite_id, tests if inventory is None else inventory).values()) for suite_id in definitions} if gating else {}
    candidates = {(test["suite_id"], test["test_id"]) for test in tests}
    replacements = {(suite_id, row["replacement_test_id"])
                    for suite_id, definition in definitions.items() for row in definition["table"]["conflicts"]
                    if row["action"] == "replace" and (suite_id, row["test_id"]) in candidates}
    selected = []
    for test in tests:
        suite_id = test["suite_id"]
        if not header and test["version_status"] != "current":
            raise ValueError("Current bounds required for " + test["test_id"])
        definition, decision = definitions[suite_id], decisions[suite_id]
        action = actions[suite_id].get(test["test_id"])
        if test["test_id"] in superseded[suite_id]:
            decision["superseded_test_ids"].append(test["test_id"])
            selected.append(test)
        elif action:
            decision["replaced_test_ids" if action == "replace" else "left_out_test_ids"].append(test["test_id"])
        elif authority_edition(test, registries[suite_id]) == definition["edition"]:
            decision["own_test_ids"].append(test["test_id"])
            selected.append(test)
        elif header or applicability(test, definition["level"]) == "test":
            decision["continuity_test_ids"].append(test["test_id"])
            selected.append(test)
        elif ((suite_id, test["test_id"]) in replacements
              and authority_edition(test, registries[suite_id]) not in {None, max(registries[suite_id])}):
            decision["replacement_test_ids"].append(test["test_id"])
            selected.append(test)
        elif (gating and test["test_id"] not in gating_exclusions[suite_id]
              and applicability(test, definition["level"]) == "version-gating"):
            decision["version_gating_test_ids"].append(test["test_id"])
            selected.append(test)
        else:
            decision["outside_interval_test_ids"].append(test["test_id"])
    selected_ids = {(test["suite_id"], test["test_id"]) for test in selected}
    for suite_id, definition in definitions.items():
        for row in definition["table"]["conflicts"]:
            if (row["action"] == "replace" and (suite_id, row["test_id"]) in candidates
                    and (suite_id, row["replacement_test_id"]) not in selected_ids):
                raise ValueError("Replacement is not selected for edition " + str(definition["edition"])
                                 + ": " + row["replacement_test_id"])
    return selected, decisions


def edition_details(definition, decisions):
    return {**{key: value for key, value in definition.items() if key != "table"}, **decisions}


def edition_plan(test, definition):
    """Bind each claim to its table; superseded claims have no execution plan."""
    marker = next((row["superseded"] for row in definition["table"]["conflicts"]
                   if row["test_id"] == test["test_id"] and "superseded" in row), None)
    membership = {"edition": definition["edition"], "level_source_id": definition.get("level_source_id", definition["source_id"]),
                  "conflict_table": definition["conflict_table"], "superseded": marker}
    return {**test, "edition_membership": membership}, definition["level"], "superseded" if marker else "test"


def resolve_language_plans(plans, inventory, config, selection):
    """Use governing tables at ISO levels and the version policy at other levels."""
    groups, selected, details = {}, {}, {}
    candidates = {(test["suite_id"], test["test_id"]): test for test, _, _ in plans}
    additional = []
    for test, level, _ in plans:
        label = level["level"] if level else test["version"]
        groups.setdefault((test["suite_id"], label), []).append((test, level))
    for (suite_id, label), group in groups.items():
        level = group[0][1]
        governing = iso_edition(suite_id, level["level"]) if level else None
        if governing:
            number = next(n for n, entry in registered_editions(suite_id).items() if entry["id"] == governing["id"])
            definition = edition_definition(suite_id, number, config, inventory)
            definition["level"] = level
            if selection == "earliest-per-test":
                # A cited replacement can have another earliest measured level.
                targets = {test["test_id"] for test, _ in group}
                present = set(targets)
                for row in definition["table"]["conflicts"]:
                    if row["action"] != "replace" or row["test_id"] not in targets:
                        continue
                    replacement = row["replacement_test_id"]
                    candidate = candidates.get((suite_id, replacement))
                    if candidate is not None and replacement not in present:
                        group.append((candidate, level))
                        present.add(replacement)
                        additional.append((suite_id, replacement, label))
            tests, decisions = edition_inventory([test for test, _ in group], {suite_id: definition},
                                                 header=selection == "declared-per-test", gating=selection == "explicit",
                                                 inventory=inventory)
            details.setdefault(suite_id, {})[label] = edition_details(definition, decisions[suite_id])
            resolutions = {test["test_id"]: resolution for test, resolution in group}
            gating_ids = set(decisions[suite_id]["version_gating_test_ids"])
            for test in tests:
                bound, _, mode = edition_plan(test, definition)
                if test["test_id"] in gating_ids:
                    mode = "version-gating"
                selected[(suite_id, test["test_id"], label)] = bound, resolutions[test["test_id"]], mode
        else:
            tests = [test for test, _ in group]
            if selection != "declared-per-test":
                tests = version_inventory(tests)
                if any(test["version_status"] != "current" for test in tests):
                    raise ValueError("Measured runs require current version metadata for every selected test")
            for test in tests:
                mode = applicability(test, level) if selection == "explicit" else "test"
                selected[(suite_id, test["test_id"], label)] = test, level, mode
    resolved = [selected[key] for test, level, _ in plans
                if (key := (test["suite_id"], test["test_id"], level["level"] if level else test["version"])) in selected]
    original_keys = {(test["suite_id"], test["test_id"], level["level"] if level else test["version"])
                     for test, level, _ in plans}
    resolved.extend(selected[key] for key in additional if key in selected and key not in original_keys)
    return resolved, details


def header_plans(tests, config, inventory=None):
    """Header-level checks share the governing ISO decisions without measuring bounds."""
    plans = [(test, resolve_level(config, test["version"]), "test") for test in tests]
    return resolve_language_plans(plans, tests if inventory is None else inventory, config, "declared-per-test")


def edition_audit(suite_id, tests, source_map=None):
    editions = registered_editions(suite_id)
    expected = {str(number) + ".json" for number in editions if number != max(editions)}
    directory = standard_root(suite_id) / "edition-conflicts"
    actual = {path.relative_to(directory).as_posix() for path in directory.rglob("*") if path.is_file()}
    errors, tables = [], []
    if source_map is not None:
        from suite_audits import Sources
        sources = Sources(source_registry(suite_id), source_map)
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
                           "superseded": sum("superseded" in row for row in table["conflicts"]),
                           "sha256": sha(directory / (str(number) + ".json"))})
            if source_map is not None:
                for row in table["conflicts"]:
                    sources.locator(editions[number]["id"], row["authority"].removeprefix(
                        editions[number]["authority_prefix"] + " "), errors, row["test_id"] + ": authority")
                    for side, citations in row.get("superseded", {}).items():
                        for citation in citations:
                            sources.citation(citation, errors, row["test_id"] + ": " + side)
        except (OSError, ValueError, KeyError, TypeError) as error:
            errors.append("Edition " + str(number) + ": " + str(error))
    return {"tables": tables, "errors": errors}
