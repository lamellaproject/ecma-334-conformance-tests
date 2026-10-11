/*
Rules: E15-7-6-abstract-no-private-accessor
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: private set;
Into: set;
*/
abstract class Box { public abstract int Item { get; private set; } }
class Program { static void Main() { } }
