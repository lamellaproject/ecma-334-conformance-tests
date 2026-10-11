/*
Rules: E15-2-2-2-abstract-sealed; E15-2-2-3-sealed-abstract
Authority: ECMA-334 7th ed 15.2.2.2
Version: 7.3
Expected: reject
Mutate: abstract sealed class Gauge
Into: abstract class Gauge
*/
abstract sealed class Gauge { }
class Program { static void Main() { } }
