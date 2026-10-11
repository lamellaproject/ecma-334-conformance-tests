/*
Rules: E15-9-1-indexer-parameter-type-accessibility
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public int this[Hidden index]
Into: private int this[Hidden index]
Csc: CS0055
*/
public class Grid { private class Hidden { } public int this[Hidden index] => 7; }
class Program { static void Main() { } }
