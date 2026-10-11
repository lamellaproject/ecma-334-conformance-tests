/*
Rules: E15-11-1-constructor-class-name
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: public Other()
Into: public Gauge()
Csc: CS1520
*/
class Gauge { public Other() { } }
class Program { static void Main() { } }
