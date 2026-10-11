/*
Rules: E15-13-finalizer-void-method-body
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: => 13;
Into: => N = 13;
*/
class Gauge { int N; ~Gauge() => 13; }
class Program { static void Main() { } }
