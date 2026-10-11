/*
Rules: E7-5-2-top-level-type-access
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: protected internal class Item
Into: internal class Item
*/
protected internal class Item { }
class Program { static void Main() { } }
