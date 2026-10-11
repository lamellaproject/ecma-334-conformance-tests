/*
Rules: E15-11-5-default-constructor-base-best-unique
Authority: ECMA-334 7th ed 15.11.5
Version: 7.3
Expected: reject
Mutate: private Basis()
Into: protected Basis()
Csc: CS0122
*/
class Basis { private Basis() { } }
class Gauge : Basis { }
class Program { static void Main() { } }
