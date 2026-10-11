/*
Rules: E15-9-1-ordinary-indexer-this; E15-9-1-indexer-no-user-name
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: int Entry[int index]
Into: int this[int index]
*/
class Grid { public int Entry[int index] { get { return index; } } }
class Program { static void Main() { } }
