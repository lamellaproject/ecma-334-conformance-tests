/*
Rules: E12-8-11-3-applicable-indexer; E12-8-11-3-no-indexer
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: reject
Mutate: receiver["willow"]
Into: receiver[5]
*/
class Cell { public int this[int index] { get { return index; } } }
class Program { static void Main() { Cell receiver = new Cell(); int result = receiver["willow"]; } }
