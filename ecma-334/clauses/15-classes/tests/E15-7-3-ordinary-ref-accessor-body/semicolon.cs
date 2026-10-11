/*
Rules: E15-7-3-ordinary-ref-accessor-body
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: get;
Into: get { return ref slot; }
*/
class Box { int slot; public ref int Item { get; } }
class Program { static void Main() { } }
