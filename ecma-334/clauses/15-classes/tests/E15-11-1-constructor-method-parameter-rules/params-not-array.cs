/*
Rules: E15-11-1-constructor-method-parameter-rules
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: Gauge(params int n)
Into: Gauge(int n)
*/
class Gauge { public Gauge(params int n) { } }
class Program { static void Main() { } }
