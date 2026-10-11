/*
Rules: E15-7-1-property-initializer-auto-only
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: = 17;
Into: 
Csc: CS8050
*/
class Box { int slot; public int Item { get { return slot; } set { slot = value; } } = 17; }
class Program { static void Main() { } }
