/*
Rules: E12-8-14-abstract-member
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: reject
Mutate: return base.Read();
Into: return 3;
*/
abstract class Root { public abstract int Read(); }
class Leaf : Root { public override int Read() { return base.Read(); } }
class Program { static void Main() { new Leaf().Read(); } }
