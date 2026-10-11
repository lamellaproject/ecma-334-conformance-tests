/*
Rules: E15-7-6-abstract-accessor-semicolon
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: get { return 33; }
Into: get;
*/
abstract class Box { public abstract int Item { get { return 33; } } }
class Program { static void Main() { } }
