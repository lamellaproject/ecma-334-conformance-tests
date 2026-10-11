/*
Rules: E23-2-unsafe-property; E23-2-property-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public unsafe int Value
Into: public int Value
*/
using System;
class Item { public unsafe int Value { get { int value = 13; int* p = &value; return *p; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Item().Value == 13, "unsafe-property-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
