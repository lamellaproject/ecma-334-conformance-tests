/*
Rules: E15-9-2-indexer-no-semicolon-implementation
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: public int this[int index]
Into: public abstract int this[int index]
Csc: CS0501
*/
abstract class Grid { public int this[int index] { get; set; } }
class Program { static void Main() { } }
