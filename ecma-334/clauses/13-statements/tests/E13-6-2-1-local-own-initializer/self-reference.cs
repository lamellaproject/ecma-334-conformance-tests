/*
Rules: E13-6-2-1-local-own-initializer
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: int value = value + 1;
Into: int value = 1;
*/
class Program { static void Main() { int value = value + 1; } }
