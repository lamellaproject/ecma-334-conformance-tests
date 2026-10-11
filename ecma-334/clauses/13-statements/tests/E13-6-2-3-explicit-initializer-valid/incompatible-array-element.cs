/*
Rules: E13-6-2-3-explicit-initializer-valid
Authority: ECMA-334 7th ed 13.6.2.3
Version: 7.3
Expected: reject
Mutate: { "chip" }
Into: { 4 }
*/
class Program { static void Main() { int[] data = { "chip" }; } }
