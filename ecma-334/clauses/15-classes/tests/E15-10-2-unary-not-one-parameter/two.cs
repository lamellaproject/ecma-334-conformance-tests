/*
Rules: E15-10-2-unary-not-one-parameter
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator !(Gauge x, int y)
Into: operator !(Gauge x)
*/
class Gauge { public static int operator !(Gauge x, int y) { return 7; } }
class Program { static void Main() { } }
