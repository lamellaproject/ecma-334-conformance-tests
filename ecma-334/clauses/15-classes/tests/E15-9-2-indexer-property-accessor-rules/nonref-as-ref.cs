/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: ref int alias = ref grid[1];
Into: int alias = grid[1];
Csc: CS0206
*/
class Grid { int stored; public int this[int index] { get { return stored; } } }
class Program { static void Main() { Grid grid = new Grid(); ref int alias = ref grid[1]; } }
