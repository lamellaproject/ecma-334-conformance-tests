/*
Rules: E15-7-3-accessors-not-members
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: box.get_Item()
Into: box.Item
*/
class Box { public int Item { get { return 16; } } }
class Program { static void Main() { Box box = new Box(); int seen = box.get_Item(); } }
