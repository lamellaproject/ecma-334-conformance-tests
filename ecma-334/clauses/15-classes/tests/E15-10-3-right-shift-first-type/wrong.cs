/*
Rules: E15-10-3-right-shift-first-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: operator >>(object x, int y)
Into: operator >>(Gauge x, int y)
Csc: CS0564
*/
class Gauge { public static int operator >>(object x, int y) { return 7; } }
class Program { static void Main() { } }
