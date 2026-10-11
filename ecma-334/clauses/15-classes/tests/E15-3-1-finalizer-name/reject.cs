/*
Rules: E15-3-1-finalizer-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: ~Other() { }
Into: ~Meter() { }
*/
class Meter { ~Other() { } }
class Program { static void Main() { } }
