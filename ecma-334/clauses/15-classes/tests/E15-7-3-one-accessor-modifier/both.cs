/*
Rules: E15-7-3-one-accessor-modifier
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: internal set
Into: set
*/
class Box { int slot; public int Item { private get { return slot; } internal set { slot = value; } } }
class Program { static void Main() { } }
