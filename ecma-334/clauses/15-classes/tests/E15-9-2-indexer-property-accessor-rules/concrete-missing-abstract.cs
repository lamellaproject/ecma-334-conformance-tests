/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: class Derived : Grid { }
Into: abstract class Derived : Grid { }
Csc: CS0534
*/
abstract class Grid { public abstract int this[int index] { get; set; } }
class Derived : Grid { }
class Program { static void Main() { } }
