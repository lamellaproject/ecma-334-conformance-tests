/*
Rules: E15-7-3-private-no-accessor-modifier
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: private set
Into: set
*/
class Box { int slot; private int Item { get { return slot; } private set { slot = value; } } }
class Program { static void Main() { } }
