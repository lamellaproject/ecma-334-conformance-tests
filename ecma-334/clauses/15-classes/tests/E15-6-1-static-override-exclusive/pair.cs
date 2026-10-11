/*
Rules: E15-6-1-static-override-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public static override int Read()
Into: public override int Read()
Csc: CS0112
*/
class Parent { public virtual int Read() { return 1; } }
class Holder : Parent { public static override int Read() { return 13; } }
class Program { static void Main() { } }
