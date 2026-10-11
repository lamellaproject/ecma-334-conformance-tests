/*
Rules: E12-8-15-getter-required
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: reject
Mutate: public int Value { set { } }
Into: public int Value { get { return 3; } set { } }
*/
class Cell { public int Value { set { } } }
class Program { static void Main() { new Cell().Value++; } }
