/*
Rules: E6-5-8-ed1-raw-nel-filename
Authority: ECMA-334 1st ed 9.5.7
Version: ISO-1
Expected: run
Stdout: OK 0
Source-Diagnostic: [{"case_id":"logical-filename","source":"#warning filename-probe","severity":"warning","file":"map\u0085unit.cs","line":61,"contains":"filename-probe"}]
Version-Witness: tests/E6-5-8-ed1-raw-nel-filename/nel-line-filename.witness.cs.part
Mutate: \xC2\x85
Into: _
*/
// ECMA-334 1st ed 9.5.7, p. 68 (PDF p. 82), line 34 permits this filename character.
#line 61 "mapunit.cs"
#warning filename-probe
class Entry { public static void Main() { System.Console.WriteLine("OK 0"); } }
