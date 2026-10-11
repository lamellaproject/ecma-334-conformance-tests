/*
Rules: E12-8-16-3-indexer-target
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: reject
Mutate: ["bad"] = 7
Into: [2] = 7
Csc: CS1503
*/
using System;
class Item { public int this[int key] { set { } } }
class Program
{
    static void Main() { var value = new Item { ["bad"] = 7 }; Console.WriteLine(value != null); }
}
