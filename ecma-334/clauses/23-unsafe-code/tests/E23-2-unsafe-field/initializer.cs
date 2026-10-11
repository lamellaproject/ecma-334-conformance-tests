/*
Rules: E23-2-unsafe-field; E23-2-field-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static unsafe int* Pointer
Into: static int* Pointer
*/
using System;
class Item { public static unsafe int* Pointer = (int*)0x1000; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            Check((ulong)Item.Pointer == 0x1000, "unsafe-field-type-and-initializer");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
