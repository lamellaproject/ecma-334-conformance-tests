/*
Rules: E15-9-1-indexer-method-modifier-combinations
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public abstract extern int this[int index]
Into: public abstract int this[int index]
Csc: CS0180
*/
abstract class Grid { public abstract extern int this[int index] { get; } }
class Program { static void Main() { } }
