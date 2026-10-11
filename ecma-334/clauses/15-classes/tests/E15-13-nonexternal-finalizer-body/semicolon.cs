/*
Rules: E15-13-nonexternal-finalizer-body
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: ~Gauge();
Into: ~Gauge() { }
*/
class Gauge { ~Gauge(); }
class Program { static void Main() { } }
