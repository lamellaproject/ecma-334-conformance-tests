/*
Rules: E15-6-1-sealed-requires-override
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public sealed int Read()
Into: public override int Read()
Csc: CS0238
*/
class Parent { public virtual int Read() { return 1; } }
class Holder : Parent { public sealed int Read() { return 31; } }
class Program { static void Main() { } }
