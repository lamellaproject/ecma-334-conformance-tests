/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: this[int value]
Into: this[int index]
Csc: CS0316
*/
class Grid { public int this[int value] { get { return 4; } set { } } }
class Program { static void Main() { } }
