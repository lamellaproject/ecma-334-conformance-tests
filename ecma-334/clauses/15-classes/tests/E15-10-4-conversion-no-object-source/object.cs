/*
Rules: E15-10-4-conversion-no-object-source
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: operator Gauge(object x)
Into: operator Gauge(string x)
Csc: CS0553
*/
class Gauge { public static explicit operator Gauge(object x) { return new Gauge(); } }
class Program { static void Main() { } }
