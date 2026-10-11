/*
Rules: E15-13-grammar-finalizer-declaration-form-2
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: extern extern
Into: extern
*/
class Gauge { extern extern ~Gauge(); }
class Program { static void Main() { } }
