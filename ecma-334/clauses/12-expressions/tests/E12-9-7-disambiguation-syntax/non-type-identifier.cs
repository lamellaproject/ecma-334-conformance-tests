/*
Rules: E12-9-7-disambiguation-syntax
Authority: ECMA-334 7th ed 12.9.7
Version: 7.3
Expected: reject
Mutate: (alias)1
Into: (alias)+1
*/
class Program { static void Main() { int alias = 2; int result = (alias)1; } }
