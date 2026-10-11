/*
Rules: E15-12-static-constructor-class-name
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: static Other()
Into: static Gauge()
Csc: CS1520
*/
class Gauge { static Other() { } }
class Program { static void Main() { } }
