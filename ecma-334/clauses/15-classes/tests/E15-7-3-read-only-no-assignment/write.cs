/*
Rules: E15-7-3-read-only-no-assignment
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: box.Item = 4;
Into: box.Slot = 4;
*/
class Box { public int Slot; public int Item { get { return Slot; } } }
class Program { static void Main() { Box box = new Box(); box.Item = 4; } }
