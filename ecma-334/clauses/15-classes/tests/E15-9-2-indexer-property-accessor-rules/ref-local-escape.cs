/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: return ref local;
Into: return ref stored;
Csc: CS8168
*/
class Grid { int stored; public ref int this[int index] { get { int local = index; return ref local; } } }
class Program { static void Main() { } }
