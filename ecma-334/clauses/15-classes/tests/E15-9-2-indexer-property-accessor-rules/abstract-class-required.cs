/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: class Grid
Into: abstract class Grid
Csc: CS0513
*/
class Grid { public abstract int this[int index] { get; } }
class Program { static void Main() { } }
