/*
Rules: E15-6-5-override-return-identity
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public override Small Read()
Into: public override Large Read()
*/
class Large { }
class Small : Large { }
class Root { public virtual Large Read() { return new Large(); } }
class Leaf : Root { public override Small Read() { return new Small(); } }
class Program { static void Main() { } }
