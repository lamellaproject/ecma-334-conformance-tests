/*
Rules: E15-6-1-virtual-override-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public virtual override int Read()
Into: public override int Read()
Csc: CS0113
*/
class Parent { public virtual int Read() { return 1; } }
class Holder : Parent { public virtual override int Read() { return 17; } }
class Program { static void Main() { } }
