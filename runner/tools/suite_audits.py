"""Structural and evidence audits shared by the maintainer commands."""
from __future__ import annotations

import json
import re
from collections import Counter
from pathlib import Path

from suite_common import (KINDS, ROOT, RULE_FIELDS, RULE_ID, checked_object, header_body, inside,
                          load_manifest, raw_sources, read_rules, read_tsv, sha, source_registry,
                          standard_root, suite_path, validate_raw_source)
from suite_config import level_tuple, public_level, resolve_level
from suite_engine import CONTROL_OUTCOMES, DEPARTURE_FIELDS, Context, control_level, departure_rows, load_controls
from suite_evidence import verify_record

COVERAGE_FIELDS = ["block_id", "source_id", "locator", "rule_ids", "disposition", "notes"]
RETIRED_FIELDS = [*RULE_FIELDS, "retirement_reason"]


def normalized(text):
    # PDF text extraction puts subscript labels on separate lines and can remove
    # spacing next to mathematical punctuation. Preserve all other characters
    # and word boundaries; never rewrite the quotation stored in the ledger.
    punctuation = re.escape(",.[]()<>?")
    return re.sub(r"\s*([" + punctuation + r"])\s*", r"\1", " ".join(text.split()))


class Sources:
    """Read explicitly supplied external sources, checking their registered immutable pins."""
    def __init__(self, registry, map_file):
        self.registry, self.texts, self.identities = registry, {}, []
        self.pins = {e["id"]: e for e in registry["editions"]}
        self.pins.update({r["id"] + ":" + a["path"]: dict(a, role=r["role"], commit=r["commit"])
                          for r in registry["references"] for a in r.get("assets", [])})
        if map_file is None:
            return
        map_file = Path(map_file).resolve()
        value = json.loads(map_file.read_text(encoding="utf-8"))
        checked_object(value, {"schema_version", "sources"}, {"schema_version", "sources"})
        if value["schema_version"] != 1 or not isinstance(value["sources"], dict):
            raise ValueError("Invalid external source map")
        for source_id, entry in value["sources"].items():
            checked_object(entry, {"asset", "text"}, {"asset"})
            pin = self.pins.get(source_id)
            if not pin:
                raise ValueError("Source map names an unregistered source: " + source_id)
            asset = (map_file.parent / entry["asset"]).resolve()
            if sha(asset) != pin["sha256"]:
                raise ValueError("External source does not match its pin: " + source_id)
            record = {"source_id": source_id, "asset": str(asset), "sha256": sha(asset)}
            if "edition" in pin:
                extraction = pin.get("text")
                if not extraction or "text" not in entry:
                    raise ValueError("Edition quote auditing requires its registered text extraction: " + source_id)
                text = (map_file.parent / entry["text"]).resolve()
                if sha(text) != extraction["sha256"]:
                    raise ValueError("Edition text extraction does not match its pin: " + source_id)
                record.update(text=str(text), text_sha256=sha(text))
            else:
                text = asset
            self.texts[source_id] = text.read_text(encoding="utf-8")
            self.identities.append(record)

    def quote(self, row, errors, identity):
        source_id, locator = row["source_id"], row["locator"]
        pin = self.pins.get(source_id)
        quote = json.loads(row["quote_json"])
        if not isinstance(quote, str) or not quote.strip() or len(quote.split()) > 30:
            errors.append(identity + ": quote must be a nonempty short JSON string")
            return
        if not pin or pin["role"] != "primary":
            errors.append(identity + ": rule authority must name a registered primary source")
            return
        if "edition" in pin:
            pages = re.search(r"\(PDF p\. ([0-9, ]+)\)", locator)
            if not re.search(r"\bp\. [1-9][0-9]*", locator) or not pages:
                errors.append(identity + ": edition locator must include printed and PDF pages")
                return
        elif pin["commit"] not in locator:
            errors.append(identity + ": feature locator must include its pinned commit")
        if not self.texts:
            return
        if source_id not in self.texts:
            errors.append(identity + ": external source map is incomplete")
            return
        text = self.texts[source_id]
        if "edition" in pin:
            parts = text.split("\f")
            numbers = [int(n.strip()) for n in pages[1].split(",")]
            if any(n < 1 or n > len(parts) for n in numbers):
                errors.append(identity + ": PDF page is outside the pinned extraction")
                return
            text = " ".join(parts[n - 1] for n in numbers)
        if normalized(quote) not in normalized(text):
            errors.append(identity + ": quotation is not exact at its pinned source locator")


