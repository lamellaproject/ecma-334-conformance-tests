/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: return value;
Into: return;
Csc: CS0127
*/
class Grid { public int this[int index] { set { return value; } } }
class Program { static void Main() { } }
