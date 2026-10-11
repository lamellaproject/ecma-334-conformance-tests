/*
Rules: E15-9-1-indexer-method-parameter-rules
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: this[params int index]
Into: this[int index]
Csc: CS0225
*/
class Grid { public int this[params int index] => index; }
class Program { static void Main() { } }
