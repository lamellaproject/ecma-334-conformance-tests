/*
Rules: E15-2-4-2-base-lookup-object
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Leaf : Root<Leaf.Slot>
Into: class Leaf : Root<int>
*/
class Root<T> { public class Slot { } }
class Leaf : Root<Leaf.Slot> { }
class Program { static void Main() { } }
