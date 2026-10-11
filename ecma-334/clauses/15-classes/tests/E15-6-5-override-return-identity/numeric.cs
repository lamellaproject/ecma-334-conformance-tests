/*
Rules: E15-6-5-override-return-identity
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public override int Read()
Into: public override long Read()
Csc: CS0508
*/
class Root { public virtual long Read() { return 149; } }
class Leaf : Root { public override int Read() { return 151; } }
class Program { static void Main() { } }
