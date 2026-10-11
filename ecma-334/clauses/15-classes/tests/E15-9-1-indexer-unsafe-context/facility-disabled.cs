/*
Rules: E15-9-1-indexer-unsafe-context
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: public unsafe int this[int index]
Into: public int this[int index]
Csc: CS0227
*/
class Grid { public unsafe int this[int index] => index; }
class Program { static void Main() { } }
