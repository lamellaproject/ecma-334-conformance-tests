/*
Rules: E15-7-1-property-expression-readonly
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: int Item => 4;
Into: int Item { get; set; }
Csc: CS0200
*/
class Box { public int Item => 4; }
class Program { static void Main() { Box box = new Box(); box.Item = 12; } }
