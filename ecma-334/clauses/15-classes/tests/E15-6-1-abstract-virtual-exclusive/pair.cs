/*
Rules: E15-6-1-abstract-virtual-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public abstract virtual int Read();
Into: public abstract int Read();
Csc: CS0503
*/
abstract class Holder { public abstract virtual int Read(); }
class Program { static void Main() { } }
