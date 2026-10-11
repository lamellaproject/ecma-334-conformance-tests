/*
Rules: E23-2-unsafe-struct; E23-2-struct-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe struct Item
Into: struct Item
*/
using System;
unsafe struct Item { public int Read() { int value = 7; int* p = &value; return *p; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Item().Read() == 7, "struct-body-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
