/*
Rules: E15-2-5-one-class-constraint
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : Root, Leaf
Into: where T : Leaf
*/
class Root { }
class Leaf : Root { }
class Box<T> where T : Root, Leaf { }
class Program { static void Main() { } }
