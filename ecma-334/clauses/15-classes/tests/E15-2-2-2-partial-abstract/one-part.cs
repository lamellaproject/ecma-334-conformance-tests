/*
Rules: E15-2-2-2-partial-abstract
Authority: ECMA-334 7th ed 15.2.2.2
Version: 7.3
Expected: reject
Mutate: abstract partial class Gauge
Into: partial class Gauge
*/
partial class Gauge { }
abstract partial class Gauge { }
class Program { static void Main() { new Gauge(); } }
