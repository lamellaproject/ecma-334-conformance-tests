/*
Rules: E15-2-2-4-1-static-instantiation
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: static class Gauge
Into: class Gauge
*/
static class Gauge { }
class Program { static void Main() { new Gauge(); } }
