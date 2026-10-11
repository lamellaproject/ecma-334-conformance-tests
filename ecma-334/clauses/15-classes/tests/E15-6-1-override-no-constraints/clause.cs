/*
Rules: E15-6-1-override-no-constraints
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public override T Create<T>() where T : Item, new()
Into: public override T Create<T>()
Csc: CS0460
*/
class Item { }
abstract class Parent { public abstract T Create<T>() where T : Item, new(); }
class Factory : Parent { public override T Create<T>() where T : Item, new() { return new T(); } }
class Program { static void Main() { } }
