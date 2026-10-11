/*
Rules: E15-11-2-base-constructor-best-unique
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : base("coil")
Into: : base(13)
Csc: CS1503
*/
class Basis { public Basis(int n) { } }
class Gauge : Basis { public Gauge() : base("coil") { } }
class Program { static void Main() { } }
