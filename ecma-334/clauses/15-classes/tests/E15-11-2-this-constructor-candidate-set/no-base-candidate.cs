/*
Rules: E15-11-2-this-constructor-candidate-set; E15-11-2-this-constructor-applicable-required
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : this(13)
Into: : base(13)
Csc: CS1729
*/
class Basis { public Basis() { } public Basis(int n) { } }
class Gauge : Basis { public Gauge() : this(13) { } }
class Program { static void Main() { } }
