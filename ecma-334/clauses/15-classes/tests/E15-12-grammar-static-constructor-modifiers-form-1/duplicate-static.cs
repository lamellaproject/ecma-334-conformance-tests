/*
Rules: E15-12-grammar-static-constructor-modifiers-form-1
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: static static
Into: static
Csc: CS1004
*/
class Gauge { static static Gauge() { } }
class Program { static void Main() { } }
