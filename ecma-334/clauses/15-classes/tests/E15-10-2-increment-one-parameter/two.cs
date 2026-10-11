/*
Rules: E15-10-2-increment-one-parameter
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator ++(Gauge x, int y)
Into: operator ++(Gauge x)
*/
class Gauge { public static Gauge operator ++(Gauge x, int y) { return x; } }
class Program { static void Main() { } }
