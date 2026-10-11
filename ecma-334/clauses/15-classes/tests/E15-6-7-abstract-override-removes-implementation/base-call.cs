/*
Rules: E15-6-7-abstract-override-removes-implementation; E15-6-7-abstract-no-base-access
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: reject
Mutate: public abstract override int Read();
Into: public override int Read() { return 73; }
Csc: CS0205
*/
class Source { public virtual int Read() { return 73; } }
abstract class Boundary : Source { public abstract override int Read(); }
class Leaf : Boundary { public override int Read() { return base.Read(); } }
class Program { static void Main() { } }
