/*
Rules: E15-10-1-operator-no-new
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: public new static
Into: public static
Csc: CS0106
*/
class Gauge { public new static int operator +(Gauge x) { return 7; } }
class Program { static void Main() { } }
