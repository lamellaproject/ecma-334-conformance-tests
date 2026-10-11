/*
Rules: E15-11-1-constructor-unsafe-context
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: public unsafe Gauge()
Into: public Gauge()
Csc: CS0227
*/
class Gauge { public unsafe Gauge() { } }
class Program { static void Main() { } }
