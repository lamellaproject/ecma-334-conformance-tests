/*
Rules: E15-13-finalizer-class-name
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: ~Other()
Into: ~Gauge()
*/
class Gauge { ~Other() { } }
class Program { static void Main() { } }
