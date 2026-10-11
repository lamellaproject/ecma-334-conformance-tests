/*
Rules: E15-10-2-unary-signature-no-return-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: long operator +(Gauge x)
Into: long operator -(Gauge x)
Csc: CS0111
*/
class Gauge { public static int operator +(Gauge x) { return 13; } public static long operator +(Gauge x) { return 19; } }
class Program { static void Main() { } }
