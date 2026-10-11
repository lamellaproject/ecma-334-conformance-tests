/*
Rules: E15-7-1-property-method-modifier-combinations
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: public public int Item
Into: public int Item
*/
class Box { public public int Item => 4; }
class Program { static void Main() { } }
