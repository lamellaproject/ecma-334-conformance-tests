/*
Rules: E15-2-4-2-one-direct-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Leaf : Root, Other
Into: class Leaf : Root
*/
class Root { }
class Other { }
class Leaf : Root, Other { }
class Program { static void Main() { } }
