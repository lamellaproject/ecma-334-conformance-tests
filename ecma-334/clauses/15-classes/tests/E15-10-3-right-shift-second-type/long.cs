/*
Rules: E15-10-3-right-shift-second-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: operator >>(Gauge x, long y)
Into: operator >>(Gauge x, int y)
Csc: CS8370
*/
class Gauge { public static int operator >>(Gauge x, long y) { return 7; } }
class Program { static void Main() { } }
