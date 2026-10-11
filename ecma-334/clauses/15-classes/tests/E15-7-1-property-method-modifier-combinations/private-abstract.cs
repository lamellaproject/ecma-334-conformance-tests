/*
Rules: E15-7-1-property-method-modifier-combinations
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: private abstract int Item
Into: protected abstract int Item
*/
abstract class Box { private abstract int Item { get; } }
class Program { static void Main() { } }
