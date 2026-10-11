/*
Rules: E16-2-3-ref-like-fields
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ref struct Entry
Into: struct Entry
*/
using System;
ref struct Entry { public Span<int> Values; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry item = new Entry(); item.Values = new int[2]; item.Values[1] = 81;
        Check(item.Values[1] == 81, "ref-like-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
