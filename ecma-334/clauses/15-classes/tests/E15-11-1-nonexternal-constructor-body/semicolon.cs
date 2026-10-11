/*
Rules: E15-11-1-nonexternal-constructor-body
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: public Gauge();
Into: public Gauge() { }
Csc: CS0501
*/
class Gauge { public Gauge(); }
class Program { static void Main() { } }
