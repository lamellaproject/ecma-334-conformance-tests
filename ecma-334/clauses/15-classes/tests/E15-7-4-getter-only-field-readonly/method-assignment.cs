/*
Rules: E15-7-4-getter-only-field-readonly
Authority: ECMA-334 7th ed 15.7.4
Version: 7.3
Expected: reject
Mutate: int Item { get; }
Into: int Item { get; set; }
*/
class Box { public int Item { get; } public void Change() { Item = 12; } }
class Program { static void Main() { } }
