/*
Rules: E15-6-5-override-base-required
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public override int Read()
Into: public int Read()
Csc: CS0115
*/
class Root { }
class Leaf : Root { public override int Read() { return 73; } }
class Program { static void Main() { } }
