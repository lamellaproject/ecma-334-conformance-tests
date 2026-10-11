/*
Rules: E15-10-2-unary-complement-parameter-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator ~(object x)
Into: operator ~(Gauge x)
Csc: CS0562
*/
class Gauge { public static int operator ~(object x) { return 7; } }
class Program { static void Main() { } }
