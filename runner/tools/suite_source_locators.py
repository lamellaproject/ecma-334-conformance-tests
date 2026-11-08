"""Resolve edition clause and page locators in pinned PDF text extractions."""
from __future__ import annotations

import re

CLAUSE = r"(?:[1-9][0-9]*(?:\.[0-9]+)*|[A-Z](?:\.[0-9]+)*)"


def page_numbers(value):
    """Read comma lists, ranges and repeated printed-page labels."""
    value = re.sub(r"\bp\.\s*", "", value)
    numbers = []
    for part in re.split(r"[,;]", value):
        match = re.fullmatch(r"\s*([1-9][0-9]*)(?:-([1-9][0-9]*))?\s*", part)
        if not match:
            raise ValueError("Invalid edition page list")
        first, last = int(match[1]), int(match[2] or match[1])
        if last < first:
            raise ValueError("Reversed edition page range")
        numbers.extend(range(first, last + 1))
    return numbers


def parse_locator(locator):
    label = re.match(r"(?:Annex )?(" + CLAUSE + r")(?=[,;\s])", locator)
    pdf = re.search(r"\(PDF p\. ([0-9, ]+)\)", locator)
    printed = re.search(r"\bp\. (.+?)\s*$", locator[:pdf.start()]) if pdf else None
    if not label or not pdf or not printed:
        raise ValueError("Edition locator must include a clause and printed/PDF pages")
    return label[1], page_numbers(printed[1]), page_numbers(pdf[1])


def clause_extents(headings, length):
    """A clause includes its descendants and ends at the next unrelated heading."""
    ordered = sorted(headings.items(), key=lambda pair: pair[1])
    return {clause: (start, next((position for name, position in ordered[index + 1:]
                                if not name.startswith(clause + ".")), length))
            for index, (clause, start) in enumerate(ordered)}


class EditionText:
    """Index body headings using contents titles and parent-bounded deeper headings."""
    def __init__(self, text):
        self.text = text
        self.pages = text.split("\f")
        self.starts = [0]
        for page in self.pages:
            self.starts.append(self.starts[-1] + len(page) + 1)
        scope = re.compile(r"(?m)^[ \t]*(?:[0-9]{1,2}[ \t]+)?1\.?[ \t]+Scope[ \t]*$")
        self.offset = next((number for number, page in enumerate(self.pages) if scope.search(page)), None)
        if self.offset is None:
            raise ValueError("Pinned edition has no Scope body heading")
        front = "\n".join(self.pages[:self.offset])
        # Running headers do not contribute contents entries.
        front = re.sub(r"(?m)^[ \t]*ECMA-334\b[^\n]*$", "", front)
        contents = " ".join(front.split())
        first = re.search(r"(?<![\w.])1\.?\s+Scope\s*\.{2,}", contents)
        if first is None:
            raise ValueError("Pinned edition has no Scope contents entry")
        contents = contents[first.start():]
        entries = {}
        pattern = re.compile(r"(?<![\w.\-])(?:[0-9]{1,2}\s+)?(" + CLAUSE
                             + r")\.?\s+([^\s].*?)\.{2,}\s*([0-9]+)\b")
        for match in pattern.finditer(contents):
            if match[1] in entries:
                raise ValueError("Pinned edition repeats a contents clause: " + match[1])
            entries[match[1]] = match[2].strip(), int(match[3]) + self.offset
        headings = {}
        for clause, (title, expected) in entries.items():
            words = r"\s+".join(re.escape(word) for word in title.split())
            heading = re.compile(r"(?<![\w.\u00a7])(?:Annex\s+)?" + re.escape(clause)
                                 + r"(?:\.(?![0-9]))?\s+(?:\((?:normative|informative)\)\s+)?"
                                 + words, re.I)
            matches = [(expected, match.start()) for match in heading.finditer(self.pages[expected - 1])
                       ] if self.offset < expected <= len(self.pages) else []
            if not matches:
                matches = [(number, match.start())
                           for number, page in enumerate(self.pages[self.offset:], self.offset + 1)
                           for match in heading.finditer(page)]
            if not matches:
                raise ValueError("Pinned edition has no body heading for contents clause: " + clause)
            page, position = min(matches, key=lambda pair: (abs(pair[0] - expected), pair))
            headings[clause] = self.starts[page - 1] + position
        # Some contents lists omit the deepest subclauses. Decimal literals and
        # code examples outside an indexed parent are not candidate headings.
        deeper = re.compile(r"(?m)^[ \t]*(?:[0-9]{1,2}[ \t]+)?"
                            r"([1-9][0-9]*(?:\.[0-9]+)+|[A-Z](?:\.[0-9]+)+)[ \t]+[^\s\n][^\n]*")
        candidates = [(match[1], match.start()) for match in deeper.finditer(text)
                      if match.start() >= self.starts[self.offset] and match[1] not in headings]
        for depth in sorted({clause.count(".") for clause, _ in candidates}):
            extents = clause_extents(headings, len(text))
            for clause, position in candidates:
                parent = clause.rsplit(".", 1)[0]
                if clause.count(".") == depth and parent in extents and extents[parent][0] < position < extents[parent][1]:
                    if clause in headings:
                        raise ValueError("Pinned edition repeats a body clause: " + clause)
                    headings[clause] = position
        self.clauses = clause_extents(headings, len(text))

    def excerpt(self, clause, printed, pdf):
        if (not printed or len(printed) != len(pdf)
                or any(type(a) is not int or type(b) is not int or a < 1 or b < 1
                       or a + self.offset != b for a, b in zip(printed, pdf))):
            raise ValueError("Printed/PDF page pairs disagree with the pinned edition")
        if any(page > len(self.pages) for page in pdf):
            raise ValueError("PDF page is outside the pinned extraction")
        if clause not in self.clauses:
            raise ValueError("Edition locator names an unknown clause: " + clause)
        lo, hi = self.clauses[clause]
        spans = [(max(lo, self.starts[page - 1]), min(hi, self.starts[page] - 1)) for page in pdf]
        text = " ".join(self.text[start:end] for start, end in spans if start < end)
        if not text.strip():
            raise ValueError("Edition clause does not intersect its cited PDF pages")
        return text
