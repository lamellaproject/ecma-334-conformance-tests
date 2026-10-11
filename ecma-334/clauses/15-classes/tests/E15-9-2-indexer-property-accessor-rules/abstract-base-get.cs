/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: return base[index];
Into: return index;
Csc: CS0205
*/
abstract class Grid { public abstract int this[int index] { get; } }
class Derived : Grid { public override int this[int index] { get { return base[index]; } } }
class Program { static void Main() { } }
