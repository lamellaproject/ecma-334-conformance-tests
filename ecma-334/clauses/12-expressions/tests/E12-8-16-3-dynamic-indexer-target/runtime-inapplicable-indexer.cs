/*
Rules: E12-8-16-3-dynamic-indexer-target
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: dynamic key = "bad";
Into: dynamic key = 2;
*/
using System;
public class Item
{
    public static int Constructors, Setters;
    public Item() { Constructors++; }
    public int this[int key] { set { Setters++; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic key = "bad";
        bool error = false;
        try { var value = new Item { [key] = 7 }; }
        catch (Exception) { error = true; }
        Check(error, "runtime-index-initializer-no-applicable-indexer");
        Check(Item.Constructors == 1, "runtime-index-binding-after-constructor");
        Check(Item.Setters == 0, "invalid-indexer-setter-not-entered");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
