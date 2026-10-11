/*
Rules: E15-9-2-indexer-no-constant-parameter-name
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Mutate: const int index = 4;
Into: const int other = 4;
Csc: CS0136
*/
class Grid { public int this[int index] { get { const int index = 4; return 5; } } }
class Program { static void Main() { } }
