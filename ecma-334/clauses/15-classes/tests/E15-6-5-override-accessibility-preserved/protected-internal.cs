/*
Rules: E15-6-5-override-accessibility-preserved
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: protected override int Read()
Into: protected internal override int Read()
Csc: CS0507
*/
class Root { protected internal virtual int Read() { return 191; } }
class Leaf : Root { protected override int Read() { return 193; } }
class Program { static void Main() { } }
