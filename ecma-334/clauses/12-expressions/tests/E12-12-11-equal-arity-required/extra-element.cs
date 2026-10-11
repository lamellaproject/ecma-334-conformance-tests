/*
Rules: E12-12-11-equal-arity-required
Authority: ECMA-334 7th ed 12.12.11
Version: 7.3
Expected: reject
Mutate: (1, 2, 3)
Into: (1, 2)
*/
class Program { static void Main() { bool b = (1, 2) == (1, 2, 3); } }
