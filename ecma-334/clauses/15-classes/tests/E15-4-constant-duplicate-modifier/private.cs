/*
Rules: E15-4-constant-duplicate-modifier
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: private private const int Code = 59;
Into: private const int Code = 59;
Csc: CS1004
*/
class Limits { private private const int Code = 59; }
class Program { static void Main() { } }
