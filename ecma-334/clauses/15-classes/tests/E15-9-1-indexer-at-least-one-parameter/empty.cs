/*
Rules: E15-9-1-indexer-at-least-one-parameter
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: int this[]
Into: int this[int index]
*/
class Grid { public int this[] { get { return 4; } } }
class Program { static void Main() { } }
