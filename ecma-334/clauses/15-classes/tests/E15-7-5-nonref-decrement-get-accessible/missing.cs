/*
Rules: E15-7-5-nonref-decrement-get-accessible
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: int Item { set { slot = value; } }
Into: int Item { get { return slot; } set { slot = value; } }
*/
class Box { int slot; public int Item { set { slot = value; } } }
class Program { static void Main() { Box box = new Box(); box.Item--; } }
