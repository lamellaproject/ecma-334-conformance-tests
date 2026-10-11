/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: protected set { }
Into: set { }
Csc: CS0274
*/
class Grid { public int this[int index] { private get { return index; } protected set { } } }
class Program { static void Main() { } }
