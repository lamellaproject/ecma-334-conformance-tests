/*
Rules: E15-7-3-indexer-not-automatically-implemented
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: get; set;
Into: get { return index; } set { }
*/
class Box { public int this[int index] { get; set; } }
class Program { static void Main() { } }
