/*
Rules: E15-7-3-write-only-classification
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: set { Calls++; Slot = value; }
Into: set { Calls++; Slot = value + 1; }
*/
using System;
class Box { public int Slot, Calls; public int Item { set { Calls++; Slot = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); box.Item = 31;
        Check(box.Slot == 31 && box.Calls == 1, "write-only-assignment");
        box.Item = 42;
        Check(box.Slot == 42 && box.Calls == 2, "write-only-reassignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
