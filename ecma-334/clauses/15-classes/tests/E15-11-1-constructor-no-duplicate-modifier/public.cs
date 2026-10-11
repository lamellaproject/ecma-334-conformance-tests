/*
Rules: E15-11-1-constructor-no-duplicate-modifier
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: public public
Into: public
Csc: CS1004
*/
class Gauge { public public Gauge() { } }
class Program { static void Main() { } }
