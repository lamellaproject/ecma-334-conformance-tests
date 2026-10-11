/*
Rules: E23-2-unsafe-instance-constructor; E23-2-instance-constructor-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public unsafe Item()
Into: public Item()
*/
using System;
class Item { public int Value; public unsafe Item() { int value = 17; int* p = &value; Value = *p; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Item().Value == 17, "unsafe-instance-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
