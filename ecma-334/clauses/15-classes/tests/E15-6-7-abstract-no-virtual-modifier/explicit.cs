/*
Rules: E15-6-7-abstract-no-virtual-modifier
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: reject
Mutate: public abstract virtual int Read();
Into: public abstract int Read();
Csc: CS0503
*/
abstract class Source { public abstract virtual int Read(); }
class Program { static void Main() { } }
