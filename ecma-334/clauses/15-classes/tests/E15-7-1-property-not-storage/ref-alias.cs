/*
Rules: E15-7-1-property-not-storage
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: ref box.Amount
Into: ref box.Slot
Csc: CS0206
*/
class Box { public int Slot; public int Amount { get { return Slot; } set { Slot = value; } } }
class Program { static void Main() { Box box = new Box(); ref int alias = ref box.Amount; alias = 14; } }
