/*
Rules: E15-10-2-increment-parameter-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator ++(object x)
Into: operator ++(Gauge x)
Csc: CS0559
*/
class Gauge { public static Gauge operator ++(object x) { return new Gauge(); } }
class Program { static void Main() { } }
