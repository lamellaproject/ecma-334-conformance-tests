/*
Rules: E15-4-allowed-constant-type
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const int* Empty = null;
Into: public static readonly int* Empty = null;
Csc: CS0283
*/
unsafe class Limits { public const int* Empty = null; }
class Program { unsafe static void Main() { int* value = Limits.Empty; } }
