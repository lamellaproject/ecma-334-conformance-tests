/*
Rules: E8-3-9-bool-integral-not-interchangeable
Authority: ECMA-334 7th ed 8.3.9
Version: 7.3
Expected: reject
Mutate: bool value = source;
Into: bool value = source != 0;
*/
class Program { static void Main() { int source = 1; bool value = source; } }
