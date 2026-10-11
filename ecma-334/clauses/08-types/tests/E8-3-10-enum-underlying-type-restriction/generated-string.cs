/*
Rules: E8-3-10-enum-underlying-type-restriction
Authority: ECMA-334 7th ed 8.3.10
Version: 7.3
Expected: reject
Generated: clauses/08-types/generators/numeric-matrix.py
*/
enum Code : string { Marker }
class Program { static void Main() { } }
