/*
Rules: E15-7-3-extern-ref-accessor-semicolon
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: get { return ref slot; }
Into: get;
*/
class Box { int slot; public extern ref int Item { get { return ref slot; } } }
class Program { static void Main() { } }
