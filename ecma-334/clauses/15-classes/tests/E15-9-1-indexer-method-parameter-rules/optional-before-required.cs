/*
Rules: E15-9-1-indexer-method-parameter-rules
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: this[int first = 2, int second]
Into: this[int first, int second]
Csc: CS1737
*/
class Grid { public int this[int first = 2, int second] => first + second; }
class Program { static void Main() { } }
