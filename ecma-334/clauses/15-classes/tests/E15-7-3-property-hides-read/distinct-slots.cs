/*
Rules: E15-7-3-property-hides-read; E15-7-3-property-hides-write
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new int Item
Into: override int Item
*/
using System;
class Base { int slot = 7; public virtual int Item { get { return slot; } set { slot = value; } } }
class Derived : Base { int slot = 19; public new int Item { get { return slot; } set { slot = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived box = new Derived(); Base parent = box;
        Check(box.Item == 19 && parent.Item == 7, "hidden-read");
        box.Item = 29;
        Check(box.Item == 29 && parent.Item == 7, "hidden-write");
        parent.Item = 38;
        Check(box.Item == 29 && parent.Item == 38, "base-access-separate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
