/*
Rules: E15-6-1-abstract-sealed-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public abstract sealed override int Read();
Into: public abstract override int Read();
*/
class Parent { public virtual int Read() { return 1; } }
abstract class Holder : Parent { public abstract sealed override int Read(); }
class Program { static void Main() { } }
