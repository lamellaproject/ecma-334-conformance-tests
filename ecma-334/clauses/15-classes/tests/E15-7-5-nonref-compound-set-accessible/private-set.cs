/*
Rules: E15-7-5-nonref-compound-set-accessible
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: private set
Into: set
*/
class Box { int slot; public int Item { get { return slot; } private set { slot = value; } } }
class Program { static void Main() { Box box = new Box(); box.Item += 6; } }
