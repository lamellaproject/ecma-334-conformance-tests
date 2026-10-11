/*
Rules: E15-12-grammar-static-constructor-declaration
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: public static Gauge()
Into: static Gauge()
Csc: CS0515
*/
class Gauge { public static Gauge() { } }
class Program { static void Main() { } }
