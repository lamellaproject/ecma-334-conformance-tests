/*
Rules: E12-8-16-2-dynamic-limited-check
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new Item(argument, argument)
Into: new Item(argument)
Csc: CS1729
*/
using System;
public class Item { public Item(int number) { } }
class Program
{
    static void Main() { dynamic argument = 6; var value = new Item(argument, argument); Console.WriteLine(value != null); }
}
