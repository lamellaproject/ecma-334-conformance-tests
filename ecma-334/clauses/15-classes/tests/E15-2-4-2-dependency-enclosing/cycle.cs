/*
Rules: E15-2-4-2-dependency-enclosing; E15-2-4-2-dependency-cycle
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Crate : Crate.Item
Into: class Crate : object
*/
class Crate : Crate.Item { public class Item { } }
class Program { static void Main() { } }
