/*
Rules: E15-9-1-indexer-method-parameter-rules
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: this[params int[] first, int second]
Into: this[int[] first, int second]
Csc: CS0231
*/
class Grid { public int this[params int[] first, int second] => second; }
class Program { static void Main() { } }
