/*
Rules: E15-13-grammar-finalizer-declaration-form-1
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: ~Gauge(int n)
Into: ~Gauge()
*/
class Gauge { ~Gauge(int n) { } }
class Program { static void Main() { } }
