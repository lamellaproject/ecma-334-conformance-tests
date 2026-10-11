/*
Rules: E15-12-external-static-constructor-semicolon
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: extern Gauge() { }
Into: extern Gauge();
Csc: CS0179
*/
class Gauge { static extern Gauge() { } }
class Program { static void Main() { } }
