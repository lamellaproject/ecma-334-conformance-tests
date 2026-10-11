/*
Rules: E15-10-1-external-operator-semicolon
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: operator +(Gauge x) => 7;
Into: operator +(Gauge x);
Csc: CS0179
*/
class Gauge { public static extern int operator +(Gauge x) => 7; }
class Program { static void Main() { } }
