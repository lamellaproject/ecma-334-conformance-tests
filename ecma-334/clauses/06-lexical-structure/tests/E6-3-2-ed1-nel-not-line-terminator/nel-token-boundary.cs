/*
Rules: E6-3-2-ed1-nel-not-line-terminator
Authority: ECMA-334 1st ed 9.3.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E6-3-2-ed1-nel-not-line-terminator/nel-token-boundary.witness.cs.part
Mutate: \xC2\x85
Into: \x20
*/
// ECMA-334 1st ed 9.3.1, p. 52 (PDF p. 66), lines 32-37 has no NEL line terminator.
class Boundary{ public static int Main() { return 0; } }
