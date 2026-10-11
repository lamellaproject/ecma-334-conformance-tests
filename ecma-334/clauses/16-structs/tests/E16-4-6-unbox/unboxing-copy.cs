/*
Rules: E16-4-6-unbox; E16-4-6-unboxing-copy
Authority: ECMA-334 7th ed 16.4.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Entry result = (Entry)boxed;
Into: Entry result = new Entry();
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry original = new Entry(); original.Value = 149;
        object boxed = original;
        Entry result = (Entry)boxed;
        Check(result.Value == 149, "unboxed-value");
        result.Value = 31;
        Check(result.Value == 31, "unboxed-destination-update");
        Check(((Entry)boxed).Value == 149, "box-independent-of-unboxed-copy");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
