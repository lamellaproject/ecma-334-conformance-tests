/*
Rules: E15-4-constant-expression-conversion
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const int Code = 101L;
Into: public const int Code = 101;
Csc: CS0266
*/
class Limits { public const int Code = 101L; }
class Program { static void Main() { int value = Limits.Code; } }
