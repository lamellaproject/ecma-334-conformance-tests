/*
Rules: E15-6-5-override-base-not-sealed
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public sealed override int Read()
Into: public override int Read()
Csc: CS0239
*/
class Root { public virtual int Read() { return 131; } }
class Branch : Root { public sealed override int Read() { return 137; } }
class Leaf : Branch { public override int Read() { return 139; } }
class Program { static void Main() { } }
