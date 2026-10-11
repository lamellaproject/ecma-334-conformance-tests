/*
Rules: E15-7-6-override-property-modifier; E15-7-6-override-property-existing-member
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: override int Item
Into: new int Item
*/
using System;
class Base { int slot; public virtual int Item { get { return slot; } set { slot = value; } } }
class Derived : Base { int slot; public override int Item { get { return slot + 5; } set { slot = value + 2; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived box = new Derived(); Base alias = box;
        alias.Item = 13;
        Check(box.Item == 20 && alias.Item == 20, "one-specialized-member");
        box.Item = 28;
        Check(alias.Item == 35, "override-no-second-base-slot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
