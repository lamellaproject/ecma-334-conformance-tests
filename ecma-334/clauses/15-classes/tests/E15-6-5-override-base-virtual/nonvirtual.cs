/*
Rules: E15-6-5-override-base-virtual; E15-6-5-overridden-base-search-order
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public new int Read()
Into: public new virtual int Read()
Csc: CS0506
*/
class Root { public virtual int Read() { return 103; } }
class Branch : Root { public new int Read() { return 107; } }
class Leaf : Branch { public override int Read() { return 109; } }
class Program { static void Main() { } }
