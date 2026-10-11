/*
Rules: E15-7-1-property-method-modifier-combinations
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: static virtual int Item
Into: static int Item
*/
class Box { public static virtual int Item => 7; }
class Program { static void Main() { } }
