/*
Rules: E15-12-nonexternal-static-constructor-body
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: static Gauge();
Into: static Gauge() { }
Csc: CS0501
*/
class Gauge { static Gauge(); }
class Program { static void Main() { } }
