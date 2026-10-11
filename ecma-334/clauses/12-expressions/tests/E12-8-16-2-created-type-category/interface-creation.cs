/*
Rules: E12-8-16-2-created-type-category; E12-8-16-2-invalid-creation
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new IItem()
Into: new Item()
Csc: CS0144
*/
using System;
interface IItem { }
class Item : IItem { }
class Program
{
    static void Main() { IItem item = new IItem(); Console.WriteLine(item != null); }
}
