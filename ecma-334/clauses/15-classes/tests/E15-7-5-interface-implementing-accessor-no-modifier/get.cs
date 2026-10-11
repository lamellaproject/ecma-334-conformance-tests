/*
Rules: E15-7-5-interface-implementing-accessor-no-modifier
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: internal get
Into: get
*/
interface IBox { int Item { get; } }
class Box : IBox { int slot; public int Item { internal get { return slot; } set { slot = value; } } }
class Program { static void Main() { } }
