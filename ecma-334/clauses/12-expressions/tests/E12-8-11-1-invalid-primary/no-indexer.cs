/*
Rules: E12-8-11-1-invalid-primary
Authority: ECMA-334 7th ed 12.8.11.1
Version: 7.3
Expected: reject
Mutate: class Cell { }
Into: class Cell { public int this[int index] { get { return index; } } }
*/
class Cell { }
class Program { static void Main() { int result = new Cell()[0]; } }
