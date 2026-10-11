/*
Rules: E15-2-2-4-1-static-instance-constructor
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: public Gauge()
Into: static Gauge()
*/
static class Gauge { public Gauge() { } }
class Program { static void Main() { } }
