/*
Rules: E15-11-5-default-constructor-base-best-unique
Authority: ECMA-334 7th ed 15.11.5
Version: 7.3
Expected: reject
Mutate: public Basis(string value = "coil")
Into: public Basis(string value)
Csc: CS0121
*/
class Basis { public Basis(int value = 13) { } public Basis(string value = "coil") { } }
class Gauge : Basis { }
class Program { static void Main() { } }
