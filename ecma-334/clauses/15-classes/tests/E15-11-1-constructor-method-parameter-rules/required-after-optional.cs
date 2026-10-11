/*
Rules: E15-11-1-constructor-method-parameter-rules
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: Gauge(int n = 3, int other)
Into: Gauge(int n, int other)
*/
class Gauge { public Gauge(int n = 3, int other) { } }
class Program { static void Main() { } }