def ledger_audit(suite_id, source_map=None, require_confirmed=False):
    root, rules, tests = standard_root(suite_id), read_rules(suite_id), load_manifest(suite_id=suite_id)
    registry, errors = source_registry(suite_id), []
    sources = Sources(registry, source_map)
    scope = json.loads((root / "ledger-scope.json").read_text(encoding="utf-8"))
    checked_object(scope, {"schema_version", "coverage_proof", "clauses"}, {"schema_version", "coverage_proof", "clauses"})
    if scope["schema_version"] != 1 or not scope["coverage_proof"]:
        raise ValueError("Unsupported or unexplained ledger scope")
    owners = {Path(r["ledger"]).parts[1] for r in rules.values()}
    if owners - scope["clauses"].keys():
        errors.append("Ledger clause is absent from scope")
    for rid, rule in rules.items():
        owner = Path(rule["ledger"]).parts[1]
        if not RULE_ID.fullmatch(rid) or rule["kind"] not in KINDS or not rule["requirement"].strip():
            errors.append(rid + ": invalid predicate fields")
        if rid.startswith("E") and int(re.match(r"E([0-9]+)", rid)[1]) != int(owner[:2]):
            errors.append(rid + ": rule is outside its owning clause")
        sources.quote(rule, errors, rid)
    covered = set()
    for test in tests:
        ids = test["rule_ids"].split(";")
        covered.update(ids)
        errors.extend(test["test_id"] + ": unknown rule " + rid for rid in ids if rid not in rules)
        if ids[0] in rules and Path(rules[ids[0]]["ledger"]).parts[1] != Path(test["path"]).parts[1]:
            errors.append(test["test_id"] + ": primary rule/test ownership differs")
        _, body = header_body(suite_path(test["path"], suite_id).read_bytes())
        source = body.decode("utf-8")
        if "CultureInfo" in source or "using System.Linq;" in source:
            errors.append(test["test_id"] + ": unnecessary culture/LINQ library surface")
        if test["expected"] == "run" and json.loads(test["stdout_json"]) != "OK 0\n":
            if not (re.search(r"\bchecks\+\+", source) and re.search(r"\bfailures\+\+", source)
                    and re.search(r'if\s*\(failures\s*==\s*0\)\s*Console\.WriteLine\("OK "\s*\+\s*checks\)', source)):
                errors.append(test["test_id"] + ": missing accumulating counted-check protocol")
        for line in source.split("\n"):
            if (re.search(r"\bCheck\s*\(", line) and not re.search(r"\b(?:void|bool)\s+Check\s*\(", line)
                    and not re.search(r',\s*"[^"\n]+"\s*\);', line)):
                errors.append(test["test_id"] + ": Check call does not name its case")
    untested, retired = {}, {}
    for path in sorted((root / "clauses").glob("*/untested.tsv")):
        for row in read_tsv(path, ["rule_id", "reason"]):
            rid = row["rule_id"]
            if (rid in untested or rid not in rules or not row["reason"].strip() or rid in covered
                    or (rid in rules and Path(rules[rid]["ledger"]).parent != path.relative_to(root).parent)):
                errors.append(rid + ": invalid/duplicate/foreign/already-tested untested entry")
            untested[rid] = row["reason"]
    for path in sorted((root / "clauses").glob("*/retired-rules.tsv")):
        for row in read_tsv(path, RETIRED_FIELDS):
            rid = row["rule_id"]
            if rid in retired or rid in rules or rid in covered or rid in untested or not row["retirement_reason"].strip():
                errors.append(rid + ": retired ID repeats or is reused")
            sources.quote(row, errors, "retired " + rid)
            retired[rid] = row
    uncovered = sorted(set(rules) - covered - set(untested))
    errors.extend("Rule has neither a test nor an untested reason: " + rid for rid in uncovered)
    blocks, mapped = 0, set()
    for clause, detail in scope["clauses"].items():
        checked_object(detail, {"status", "complete_clause_claim", "expected_block_ids"},
                       {"status", "complete_clause_claim", "expected_block_ids"})
        if detail["status"] not in {"available", "partial", "in-progress"} or type(detail["complete_clause_claim"]) is not bool:
            errors.append(clause + ": invalid scope status/claim")
        path = inside(root, "clauses/" + clause + "/coverage.tsv")
        rows = read_tsv(path, COVERAGE_FIELDS) if path.is_file() else []
        if not path.is_file() and (detail["status"] != "in-progress" or detail["expected_block_ids"]):
            errors.append(clause + ": missing coverage inventory")
        ids = [r["block_id"] for r in rows]
        if len(set(ids)) != len(ids) or set(ids) != set(detail["expected_block_ids"]):
            errors.append(clause + ": coverage block inventory changed or repeats a block")
        blocks += len(rows)
        for row in rows:
            targets = row["rule_ids"].split(";") if row["rule_ids"] else []
            disposition = row["disposition"]
            if disposition.startswith("covered-by "):
                referred = disposition.removeprefix("covered-by ").split(";")
                if not row["notes"].strip() or any(not t for t in referred):
                    errors.append(clause + "/" + row["block_id"] + ": invalid covered-by explanation")
                targets = list(dict.fromkeys([*targets, *referred]))
            elif disposition == "rules":
                if not targets:
                    errors.append(clause + "/" + row["block_id"] + ": normative block has no rule")
            elif (disposition not in {"example", "note", "informative", "heading"} or targets
                  or (disposition == "informative" and not row["notes"].strip())):
                errors.append(clause + "/" + row["block_id"] + ": invalid no-rule explanation")
            for rid in targets:
                if rid not in rules or Path(rules[rid]["ledger"]).parts[1] != clause:
                    errors.append(clause + "/" + row["block_id"] + ": unknown/foreign/retired coverage rule " + rid)
                mapped.add(rid)
            if row["source_id"] not in sources.pins or not row["locator"].strip():
                errors.append(clause + "/" + row["block_id"] + ": unregistered source or missing locator")
    errors.extend("Active standard rule is absent from its coverage inventory: " + rid
                  for rid in sorted(set(rules) - mapped) if rid.startswith("E"))
    by_id, departures = {t["test_id"]: t for t in tests}, departure_rows(suite_id)
    notes_path = root / "reference-notes.tsv"
    references = read_tsv(notes_path, DEPARTURE_FIELDS) if notes_path.is_file() else []
    for label, rows in (("departure", list(departures.values())), ("reference note", references)):
        for row in rows:
            test = by_id.get(row["test_id"])
            if not test or row["source_sha256"] != test["source_sha256"] or row["rule_ids"] != test["rule_ids"]:
                errors.append(row["test_id"] + ": stale or absent " + label)
            if not row["notes"].strip():
                errors.append(row["test_id"] + ": missing " + label + " explanation")
            if label == "departure" and (not row["source_id"].startswith(suite_id + "-ed") or (test and test["authority"].startswith("csc "))):
                errors.append(row["test_id"] + ": compiler-authority discrepancies belong in reference notes")
            if row["compiler_id"] != "csc" or row["compiler_commit"] != registry["csc_commit"]:
                errors.append(row["test_id"] + ": observation does not name the pinned authority")
            levels = json.loads(row["levels_json"])
            if not isinstance(levels, list) or not levels or len(set(levels)) != len(levels):
                errors.append(row["test_id"] + ": missing or repeated observed levels")
            for level in levels:
                public_level(level)
            json.loads(row["observation_json"])
            if row["conforms_since"]:
                public_level(row["conforms_since"])
            if require_confirmed and row["status"] != "confirmed":
                errors.append(row["test_id"] + ": pending " + label)
            sources.quote(row, errors, row["test_id"] + " " + label)
    if len({r["test_id"] for r in references}) != len(references) or set(departures) & {r["test_id"] for r in references}:
        errors.append("Repeated or overlapping departure/reference note")
    return {"suite_id": suite_id, "rules": len(rules), "tests": len(tests), "tested_rules": len(covered),
            "untested_rules": len(untested), "uncovered_rules": len(uncovered), "coverage_blocks": blocks,
            "retired_rules": len(retired), "departures": len(departures), "departure_status": dict(Counter(r["status"] for r in departures.values())),
            "reference_notes": len(references), "in_progress_clauses": [c for c, d in scope["clauses"].items() if d["status"] != "available"],
            "quotes_checked_against_sources": bool(source_map), "sources": sources.identities, "errors": errors}


