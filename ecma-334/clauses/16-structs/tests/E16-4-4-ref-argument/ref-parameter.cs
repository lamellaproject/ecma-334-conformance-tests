/*
Rules: E16-4-4-ref-argument
Authority: ECMA-334 7th ed 16.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ref Entry item
Into: Entry item
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Store(ref Entry item) { item.Value += 7; }
    static void Main()
    {
        Entry item = new Entry(); item.Value = 17; Store(ref item);
        Check(item.Value == 24, "ref-struct-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
