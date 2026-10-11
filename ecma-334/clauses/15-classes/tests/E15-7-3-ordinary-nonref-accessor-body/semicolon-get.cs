/*
Rules: E15-7-3-ordinary-nonref-accessor-body
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: get;
Into: get { return slot; }
*/
class Box { int slot; public int Item { get; set { slot = value; } } }
class Program { static void Main() { } }