def raw_audit(suite_id):
    inventory, errors, rows = raw_sources(suite_id), [], []
    attributes = (ROOT / ".gitattributes").read_text(encoding="ascii").split("\n")
    for relative, entry in inventory.items():
        path = suite_path(relative, suite_id)
        validate_raw_source(path.read_bytes(), entry)
        if suite_id + "/" + relative + " -text" not in attributes:
            errors.append(relative + ": raw source must be marked -text")
        rows.append({"path": relative, "sha256": sha(path), "rule_id": entry["rule_id"]})
    # Parsing all sources catches exceptional files omitted from the inventory.
    tests = load_manifest(suite_id=suite_id)
    return {"suite_id": suite_id, "raw_files": len(rows), "raw_rules": len({r["rule_id"] for r in rows}),
            "tests_parsed": len(tests), "rows": rows, "errors": errors}


def csc_audit(suite_ids, compiler, target, results, select=None):
    """Check current header-Version evidence, including controls, truth and allowed departures."""
    results = Path(results).resolve()
    run = json.loads((results / "run.json").read_text(encoding="utf-8"))
    context = Context.from_evidence(compiler, target, results, run["provenance"])
    from suite_measurements import ObservationRegistry
    registry = ObservationRegistry(compiler, {context.target_config["id"]: target})
    registry.add(results, results / "run.json", "header")
    header_contexts = registry.header(context, run)
    if context.config["id"] != "csc" or any(context.config["commit"] != source_registry(s)["csc_commit"] for s in suite_ids):
        raise ValueError("Csc auditing requires the registered compiler authority")
    errors = []
    if (not run["complete"] or run["void"] or run["version_mode"] != "header-Version"
            or run["provenance"]["identity_sha256"] != context.identity_sha256):
        errors.append("Csc run is incomplete, void, in another mode, or uses stale execution assets")
    controls = {row["test_id"]: row for row in run["controls"]["rows"]}
    for test in load_controls():
        try:
            row = controls[test["test_id"]]
            record = json.loads(Path(row["result"]).read_text(encoding="utf-8"))
            verify_record(context, test, record, control_level(context.config, test))
            wanted_status, wanted_compile, wanted_run = CONTROL_OUTCOMES[test["test_id"].removeprefix("control--")]
            compile_ok = record["compile_exit"] in context.config["rejection_exit_codes"] if wanted_compile == "rejection" else record["compile_exit"] == wanted_compile
            run_ok = type(record["run_exit"]) is int and record["run_exit"] != 0 if wanted_run == "nonzero" else record["run_exit"] == wanted_run
            if not row["valid"] or record["status"] != wanted_status or not compile_ok or not run_ok:
                raise ValueError("Control observation differs from its deliberately broken outcome")
        except (OSError, ValueError, KeyError, TypeError) as error:
            errors.append(test["test_id"] + ": " + str(error))
    if set(controls) != {t["test_id"] for t in load_controls()}:
        errors.append("Control inventory differs")
    records = read_tsv(results / "results.tsv")
    by_key = {(r["suite_id"], r["test_id"]): r for r in records}
    if len(by_key) != len(records) or len(records) != run["tests"]:
        errors.append("Csc result inventory repeats a test or differs from run.json")
    selected = {(r[0], r[1]) for r in run["selected_test_ids"]}
    if selected != set(by_key):
        errors.append("Csc result inventory differs from run selection")
    tests = [t for suite_id in suite_ids for t in load_manifest(suite_id=suite_id)
             if select is None or re.search(select, t["test_id"])]
    observations, csc_headers, counts = [], 0, Counter()
    for test in tests:
        try:
            level = resolve_level(context.config, test["version"])
            table = by_key[(test["suite_id"], test["test_id"])]
            record = json.loads(Path(table["result_path"]).read_text(encoding="utf-8"))
            observed = (header_contexts[test["suite_id"] + "|" + test["test_id"]]
                        if isinstance(header_contexts, dict) else header_contexts)
            verify_record(observed, test, record, level)
            claimed_departure = record["departure"], record["departure_kind"]
            record["departure"], record["departure_kind"] = False, ""
            observed.mark_departure(record)
            if claimed_departure != (record["departure"], record["departure_kind"]):
                raise ValueError("Departure annotation differs from the current confirmed observation")
            for key, value in record.items():
                flat = json.dumps(value, sort_keys=True) if isinstance(value, (dict, list)) else "" if value is None else str(value)
                if table.get(key) != flat:
                    raise ValueError("results.tsv differs from its verified record: " + key)
            if record["status"] != "pass" and not record["departure"]:
                allowed_gap = (record["status"] == "unsupported" and record["unsupported_reason"] == "target-capability"
                               and json.loads(test["fixture_json"]).get("target_requires") == ["framework-runtime"])
                if not allowed_gap:
                    errors.append(test["test_id"] + ": unconfirmed csc outcome " + record["status"] + ":" + record["reason"])
            if test["csc_codes"]:
                csc_headers += 1
                codes = {d["code"] for d in record["diagnostics"] if d["stage"] == "program" and d["severity"] == "error"}
                if not {c.strip() for c in test["csc_codes"].split(";")} <= codes:
                    errors.append(test["test_id"] + ": Csc header is false at its Version")
            counts[record["status"]] += 1
            observations.append({"suite_id": test["suite_id"], "test_id": test["test_id"], "status": record["status"],
                                 "departure": record["departure"], "source_sha256": test["source_sha256"],
                                 "result_sha256": sha(table["result_path"])})
        except (OSError, ValueError, KeyError, TypeError) as error:
            errors.append(test["test_id"] + ": " + str(error))
    return {"tests_checked": len(tests), "csc_headers_checked": csc_headers, "controls_checked": len(controls),
            "status_counts": dict(counts), "run_sha256": sha(results / "run.json"),
            "results_sha256": sha(results / "results.tsv"), "rows": observations, "errors": errors,
            "provenance": context.provenance()}
