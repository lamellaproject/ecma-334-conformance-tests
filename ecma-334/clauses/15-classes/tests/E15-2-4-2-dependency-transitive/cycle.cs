/*
Rules: E15-2-4-2-dependency-transitive; E15-2-4-2-dependency-cycle; E15-2-4-2-dependency-base; E15-2-4-2-dependency-enclosing
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Link : Crate.Item
Into: class Link : object
*/
class Crate : Link { public class Item { } }
class Link : Crate.Item { }
class Program { static void Main() { } }
