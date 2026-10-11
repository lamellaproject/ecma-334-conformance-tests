/*
Rules: E15-12-grammar-static-constructor-modifiers-form-3
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: static unsafe unsafe
Into: static unsafe
Csc: CS1004
*/
class Gauge { static unsafe unsafe Gauge() { } }
class Program { static void Main() { } }
