/*
Rules: E15-7-6-abstract-property-abstract-class
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: class Box
Into: abstract class Box
*/
class Box { public abstract int Item { get; } }
class Program { static void Main() { } }
