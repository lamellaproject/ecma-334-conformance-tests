/*
Rules: E12-8-14-context
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: reject
Mutate: base(base.Value)
Into: base(3)
*/
class Root { public int Value; public Root(int value) { Value = value; } }
class Leaf : Root { public Leaf() : base(base.Value) { } }
class Program { static void Main() { new Leaf(); } }
