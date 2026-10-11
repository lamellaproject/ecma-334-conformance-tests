/*
Rules: E15-3-1-instance-constructor-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public Other() { }
Into: public Meter() { }
*/
class Meter { public Other() { } }
class Program { static void Main() { } }
