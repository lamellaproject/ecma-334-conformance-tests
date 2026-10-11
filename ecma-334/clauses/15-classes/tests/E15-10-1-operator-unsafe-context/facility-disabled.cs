/*
Rules: E15-10-1-operator-unsafe-context
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: public static unsafe int operator +(Gauge x)
Into: public static int operator +(Gauge x)
Csc: CS0227
*/
class Gauge { public static unsafe int operator +(Gauge x) { return 7; } }
class Program { static void Main() { } }
