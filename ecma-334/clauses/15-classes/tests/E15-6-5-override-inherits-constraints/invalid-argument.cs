/*
Rules: E15-6-5-override-inherits-constraints; E15-6-5-override-constraint-substitution
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: new Leaf().Echo<long>(229)
Into: new Leaf().Echo<int>(229)
Csc: CS0315
*/
class Root<U> { public virtual T Echo<T>(T value) where T : U { return value; } }
class Leaf : Root<int> { public override T Echo<T>(T value) { return value; } }
class Program { static void Main() { new Leaf().Echo<long>(229); } }
