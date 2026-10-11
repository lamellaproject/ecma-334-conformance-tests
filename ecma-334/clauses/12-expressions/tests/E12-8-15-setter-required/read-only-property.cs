/*
Rules: E12-8-15-setter-required
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: reject
Mutate: public int Value { get { return 3; } }
Into: public int Value { get { return 3; } set { } }
*/
class Cell { public int Value { get { return 3; } } }
class Program { static void Main() { new Cell().Value++; } }
