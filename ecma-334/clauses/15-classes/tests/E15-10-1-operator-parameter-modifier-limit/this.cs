/*
Rules: E15-10-1-operator-parameter-modifier-limit
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: this Gauge x
Into: Gauge x
*/
class Gauge { public static int operator +(this Gauge x) { return 7; } }
class Program { static void Main() { } }
