/*
Rules: E15-9-1-indexer-method-modifier-combinations
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public abstract sealed override int this[int index]
Into: public abstract override int this[int index]
Csc: CS0502
*/
class Grid { public virtual int this[int index] => index; }
abstract class Derived : Grid { public abstract sealed override int this[int index] { get; } }
class Program { static void Main() { } }
