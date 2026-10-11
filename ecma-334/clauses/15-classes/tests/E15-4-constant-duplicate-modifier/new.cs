/*
Rules: E15-4-constant-duplicate-modifier
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public new new const int Code = 71;
Into: public new const int Code = 71;
Csc: CS1004
*/
class Basis { public const int Code = 61; }
class Limits : Basis { public new new const int Code = 71; }
class Program { static void Main() { int value = Limits.Code; } }
