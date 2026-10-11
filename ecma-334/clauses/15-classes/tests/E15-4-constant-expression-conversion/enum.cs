/*
Rules: E15-4-constant-expression-conversion
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const Phase Current = 1;
Into: public const Phase Current = Phase.Ready;
Csc: CS0266
*/
enum Phase { Idle = 0, Ready = 1 }
class Limits { public const Phase Current = 1; }
class Program { static void Main() { Phase value = Limits.Current; } }
