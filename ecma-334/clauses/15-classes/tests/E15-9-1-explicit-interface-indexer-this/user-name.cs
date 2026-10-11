/*
Rules: E15-9-1-explicit-interface-indexer-this; E15-9-1-indexer-no-user-name
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: int IGrid.Entry[int index]
Into: int IGrid.this[int index]
*/
interface IGrid { int this[int index] { get; } }
class Grid : IGrid { int IGrid.Entry[int index] { get { return index; } } }
class Program { static void Main() { } }
