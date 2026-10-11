/*
Rules: E15-2-2-2-concrete-implements-abstract
Authority: ECMA-334 7th ed 15.2.2.2
Version: 7.3
Expected: reject
Mutate: class Leaf : Root { }
Into: class Leaf : Root { public override int Read() { return 127; } }
*/
abstract class Root { public abstract int Read(); }
class Leaf : Root { }
class Program { static void Main() { } }
