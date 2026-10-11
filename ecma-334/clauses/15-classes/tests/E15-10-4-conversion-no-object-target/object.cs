/*
Rules: E15-10-4-conversion-no-object-target
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: operator object(Gauge x)
Into: operator string(Gauge x)
Csc: CS0553
*/
class Gauge { public static explicit operator object(Gauge x) { return null; } }
class Program { static void Main() { } }
