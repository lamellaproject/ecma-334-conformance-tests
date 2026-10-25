/*
Rules: E6-5-8-ed1-line-number-no-upper-limit
Authority: ECMA-334 1st ed 9.5.7
Version: ISO-1
Expected: run
Stdout: OK 0
Source-Diagnostic: [{"case_id":"large-line-number","source":"#warning wide-coordinate","severity":"warning","file":"wide.cs","line":20000000,"contains":"wide-coordinate"}]
Version-Witness: tests/E6-5-8-ed1-line-number-no-upper-limit/large-line-indicator.witness.cs.part
Mutate: 20000000
Into: 20000001
*/
// ECMA-334 1st ed 9.5.7, p. 68 (PDF p. 82), lines 24-37 states no numeric cap and requires
// this coordinate.
#line 20000000 "wide.cs"
#warning wide-coordinate
class Entry { public static void Main() { System.Console.WriteLine("OK 0"); } }
