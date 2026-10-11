/*
Rules: E15-9-1-indexer-expression-readonly
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public int this[int index] => index;
Into: public int this[int index] { get { return index; } set { } }
Csc: CS0200
*/
class Grid { public int this[int index] => index; }
class Program { static void Main() { new Grid()[2] = 5; } }
