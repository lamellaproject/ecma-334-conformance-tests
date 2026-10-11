/*
Rules: E15-6-5-override-accessibility-preserved
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public override int Read()
Into: protected override int Read()
Csc: CS0507
*/
class Root { protected virtual int Read() { return 167; } }
class Leaf : Root { public override int Read() { return 173; } }
class Program { static void Main() { } }
