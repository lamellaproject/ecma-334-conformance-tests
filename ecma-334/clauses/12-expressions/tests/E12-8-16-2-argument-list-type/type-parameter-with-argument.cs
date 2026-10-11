/*
Rules: E12-8-16-2-argument-list-type
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new T(5)
Into: new T()
Csc: CS0417
*/
using System;
class Item { public Item() { } }
class Program
{
    static T Create<T>() where T : new() { return new T(5); }
    static void Main() { Console.WriteLine(Create<Item>() != null); }
}
