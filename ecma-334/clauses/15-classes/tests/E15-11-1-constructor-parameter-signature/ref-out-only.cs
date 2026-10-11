/*
Rules: E15-11-1-constructor-parameter-signature
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: Gauge(out int n)
Into: Gauge(int n)
Csc: CS0663
*/
class Gauge { public Gauge(ref int n) { n = 13; } public Gauge(out int n) { n = 19; } }
class Program { static void Main() { } }
