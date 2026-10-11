/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: public get { return index; }
Into: get { return index; }
Csc: CS0273
*/
class Grid { public int this[int index] { public get { return index; } set { } } }
class Program { static void Main() { } }
