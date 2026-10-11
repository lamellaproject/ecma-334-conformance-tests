/*
Rules: E15-9-1-indexer-no-this-parameter
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: this[this int index]
Into: this[int index]
*/
class Grid { public int this[this int index] { get { return index; } } }
class Program { static void Main() { } }
