/*
Rules: E15-4-constant-duplicate-modifier
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: internal internal const int Code = 43;
Into: internal const int Code = 43;
Csc: CS1004
*/
class Limits { internal internal const int Code = 43; }
class Program { static void Main() { int value = Limits.Code; } }
