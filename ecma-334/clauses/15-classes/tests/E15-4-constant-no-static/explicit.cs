/*
Rules: E15-4-constant-no-static
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public static const int Code = 919;
Into: public const int Code = 919;
Csc: CS0504
*/
class Limits { public static const int Code = 919; }
class Program { static void Main() { int value = Limits.Code; } }
