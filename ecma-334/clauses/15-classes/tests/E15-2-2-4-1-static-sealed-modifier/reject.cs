/*
Rules: E15-2-2-4-1-static-sealed-modifier
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: static sealed class Gauge
Into: static class Gauge
*/
static sealed class Gauge { }
class Program { static void Main() { } }
