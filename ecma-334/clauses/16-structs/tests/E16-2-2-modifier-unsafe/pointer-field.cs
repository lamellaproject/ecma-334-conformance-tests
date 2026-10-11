/*
Rules: E16-2-2-modifier-unsafe
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe struct Entry
Into: struct Entry
*/
using System;
unsafe struct Entry { public int* Address; }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 62; Entry item = new Entry(); item.Address = &value;
        Check(*item.Address == 62, "unsafe-struct-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
