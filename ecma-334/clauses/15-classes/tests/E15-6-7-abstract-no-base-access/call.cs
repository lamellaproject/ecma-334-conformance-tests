/*
Rules: E15-6-7-abstract-no-base-access
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: reject
Mutate: public abstract int Read();
Into: public virtual int Read() { return 41; }
Csc: CS0205
*/
abstract class Source { public abstract int Read(); }
class Leaf : Source { public override int Read() { return base.Read() + 1; } }
class Program { static void Main() { } }
