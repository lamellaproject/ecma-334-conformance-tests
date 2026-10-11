/*
Rules: E15-12-static-constructor-void-method-body
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: return 7;
Into: return;
Csc: CS0127
*/
class Gauge { static Gauge() { return 7; } }
class Program { static void Main() { } }
