/*
Rules: E15-11-2-base-constructor-candidate-set
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : base(13)
Into: : base()
Csc: CS1729
*/
class Root { public Root(int n) { } }
class Basis : Root { public Basis() : base(7) { } }
class Gauge : Basis { public Gauge() : base(13) { } }
class Program { static void Main() { } }
