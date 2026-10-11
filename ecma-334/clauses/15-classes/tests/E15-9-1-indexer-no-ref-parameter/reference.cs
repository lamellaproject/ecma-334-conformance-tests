/*
Rules: E15-9-1-indexer-no-ref-parameter
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: this[ref int index]
Into: this[int index]
*/
class Grid { public int this[ref int index] { get { return index; } } }
class Program { static void Main() { } }
