/*
Rules: E8-3-3-struct-explicit-parameterless-forbidden
Authority: ECMA-334 7th ed 8.3.3
Version: 7.3
Expected: reject
Mutate: public Sample() { Value = 4; }
Into: public Sample(int ignored) { Value = 4; }
*/
struct Sample { public int Value; public Sample() { Value = 4; } }
class Program { static void Main() { } }
