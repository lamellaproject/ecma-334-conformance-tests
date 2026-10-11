/*
Rules: E15-13-grammar-finalizer-declaration-form-1
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: virtual ~Gauge()
Into: ~Gauge()
*/
class Gauge { virtual ~Gauge() { } }
class Program { static void Main() { } }
