/*
Rules: E22-6-indexer-custom-name
Authority: ECMA-334 7th ed 22.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.IndexerName("Entry")]
Into: [System.Runtime.CompilerServices.IndexerName("Other")]
*/
using System;
class Item { [System.Runtime.CompilerServices.IndexerName("Entry")] public int this[int key] { get { return key; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(typeof(Item).GetProperty("Entry") != null, "custom-indexed-property-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
