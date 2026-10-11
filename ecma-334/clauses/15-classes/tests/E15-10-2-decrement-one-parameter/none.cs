/*
Rules: E15-10-2-decrement-one-parameter
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator --()
Into: operator --(Gauge x)
*/
class Gauge { public static Gauge operator --() { return new Gauge(); } }
class Program { static void Main() { } }
