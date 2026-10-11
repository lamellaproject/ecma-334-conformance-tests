/*
Rules: E12-8-11-1-dynamic-limited-check
Authority: ECMA-334 7th ed 12.8.11.1
Version: 7.3
Expected: reject
Mutate: receiver[index, 0]
Into: receiver[index]
*/
class Cell { public int this[int index] { get { return index; } } }
class Program { static void Main() { Cell receiver = new Cell(); dynamic index = 0; object result = receiver[index, 0]; } }
