/*
Rules: E15-6-5-override-accessibility-preserved
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: protected override int Read()
Into: private protected override int Read()
Csc: CS0507
*/
class Root { private protected virtual int Read() { return 197; } }
class Leaf : Root { protected override int Read() { return 199; } }
class Program { static void Main() { } }
