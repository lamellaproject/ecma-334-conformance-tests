/*
Rules: E15-9-1-indexer-method-modifier-combinations
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public new override int this[int index]
Into: public override int this[int index]
Csc: CS0113
*/
class Grid { public virtual int this[int index] => index; }
class Derived : Grid { public new override int this[int index] => index; }
class Program { static void Main() { } }
