/*
Rules: E15-10-1-operator-no-duplicate-modifier
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: unsafe unsafe
Into: unsafe
Csc: CS1004
*/
class Gauge { public static unsafe unsafe int operator +(Gauge x) { return 7; } }
class Program { static void Main() { } }
