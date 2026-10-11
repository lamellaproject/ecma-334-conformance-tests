/*
Rules: E12-8-21-span-indexer-bounds
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int index = requested;
Into: int index = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Probe(int requested)
    {
        Span<int> values = stackalloc int[2] { 7, 11 };
        bool failed = false;
        try { int index = requested; values[index] = 99; }
        catch (Exception) { failed = true; }
        Check(failed, "out-of-range-index-fails");
        Check(values[0] == 7 && values[1] == 11, "failed-access-leaves-items");
    }
    static void Main()
    {
        Probe(-1);
        Probe(2);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
