/*
Rules: E8-3-9-bool-no-standard-value-conversion; E8-3-9-bool-integral-not-interchangeable
Authority: ECMA-334 7th ed 8.3.9
Version: 7.3
Expected: reject
Mutate: int value = source;
Into: int value = source ? 1 : 0;
*/
class Program { static void Main() { bool source = true; int value = source; } }
