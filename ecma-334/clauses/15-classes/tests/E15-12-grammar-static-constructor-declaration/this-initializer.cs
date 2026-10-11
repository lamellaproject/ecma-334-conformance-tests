/*
Rules: E15-12-grammar-static-constructor-declaration
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: : this()
Into: 
*/
class Gauge { static Gauge() : this() { } }
class Program { static void Main() { } }
