/*
Rules: E13-6-2-4-ref-writable-reference
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: reject
Mutate: ref int alias = ref source;
Into: ref readonly int alias = ref source;
*/
class Program { static readonly int source = 6; static void Main() { ref int alias = ref source; } }
