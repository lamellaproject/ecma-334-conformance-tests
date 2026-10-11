/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: get { return 5; } set { }
Into: set { }
*/
class Grid { public virtual int this[int index] { private get { return 4; } set { } } }
class Derived : Grid { public override int this[int index] { get { return 5; } set { } } }
class Program { static void Main() { } }
