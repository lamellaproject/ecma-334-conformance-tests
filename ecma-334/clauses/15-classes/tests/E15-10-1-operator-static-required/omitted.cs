/*
Rules: E15-10-1-operator-static-required
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: public int operator +(Gauge x)
Into: public static int operator +(Gauge x)
Csc: CS0558
*/
class Gauge { public int operator +(Gauge x) { return 7; } }
class Program { static void Main() { } }
