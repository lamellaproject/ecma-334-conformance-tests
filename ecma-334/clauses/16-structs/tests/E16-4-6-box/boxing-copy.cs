/*
Rules: E16-4-6-box; E16-4-6-boxing-copy
Authority: ECMA-334 7th ed 16.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object boxed = original;
Into: object boxed = new Entry();
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry original = new Entry(); original.Value = 139;
        object boxed = original; original.Value = 29;
        Check(((Entry)boxed).Value == 139, "boxed-copy-is-independent");
        Check(original.Value == 29, "unboxed-source-update");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
