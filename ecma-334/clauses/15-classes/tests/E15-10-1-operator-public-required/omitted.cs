/*
Rules: E15-10-1-operator-public-required
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: static int operator +(Gauge x)
Into: public static int operator +(Gauge x)
Csc: CS0558
*/
class Gauge { static int operator +(Gauge x) { return 7; } }
class Program { static void Main() { } }
