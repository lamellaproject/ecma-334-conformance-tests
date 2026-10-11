/*
Rules: E7-6-constructor-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Item(string first, int second)
Into: Item(int first, string second)
*/
using System;
class Item
{
    public int Tag;
    public Item(int value) { Tag = 37; }
    public Item(ref int value) { Tag = 41; }
    public Item(int first, string second) { Tag = 43; }
    public Item(string first, int second) { Tag = 47; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 5;
        Check(new Item(value).Tag == 37, "constructor-one-value-parameter");
        Check(new Item(ref value).Tag == 41, "constructor-one-ref-parameter");
        Check(new Item(1, "ash").Tag == 43, "constructor-parameter-types-int-string");
        Check(new Item("ash", 1).Tag == 47, "constructor-parameter-types-string-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
