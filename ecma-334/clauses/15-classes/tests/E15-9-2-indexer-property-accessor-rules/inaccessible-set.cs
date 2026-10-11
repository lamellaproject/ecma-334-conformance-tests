/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: private set { }
Into: set { }
Csc: CS0272
*/
class Grid { public int this[int index] { get { return index; } private set { } } }
class Program { static void Main() { new Grid()[2] = 7; } }
