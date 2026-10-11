/*
Rules: E15-11-2-base-constructor-nonempty-set
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: private Basis(int n)
Into: protected Basis(int n)
Csc: CS0122
*/
class Basis { private Basis(int n) { } }
class Gauge : Basis { public Gauge() : base(13) { } }
class Program { static void Main() { } }
