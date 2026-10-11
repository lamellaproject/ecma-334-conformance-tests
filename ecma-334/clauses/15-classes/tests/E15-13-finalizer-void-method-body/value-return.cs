/*
Rules: E15-13-finalizer-void-method-body
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: return 13;
Into: return;
*/
class Gauge { ~Gauge() { return 13; } }
class Program { static void Main() { } }
