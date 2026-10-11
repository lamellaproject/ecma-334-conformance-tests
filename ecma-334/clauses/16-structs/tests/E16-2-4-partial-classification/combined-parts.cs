/*
Rules: E16-2-4-partial-classification; E16-2-4-partial-combination
Authority: ECMA-334 7th ed 16.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: partial struct Entry { public int Read()
Into: partial struct Other { public int Read()
*/
using System;
partial struct Entry { public int Value; }
partial struct Entry { public int Read() { return Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry item = new Entry(); item.Value = 83;
        Check(item.Read() == 83, "combined-part-members");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
