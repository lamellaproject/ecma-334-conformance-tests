/*
Rules: E15-7-5-nonref-compound-set-exists
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: int Item { get { return slot; } }
Into: int Item { get { return slot; } set { slot = value; } }
*/
class Box { int slot; public int Item { get { return slot; } } }
class Program { static void Main() { Box box = new Box(); box.Item += 7; } }
