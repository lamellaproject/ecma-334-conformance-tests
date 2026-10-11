/*
Rules: E15-4-circular-constant-dependency
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const int Code = Code;
Into: public const int Code = 59;
Csc: CS0110
*/
class Limits { public const int Code = Code; }
class Program { static void Main() { int value = Limits.Code; } }
