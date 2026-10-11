/*
Rules: E15-2-4-2-sealed-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: sealed class Root
Into: class Root
*/
sealed class Root { }
class Leaf : Root { }
class Program { static void Main() { } }
