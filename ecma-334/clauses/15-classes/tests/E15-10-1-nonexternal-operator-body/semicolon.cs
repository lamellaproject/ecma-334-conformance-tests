/*
Rules: E15-10-1-nonexternal-operator-body
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: operator +(Gauge x);
Into: operator +(Gauge x) { return 7; }
Csc: CS0501
*/
class Gauge { public static int operator +(Gauge x); }
class Program { static void Main() { } }
