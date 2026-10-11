/*
Rules: E15-7-1-ordinary-property-name
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: int Box.Item
Into: int Item
*/
class Box { int Box.Item { get { return 7; } } }
class Program { static void Main() { } }
