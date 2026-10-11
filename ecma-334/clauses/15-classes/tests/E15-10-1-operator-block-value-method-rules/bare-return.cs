/*
Rules: E15-10-1-operator-block-value-method-rules
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: return;
Into: return 7;
Csc: CS0126
*/
class Gauge { public static int operator +(Gauge x) { return; } }
class Program { static void Main() { } }
