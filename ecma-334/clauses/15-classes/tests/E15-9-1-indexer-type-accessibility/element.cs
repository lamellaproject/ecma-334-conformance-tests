/*
Rules: E15-9-1-indexer-type-accessibility
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public Hidden this[int index]
Into: private Hidden this[int index]
Csc: CS0054
*/
public class Grid { private class Hidden { } public Hidden this[int index] => null; }
class Program { static void Main() { } }
