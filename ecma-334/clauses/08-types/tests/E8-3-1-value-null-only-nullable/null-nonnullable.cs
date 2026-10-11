/*
Rules: E8-3-1-value-null-only-nullable
Authority: ECMA-334 7th ed 8.3.1
Version: 7.3
Expected: reject
Mutate: int value = null;
Into: int? value = null;
*/
class Program { static void Main() { int value = null; } }
