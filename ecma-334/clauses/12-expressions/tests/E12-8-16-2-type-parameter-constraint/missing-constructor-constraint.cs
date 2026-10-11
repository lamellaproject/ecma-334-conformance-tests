/*
Rules: E12-8-16-2-type-parameter-constraint
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: static T Create<T>()
Into: static T Create<T>() where T : new()
Csc: CS0304
*/
using System;
class Item { public Item() { } }
class Program
{
    static T Create<T>() { return new T(); }
    static void Main() { Console.WriteLine(Create<Item>() != null); }
}
