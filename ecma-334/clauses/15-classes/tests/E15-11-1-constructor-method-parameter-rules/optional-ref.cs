/*
Rules: E15-11-1-constructor-method-parameter-rules
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: Gauge(ref int n = 3)
Into: Gauge(ref int n)
*/
class Gauge { public Gauge(ref int n = 3) { } }
class Program { static void Main() { } }
