/*
Rules: E12-15-left-type-restriction
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: reject
Mutate: left ?? right
Into: (int?)left ?? right
*/
class Program { static void Main() { int left = 3, right = 7; var result = left ?? right; } }
