/*
Rules: E12-8-9-3-eligible-nongeneric-class
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: reject
Mutate: this Cell receiver
Into: Cell receiver
*/
class Cell { }
static class Extensions<T> { public static int Read(this Cell receiver) { return 3; } }
class Program { static void Main() { Extensions<int>.Read(new Cell()); } }
