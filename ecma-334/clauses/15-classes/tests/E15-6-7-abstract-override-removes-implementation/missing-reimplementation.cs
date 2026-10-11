/*
Rules: E15-6-7-abstract-override-removes-implementation; E15-6-7-concrete-derived-abstract-implementation
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: reject
Mutate: public abstract override int Read();
Into: public override int Read() { return 31; }
Csc: CS0534
*/
class Source { public virtual int Read() { return 31; } }
abstract class Boundary : Source { public abstract override int Read(); }
class Leaf : Boundary { }
class Program { static void Main() { } }
