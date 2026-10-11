/*
Rules: E13-6-2-4-ref-readonly-reference
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: reject
Mutate: alias = 8;
Into: source = 8;
*/
class Program { static void Main() { int source = 6; ref readonly int alias = ref source; alias = 8; } }
