/*
Rules: E15-9-1-ref-indexer-getter-only
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: get { return ref stored; } set { stored = value; }
Into: get { return ref stored; }
Csc: CS8147
*/
class Grid { int stored; public ref int this[int index] { get { return ref stored; } set { stored = value; } } }
class Program { static void Main() { } }
