/*
Rules: E13-6-2-2-implicit-single-variable
Authority: ECMA-334 7th ed 13.6.2.2
Version: 7.3
Expected: reject
Mutate: var first = 1, second = 2;
Into: int first = 1, second = 2;
*/
class Program { static void Main() { var first = 1, second = 2; } }
