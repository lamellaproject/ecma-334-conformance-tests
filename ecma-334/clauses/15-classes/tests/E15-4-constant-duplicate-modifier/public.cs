/*
Rules: E15-4-constant-duplicate-modifier
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public public const int Code = 29;
Into: public const int Code = 29;
Csc: CS1004
*/
class Limits { public public const int Code = 29; }
class Program { static void Main() { int value = Limits.Code; } }
