/*
Rules: E15-9-1-indexer-method-parameter-rules
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: this[int index, int index]
Into: this[int index, int other]
Csc: CS0100
*/
class Grid { public int this[int index, int index] => 3; }
class Program { static void Main() { } }
