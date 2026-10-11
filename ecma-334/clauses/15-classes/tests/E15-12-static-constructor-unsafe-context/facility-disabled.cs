/*
Rules: E15-12-static-constructor-unsafe-context
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: unsafe static Gauge()
Into: static Gauge()
Csc: CS0227
*/
class Gauge { unsafe static Gauge() { } }
class Program { static void Main() { } }
