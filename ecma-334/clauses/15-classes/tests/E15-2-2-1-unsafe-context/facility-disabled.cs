/*
Rules: E15-2-2-1-unsafe-context
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: unsafe class Gauge
Into: class Gauge
*/
// The per-test compiler options disable the unsafe-code facility.
unsafe class Gauge { }
class Program { static void Main() { } }
