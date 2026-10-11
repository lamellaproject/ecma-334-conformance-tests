/*
Rules: E15-11-1-constructor-members-declared-or-default
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: new Gauge()
Into: new Gauge(13)
Csc: CS7036
*/
class Gauge { public Gauge(int n) { } }
class Program { static void Main() { Gauge item = new Gauge(); } }
