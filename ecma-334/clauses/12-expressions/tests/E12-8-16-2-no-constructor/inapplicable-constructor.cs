/*
Rules: E12-8-16-2-no-constructor; E12-8-16-2-constructor-applicability
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new Item("bad")
Into: new Item(5)
Csc: CS1503
*/
using System;
class Item { public Item(int number) { } }
class Program
{
    static void Main() { var value = new Item("bad"); Console.WriteLine(value != null); }
}
