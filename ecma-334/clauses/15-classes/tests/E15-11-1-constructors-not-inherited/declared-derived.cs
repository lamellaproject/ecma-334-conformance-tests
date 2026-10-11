/*
Rules: E15-11-1-constructors-not-inherited
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: new Derived(13)
Into: new Derived()
Csc: CS1729
*/
class Basis { public Basis(int n) { } }
class Derived : Basis { public Derived() : base(7) { } }
class Program { static void Main() { Derived item = new Derived(13); } }
