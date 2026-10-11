/*
Rules: E15-7-3-write-only-expression-limit
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: int seen = box.Item;
Into: int seen = box.Slot;
*/
class Box { public int Slot; public int Item { set { Slot = value; } } }
class Program { static void Main() { Box box = new Box(); int seen = box.Item; } }
