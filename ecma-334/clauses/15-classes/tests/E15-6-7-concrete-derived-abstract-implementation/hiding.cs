/*
Rules: E15-6-7-concrete-derived-abstract-implementation
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: reject
Mutate: public new int Read()
Into: public override int Read()
Csc: CS0534
*/
abstract class Source { public abstract int Read(); }
class Leaf : Source { public new int Read() { return 47; } }
class Program { static void Main() { } }
