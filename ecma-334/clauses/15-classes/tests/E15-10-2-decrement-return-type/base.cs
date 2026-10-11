/*
Rules: E15-10-2-decrement-return-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: object operator --
Into: Gauge operator --
Csc: CS0448
*/
class Gauge { public static object operator --(Gauge x) { return x; } }
class Program { static void Main() { } }
