/*
Rules: E15-12-grammar-static-constructor-modifiers-form-2
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: static extern extern
Into: static extern
Csc: CS1004
*/
class Gauge { static extern extern Gauge(); }
class Program { static void Main() { } }
