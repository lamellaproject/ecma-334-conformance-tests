/*
Rules: E15-13-external-finalizer-semicolon
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: extern ~Gauge() { }
Into: extern ~Gauge();
*/
class Gauge { extern ~Gauge() { } }
class Program { static void Main() { } }
