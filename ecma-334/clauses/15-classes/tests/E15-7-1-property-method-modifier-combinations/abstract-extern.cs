/*
Rules: E15-7-1-property-method-modifier-combinations
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: abstract extern int Item
Into: abstract int Item
*/
abstract class Box { public abstract extern int Item { get; } }
class Program { static void Main() { } }
