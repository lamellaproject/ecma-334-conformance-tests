/*
Rules: E15-4-constant-expression-conversion
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const bool Ready = 1;
Into: public const bool Ready = true;
Csc: CS0029
*/
class Limits { public const bool Ready = 1; }
class Program { static void Main() { bool value = Limits.Ready; } }
