/*
Rules: E15-9-1-indexer-method-modifier-combinations
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public public int this[int index]
Into: public int this[int index]
Csc: CS1004
*/
class Grid { public public int this[int index] => index; }
class Program { static void Main() { } }
