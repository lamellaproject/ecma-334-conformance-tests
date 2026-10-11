/*
Rules: E12-12-13-expression-source
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: reject
Mutate: int as object
Into: 1 as object
*/
class Program { static void Main() { object result = int as object; } }
