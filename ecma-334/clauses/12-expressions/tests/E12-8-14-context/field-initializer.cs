/*
Rules: E12-8-14-context
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: reject
Mutate: base.Value
Into: new Root().Value
*/
class Root { public int Value = 3; }
class Leaf : Root { int saved = base.Value; }
class Program { static void Main() { new Leaf(); } }
