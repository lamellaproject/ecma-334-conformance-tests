/*
Rules: E15-6-1-explicit-implementation-no-constraints
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: T IFactory.Create<T>() where T : Item, new()
Into: T IFactory.Create<T>()
Csc: CS0460
*/
class Item { }
interface IFactory { T Create<T>() where T : Item, new(); }
class Factory : IFactory { T IFactory.Create<T>() where T : Item, new() { return new T(); } }
class Program { static void Main() { } }
