/*
Rules: E15-4-circular-constant-dependency
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const int Origin = Tail.Complete >> 1;
Into: public const int Origin = 32;
Csc: CS0110
*/
class Seed { public const int Origin = Tail.Complete >> 1; }
class Middle { public const int Part = Seed.Origin | 1; }
class Tail { public const int Complete = Middle.Part << 1; }
class Program { static void Main() { int value = Tail.Complete; } }
