/*
Rules: E15-6-5-override-no-explicit-constraints
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public override T Make<T>() where T : new()
Into: public override T Make<T>()
Csc: CS0460
*/
class Root { public virtual T Make<T>() where T : new() { return new T(); } }
class Leaf : Root { public override T Make<T>() where T : new() { return new T(); } }
class Program { static void Main() { } }
