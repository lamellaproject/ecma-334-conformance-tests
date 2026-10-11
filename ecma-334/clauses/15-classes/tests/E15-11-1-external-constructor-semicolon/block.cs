/*
Rules: E15-11-1-external-constructor-semicolon
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: extern Gauge() { }
Into: extern Gauge();
Csc: CS0179
*/
class Gauge { public extern Gauge() { } }
class Program { static void Main() { } }
