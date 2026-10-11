/*
Rules: E15-13-finalizer-unsafe-context
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: unsafe ~Gauge()
Into: ~Gauge()
*/
class Gauge { unsafe ~Gauge() { } }
class Program { static void Main() { } }
