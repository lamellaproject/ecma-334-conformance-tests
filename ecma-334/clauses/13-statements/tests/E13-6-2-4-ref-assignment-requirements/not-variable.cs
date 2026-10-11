/*
Rules: E13-6-2-4-ref-assignment-requirements
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: reject
Mutate: ref int alias = ref (value + 1);
Into: ref int alias = ref value;
*/
class Program { static void Main() { int value = 6; ref int alias = ref (value + 1); } }
