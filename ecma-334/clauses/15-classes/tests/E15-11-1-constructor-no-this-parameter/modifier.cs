/*
Rules: E15-11-1-constructor-no-this-parameter
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: this int n
Into: int n
*/
class Gauge { public Gauge(this int n) { } }
class Program { static void Main() { } }
