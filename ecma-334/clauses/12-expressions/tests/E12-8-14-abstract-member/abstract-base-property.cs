/*
Rules: E12-8-14-abstract-member
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: reject
Mutate: return base.Value;
Into: return 3;
*/
abstract class Root { public abstract int Value { get; } }
class Leaf : Root { public override int Value { get { return base.Value; } } }
class Program { static void Main() { int value = new Leaf().Value; } }
