/*
Rules: E12-8-16-2-class-constructor-this; E12-8-16-2-class-constructor-call
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new Item(23, ref changes)
Into: new Item(31, ref changes)
*/
using System;
class Item
{
    public static Item Seen;
    public int Number;
    public Item(int number, ref int changes) { Seen = this; Number = number; changes++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int changes = 4;
        Item value = new Item(23, ref changes);
        Check(object.ReferenceEquals(value, Item.Seen), "constructor-this-is-new-instance");
        Check(value.Number == 23, "constructor-argument-value");
        Check(changes == 5, "constructor-reference-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
