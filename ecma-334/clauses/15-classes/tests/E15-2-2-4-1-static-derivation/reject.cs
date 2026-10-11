/*
Rules: E15-2-2-4-1-static-derivation
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: static class Root
Into: class Root
*/
static class Root { }
class Leaf : Root { }
class Program { static void Main() { } }
