/*
Rules: E12-8-15-result-conversion
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: reject
Mutate: Leaf value = new Leaf();
Into: Root value = new Leaf();
*/
class Root { public static Root operator++(Root value) { return new Root(); } }
class Leaf : Root { }
class Program { static void Main() { Leaf value = new Leaf(); object before = value++; } }
