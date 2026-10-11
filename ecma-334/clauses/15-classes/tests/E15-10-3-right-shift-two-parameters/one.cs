/*
Rules: E15-10-3-right-shift-two-parameters
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: operator >>(Gauge x)
Into: operator >>(Gauge x, int y)
*/
class Gauge { public static int operator >>(Gauge x) { return 7; } }
class Program { static void Main() { } }
