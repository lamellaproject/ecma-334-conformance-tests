/*
Rules: E6-5-1-ed1-directive-nel-not-terminator
Authority: ECMA-334 1st ed 9.5.3
Version: ISO-1
Expected: reject
Version-Witness: tests/E6-5-1-ed1-directive-nel-not-terminator/nel-directive-boundary.witness.cs.part
Mutate: \xC2\x85
Into: \x0A
*/
// ECMA-334 1st ed 9.5.3, p. 64 (PDF p. 78), line 17 needs an old newline after the symbol.
#define Activeclass Entry { public static int Main() { return 0; } }
