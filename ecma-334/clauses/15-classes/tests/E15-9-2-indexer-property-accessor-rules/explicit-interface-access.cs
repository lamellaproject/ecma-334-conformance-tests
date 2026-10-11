/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: private get { return index; }
Into: get { return index; }
Csc: CS0106
*/
interface IGrid { int this[int index] { get; } }
class Grid : IGrid { int IGrid.this[int index] { private get { return index; } } }
class Program { static void Main() { } }
