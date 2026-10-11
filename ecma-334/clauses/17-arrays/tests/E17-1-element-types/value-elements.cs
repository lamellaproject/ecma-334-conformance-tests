/*
Rules: E17-1-element-types; E17-2-1-nonarray-type
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: entries[0].Value = 43
Into: entries[0].Value = 0
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry[] entries = new Entry[2];
        entries[0].Value = 43;
        Check(entries[0].Value == 43, "struct-element");
        Check(entries[1].Value == 0, "other-element-independent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
