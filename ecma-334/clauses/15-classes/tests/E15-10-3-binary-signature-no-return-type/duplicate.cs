/*
Rules: E15-10-3-binary-signature-no-return-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: long operator *(Gauge x, int n)
Into: long operator /(Gauge x, int n)
Csc: CS0111
*/
class Gauge { public static int operator *(Gauge x, int n) { return 13; } public static long operator *(Gauge x, int n) { return 19; } }
class Program { static void Main() { } }
