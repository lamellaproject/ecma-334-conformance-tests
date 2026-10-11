/*
Rules: E15-10-1-operator-no-duplicate-modifier
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: extern extern
Into: extern
Csc: CS1004
*/
class Gauge { public static extern extern int operator +(Gauge x) ; }
class Program { static void Main() { } }
