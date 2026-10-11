/*
Rules: E15-7-3-abstract-ref-accessor-semicolon
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: get { return ref slot; }
Into: get;
*/
abstract class Box { int slot; public abstract ref int Item { get { return ref slot; } } }
class Program { static void Main() { } }
