/*
Rules: E16-4-4-out-argument
Authority: ECMA-334 7th ed 16.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out Entry item
Into: ref Entry item
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Store(out Entry item) { item = new Entry(); item.Value = 131; }
    static void Main()
    {
        Entry item; Store(out item);
        Check(item.Value == 131, "out-struct-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
