/*
Rules: E12-8-14-abstract-member
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: reject
Mutate: return base[index];
Into: return index;
*/
abstract class Root { public abstract int this[int index] { get; } }
class Leaf : Root { public override int this[int index] { get { return base[index]; } } }
class Program { static void Main() { int value = new Leaf()[3]; } }
