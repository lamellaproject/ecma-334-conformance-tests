/*
Rules: E12-8-16-3-duplicate-member
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: reject
Mutate: Value = 3
Into: Other = 3
Csc: CS1912
*/
using System;
class Item { public int Value { get; set; } public int Other { get; set; } }
class Program
{
    static void Main() { var value = new Item { Value = 2, Value = 3 }; Console.WriteLine(value.Value); }
}
