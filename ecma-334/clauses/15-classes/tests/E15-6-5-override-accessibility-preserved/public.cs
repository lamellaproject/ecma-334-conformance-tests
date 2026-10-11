/*
Rules: E15-6-5-override-accessibility-preserved
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: protected override int Read()
Into: public override int Read()
Csc: CS0507
*/
class Root { public virtual int Read() { return 157; } }
class Leaf : Root { protected override int Read() { return 163; } }
class Program { static void Main() { } }
