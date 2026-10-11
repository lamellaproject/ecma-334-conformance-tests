/*
Rules: E12-8-16-3-created-object-reference
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: reject
Mutate: Link = value
Into: Link = null
Csc: CS0165
*/
using System;
class Item { public Item Link; }
class Program
{
    static void Main() { Item value = new Item { Link = value }; Console.WriteLine(value != null); }
}
