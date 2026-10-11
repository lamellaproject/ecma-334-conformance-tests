/*
Rules: E12-8-11-1-ref-argument
Authority: ECMA-334 7th ed 12.8.11.1
Version: 7.3
Expected: reject
Mutate: receiver[ref index]
Into: receiver[index]
*/
class Cell { public int this[int index] { get { return index; } } }
class Program { static void Main() { int index = 0; Cell receiver = new Cell(); int result = receiver[ref index]; } }
