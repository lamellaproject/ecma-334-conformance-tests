/*
Rules: E15-11-1-constructor-void-method-body
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: return 7;
Into: return;
Csc: CS0127
*/
class Gauge { public Gauge() { return 7; } }
class Program { static void Main() { } }
