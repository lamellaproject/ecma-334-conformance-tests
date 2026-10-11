/*
Rules: E15-11-5-default-constructor-base-best-unique
Authority: ECMA-334 7th ed 15.11.5
Version: 7.3
Expected: reject
Mutate: public Basis(int n)
Into: public Basis(int n = 13)
Csc: CS7036
*/
class Basis { public Basis(int n) { } }
class Gauge : Basis { }
class Program { static void Main() { } }
