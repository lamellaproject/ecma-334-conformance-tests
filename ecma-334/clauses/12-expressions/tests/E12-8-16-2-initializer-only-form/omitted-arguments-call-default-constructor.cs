/*
Rules: E12-8-16-2-initializer-only-form; E12-8-16-2-omitted-arguments-equivalence; E12-8-16-2-object-initializer-form
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new Item { Number = 7 }
Into: new Item(5) { Number = 7 }
*/
using System;
class Item
{
    public static int DefaultCalls;
    public int Number, Selected;
    public Item() { DefaultCalls++; Selected = 1; }
    public Item(int number) { Selected = 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item implicitArguments = new Item { Number = 7 };
        Item explicitArguments = new Item() { Number = 7 };
        Check(implicitArguments.Selected == 1 && explicitArguments.Selected == 1, "omitted-arguments-select-default-constructor");
        Check(Item.DefaultCalls == 2, "both-empty-argument-constructors-run");
        Check(implicitArguments.Number == 7 && explicitArguments.Number == 7, "initializer-after-either-form");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
