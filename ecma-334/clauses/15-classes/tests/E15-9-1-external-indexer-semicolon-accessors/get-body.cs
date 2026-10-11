/*
Rules: E15-9-1-external-indexer-semicolon-accessors
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: get { return index; }
Into: get;
Csc: CS0179
*/
class Grid { public extern int this[int index] { get { return index; } set; } }
class Program { static void Main() { } }
