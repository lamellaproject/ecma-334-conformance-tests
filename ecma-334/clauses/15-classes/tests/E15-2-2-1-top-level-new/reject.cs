/*
Rules: E15-2-2-1-top-level-new
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: reject
Mutate: new class Gauge
Into: class Gauge
*/
new class Gauge { }
class Program { static void Main() { } }
