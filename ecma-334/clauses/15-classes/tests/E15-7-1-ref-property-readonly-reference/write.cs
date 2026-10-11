/*
Rules: E15-7-1-ref-property-readonly-reference
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: box.View = 8;
Into: box.Slot = 8;
*/
class Box { public int Slot; public ref readonly int View => ref Slot; }
class Program { static void Main() { Box box = new Box(); box.View = 8; } }
