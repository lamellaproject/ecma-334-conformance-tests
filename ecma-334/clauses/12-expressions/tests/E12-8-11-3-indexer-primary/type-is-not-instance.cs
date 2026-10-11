/*
Rules: E12-8-11-3-indexer-primary
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: reject
Mutate: Cell[0]
Into: new Cell()[0]
*/
class Cell { public int this[int index] { get { return index; } } }
class Program { static void Main() { int result = Cell[0]; } }
