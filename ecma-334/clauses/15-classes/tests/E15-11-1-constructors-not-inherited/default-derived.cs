/*
Rules: E15-11-1-constructors-not-inherited; E15-11-1-constructor-members-declared-or-default
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: new Derived(13)
Into: new Derived()
Csc: CS1729
*/
class Basis { public Basis() { } public Basis(int n) { } }
class Derived : Basis { }
class Program { static void Main() { Derived item = new Derived(13); } }
