/*
Rules: E15-7-3-accessors-no-separate-declaration
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: public int Item { set { slot = value; } }
Into: 
*/
class Box { int slot; public int Item { get { return slot; } } public int Item { set { slot = value; } } }
class Program { static void Main() { } }
