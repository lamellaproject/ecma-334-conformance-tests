/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: public sealed override int this[int index]
Into: public override int this[int index]
Csc: CS0239
*/
class Grid { public virtual int this[int index] { get { return index; } set { } } }
class Middle : Grid { public sealed override int this[int index] { get { return index; } set { } } }
class Derived : Middle { public override int this[int index] { set { } } }
class Program { static void Main() { } }
