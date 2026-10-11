/*
Rules: E16-4-4-value-argument-copy
Authority: ECMA-334 7th ed 16.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: struct Entry
Into: class Entry
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Touch(Entry item) { item.Value = 71; return item.Value; }
    static void Main()
    {
        Entry original = new Entry(); original.Value = 25;
        Check(Touch(original) == 71, "parameter-update-executed");
        Check(original.Value == 25, "value-parameter-copy");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
