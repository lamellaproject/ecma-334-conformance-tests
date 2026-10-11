/*
Rules: E12-9-6-result-value
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: reject
Mutate: ref ++value
Into: ref value
*/
class Program { static void Use(ref int value) { } static void Main() { int value = 3; Use(ref ++value); } }
