/*
Rules: E15-6-5-override-base-required
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public override int Read(long value)
Into: public override int Read(int value)
Csc: CS0115
*/
class Root { public virtual int Read(int value) { return 79; } }
class Leaf : Root { public override int Read(long value) { return 83; } }
class Program { static void Main() { } }
