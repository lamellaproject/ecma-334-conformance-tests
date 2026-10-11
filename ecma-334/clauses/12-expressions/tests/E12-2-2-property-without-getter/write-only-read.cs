/*
Rules: E12-2-2-property-without-getter
Authority: ECMA-334 7th ed 12.2.2
Version: 7.3
Expected: reject
Mutate: int value = box.Value;
Into: box.Value = 7;
*/
class Box { public int Value { set { } } }
class Program { static void Main() { Box box = new Box(); int value = box.Value; } }
