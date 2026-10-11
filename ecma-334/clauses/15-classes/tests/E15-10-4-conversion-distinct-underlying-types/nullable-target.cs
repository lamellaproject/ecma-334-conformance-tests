/*
Rules: E15-10-4-conversion-distinct-underlying-types
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: operator Gauge?(Gauge x)
Into: operator int?(Gauge x)
Csc: CS0555
*/
struct Gauge { public static explicit operator Gauge?(Gauge x) { return null; } }
class Program { static void Main() { } }
