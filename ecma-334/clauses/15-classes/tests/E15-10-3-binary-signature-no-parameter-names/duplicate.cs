/*
Rules: E15-10-3-binary-signature-no-parameter-names
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: operator *(Gauge other, int renamed)
Into: operator /(Gauge other, int renamed)
Csc: CS0111
*/
class Gauge { public static int operator *(Gauge x, int n) { return 13; } public static int operator *(Gauge other, int renamed) { return 19; } }
class Program { static void Main() { } }
