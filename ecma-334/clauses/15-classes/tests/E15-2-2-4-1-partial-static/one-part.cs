/*
Rules: E15-2-2-4-1-partial-static
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: static partial class Gauge
Into: partial class Gauge
*/
partial class Gauge { }
static partial class Gauge { }
class Program { static void Main() { new Gauge(); } }
