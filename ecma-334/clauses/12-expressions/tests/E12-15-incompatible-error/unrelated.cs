/*
Rules: E12-15-incompatible-error
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: reject
Mutate: left ?? right
Into: (object)left ?? right
*/
class A { } class B { }
class Program { static void Main() { A left = new A(); B right = new B(); var result = left ?? right; } }
