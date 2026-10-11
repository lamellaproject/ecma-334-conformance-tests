/*
Rules: E15-7-5-nonref-assignment-set-exists
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: box.Item = 29;
Into: box.Slot = 29;
*/
class Box { public int Slot; public int Item { get { return Slot; } } }
class Program { static void Main() { Box box = new Box(); box.Item = 29; } }
