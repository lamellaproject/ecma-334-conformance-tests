/*
Rules: E15-4-constant-shared-modifiers
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: private const int First = 53, Second = 67;
Into: public const int First = 53, Second = 67;
Csc: CS0122
*/
class Limits { private const int First = 53, Second = 67; }
class Program { static void Main() { int value = Limits.First; } }
