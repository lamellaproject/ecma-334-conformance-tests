/*
Rules: E15-7-3-explicit-interface-no-accessor-modifier
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: private set
Into: set
*/
interface IBox { int Item { get; set; } }
class Box : IBox { int slot; int IBox.Item { get { return slot; } private set { slot = value; } } }
class Program { static void Main() { } }
