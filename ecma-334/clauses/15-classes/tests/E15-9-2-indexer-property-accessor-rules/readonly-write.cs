/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: public ref readonly int this[int index]
Into: public ref int this[int index]
Csc: CS8331
*/
class Grid { int stored; public ref readonly int this[int index] => ref stored; }
class Program { static void Main() { new Grid()[1] = 3; } }
