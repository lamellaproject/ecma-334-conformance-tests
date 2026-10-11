/*
Rules: E23-4-fixed-storage
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int* before = &value;
Into: int* before = &other;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 41, other = 7;
        int* before = &value;
        // Collection is needed here because the rule concerns storage under the garbage collector.
        GC.Collect();
        int* after = &value;
        Check(before == after, "fixed-address-after-collection");
        Check(*before == 41, "fixed-value-after-collection");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
