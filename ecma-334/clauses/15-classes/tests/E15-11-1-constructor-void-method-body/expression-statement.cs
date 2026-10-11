/*
Rules: E15-11-1-constructor-void-method-body
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: => 7;
Into: => N = 7;
Csc: CS0201
*/
class Gauge { public int N; public Gauge() => 7; }
class Program { static void Main() { } }
