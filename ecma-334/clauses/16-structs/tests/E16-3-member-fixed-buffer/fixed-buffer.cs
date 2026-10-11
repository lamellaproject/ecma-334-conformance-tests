/*
Rules: E16-3-member-fixed-buffer
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public fixed int Items[3];
Into: public int Items;
*/
using System;
unsafe struct Entry { public fixed int Items[3]; }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry item = default(Entry); item.Items[0] = 113; item.Items[2] = 29;
        Check(item.Items[0] == 113, "fixed-first-element");
        Check(item.Items[2] == 29, "fixed-last-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
