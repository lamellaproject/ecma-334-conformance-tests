/*
Rules: E15-7-1-property-method-modifier-combinations
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: new override int Item
Into: override int Item
*/
class Base { public virtual int Item => 9; }
class Box : Base { public new override int Item => 12; }
class Program { static void Main() { } }
