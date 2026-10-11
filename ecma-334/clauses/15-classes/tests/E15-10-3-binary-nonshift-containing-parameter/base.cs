/*
Rules: E15-10-3-binary-nonshift-containing-parameter
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: operator *(Basis x, int y)
Into: operator *(Gauge x, int y)
Csc: CS0563
*/
class Basis { }
class Gauge : Basis { public static int operator *(Basis x, int y) { return 7; } }
class Program { static void Main() { } }
