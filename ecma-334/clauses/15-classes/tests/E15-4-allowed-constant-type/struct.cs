/*
Rules: E15-4-allowed-constant-type
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const Offset Empty = default(Offset);
Into: public static readonly Offset Empty = default(Offset);
Csc: CS0283
*/
struct Offset { }
class Limits { public const Offset Empty = default(Offset); }
class Program { static void Main() { Offset value = Limits.Empty; } }
