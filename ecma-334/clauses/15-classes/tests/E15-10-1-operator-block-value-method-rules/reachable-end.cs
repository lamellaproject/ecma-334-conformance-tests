/*
Rules: E15-10-1-operator-block-value-method-rules
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: if (x != null) return 7;
Into: return 7;
Csc: CS0161
*/
class Gauge { public static int operator +(Gauge x) { if (x != null) return 7; } }
class Program { static void Main() { } }
