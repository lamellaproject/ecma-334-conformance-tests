/*
Rules: E15-9-1-indexer-method-parameter-rules
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: this[int first, int second = Make()]
Into: this[int first, int second = 5]
Csc: CS1736
*/
class Grid { static int Make() { return 5; } public int this[int first, int second = Make()] => first + second; }
class Program { static void Main() { } }
