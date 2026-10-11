/*
Rules: E12-8-21-span-indexer-reference; E12-8-21-span-memory-view
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: ref int item = ref values[1];
Into: ref int item = ref values[0];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Span<int> values = stackalloc int[2];
        values[0] = 4;
        values[1] = 8;
        ref int item = ref values[1];
        item = 19;
        Check(values[0] == 4, "alias-leaves-other-item");
        Check(values[1] == 19, "alias-updates-allocated-item");
        values[1] = 23;
        Check(item == 23, "item-write-visible-through-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
