/*
Rules: E15-10-3-binary-nonshift-containing-parameter
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: operator *(int x, int y)
Into: operator *(Gauge x, int y)
Csc: CS0563
*/
class Gauge { public static int operator *(int x, int y) { return 7; } }
class Program { static void Main() { } }
