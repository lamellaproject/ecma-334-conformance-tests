/*
Rules: E15-11-1-constructor-method-parameter-rules
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: Gauge(int n, int n)
Into: Gauge(int n, int other)
*/
class Gauge { public Gauge(int n, int n) { } }
class Program { static void Main() { } }
