/*
Rules: E15-9-1-indexer-method-modifier-combinations
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public sealed int this[int index]
Into: public sealed override int this[int index]
Csc: CS0238
*/
class Grid { public virtual int this[int index] => index; }
class Derived : Grid { public sealed int this[int index] => index; }
class Program { static void Main() { } }
