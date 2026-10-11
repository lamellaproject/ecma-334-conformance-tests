/*
Rules: E15-2-4-2-dependency-cycle; E15-2-4-2-dependency-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Gauge : Gauge
Into: class Gauge : object
*/
class Gauge : Gauge { }
class Program { static void Main() { } }
