/*
Rules: E7-8-3-member-name-uniqueness; E7-8-3-fully-qualified-name-uniqueness
Authority: ECMA-334 7th ed 7.8.3
Version: 7.3
Expected: reject
Mutate: public struct Item { }
Into: public struct Other { }
Csc: CS0102
*/
class Crate { public class Item { } public struct Item { } }
class Program { static void Main() { } }
