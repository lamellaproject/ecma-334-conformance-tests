/*
Rules: E15-9-1-indexer-no-out-parameter
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: this[out int index]
Into: this[int index]
*/
class Grid { public int this[out int index] { get { index = 0; return 3; } } }
class Program { static void Main() { } }
