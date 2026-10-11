/*
Rules: E13-6-2-4-ref-initializer-type
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: reject
Mutate: ref long alias = ref value;
Into: ref int alias = ref value;
*/
class Program { static void Main() { int value = 6; ref long alias = ref value; } }
