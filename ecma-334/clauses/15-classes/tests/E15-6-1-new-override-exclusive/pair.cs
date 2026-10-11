/*
Rules: E15-6-1-new-override-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public new override int Read()
Into: public override int Read()
Csc: CS0113
*/
class Parent { public virtual int Read() { return 1; } }
class Holder : Parent { public new override int Read() { return 19; } }
class Program { static void Main() { } }
