/*
Rules: E23-2-unsafe-static-constructor; E23-2-static-constructor-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static unsafe Item()
Into: static Item()
*/
using System;
class Item { public static int Value; static unsafe Item() { int value = 19; int* p = &value; Value = *p; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Item.Value == 19, "unsafe-static-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
