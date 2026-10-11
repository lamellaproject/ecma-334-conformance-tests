/*
Rules: E15-7-1-ref-property-only-readable
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: set { slot = value; }
Into: 
*/
class Box { int slot; public ref int Item { get { return ref slot; } set { slot = value; } } }
class Program { static void Main() { } }
