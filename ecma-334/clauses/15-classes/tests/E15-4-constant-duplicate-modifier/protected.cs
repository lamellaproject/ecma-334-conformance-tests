/*
Rules: E15-4-constant-duplicate-modifier
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: protected protected const int Code = 37;
Into: protected const int Code = 37;
Csc: CS1004
*/
class Limits { protected protected const int Code = 37; }
class Program { static void Main() { } }
