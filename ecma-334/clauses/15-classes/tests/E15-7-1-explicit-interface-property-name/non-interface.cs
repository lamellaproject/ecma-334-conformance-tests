/*
Rules: E15-7-1-explicit-interface-property-name
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: int Other.Item
Into: int IBox.Item
*/
interface IBox { int Item { get; } }
class Other { }
class Box : IBox { int Other.Item { get { return 11; } } }
class Program { static void Main() { } }
