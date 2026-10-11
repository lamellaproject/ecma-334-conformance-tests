/*
Rules: E15-12-grammar-static-constructor-declaration
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: static Gauge(int n)
Into: static Gauge()
Csc: CS0132
*/
class Gauge { static Gauge(int n) { } }
class Program { static void Main() { } }
