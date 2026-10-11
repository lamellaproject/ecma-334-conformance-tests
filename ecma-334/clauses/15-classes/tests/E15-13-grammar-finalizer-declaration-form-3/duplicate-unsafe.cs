/*
Rules: E15-13-grammar-finalizer-declaration-form-3
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: unsafe unsafe
Into: unsafe
*/
class Gauge { unsafe unsafe ~Gauge() { } }
class Program { static void Main() { } }
