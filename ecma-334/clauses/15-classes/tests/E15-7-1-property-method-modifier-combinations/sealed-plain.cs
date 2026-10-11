/*
Rules: E15-7-1-property-method-modifier-combinations
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: sealed int Item
Into: int Item
*/
class Box { public sealed int Item => 7; }
class Program { static void Main() { } }
