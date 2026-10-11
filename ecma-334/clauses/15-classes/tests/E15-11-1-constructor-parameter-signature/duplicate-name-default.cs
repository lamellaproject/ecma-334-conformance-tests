/*
Rules: E15-11-1-constructor-parameter-signature
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: Gauge(int renamed = 7)
Into: Gauge(long renamed = 7)
Csc: CS0111
*/
class Gauge { public Gauge(int n = 3) { } public Gauge(int renamed = 7) { } }
class Program { static void Main() { } }
