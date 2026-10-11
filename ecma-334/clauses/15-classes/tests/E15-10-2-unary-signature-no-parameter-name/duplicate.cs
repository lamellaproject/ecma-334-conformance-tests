/*
Rules: E15-10-2-unary-signature-no-parameter-name
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator +(Gauge other)
Into: operator -(Gauge other)
Csc: CS0111
*/
class Gauge { public static int operator +(Gauge x) { return 13; } public static int operator +(Gauge other) { return 19; } }
class Program { static void Main() { } }
