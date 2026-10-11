/*
Rules: E15-2-2-2-abstract-instantiation
Authority: ECMA-334 7th ed 15.2.2.2
Version: 7.3
Expected: reject
Mutate: abstract class Gauge
Into: class Gauge
*/
abstract class Gauge { }
class Program { static void Main() { new Gauge(); } }
