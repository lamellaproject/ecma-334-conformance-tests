/*
Rules: E8-3-6-ulong-range
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: reject
Generated: clauses/08-types/generators/numeric-matrix.py
*/
class Program { static void Main() { const ulong value = (ulong)18446744073709551616m; } }
