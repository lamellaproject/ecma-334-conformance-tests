/*
Rules: E22-6-indexer-default-name; E22-6-indexer-indexed-property
Authority: ECMA-334 7th ed 22.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public int this[int key]
Into: [System.Runtime.CompilerServices.IndexerName("Entry")] public int this[int key]
*/
using System;
class Item { public int this[int key] { get { return key + 2; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var property = typeof(Item).GetProperty("Item");
        Check(property != null, "default-indexed-property-name");
        Check(property != null && property.GetIndexParameters().Length == 1, "indexed-property-parameter");
        Check(new Item()[5] == 7, "indexer-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
