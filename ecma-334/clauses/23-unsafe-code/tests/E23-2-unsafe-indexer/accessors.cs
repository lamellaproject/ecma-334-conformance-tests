/*
Rules: E23-2-unsafe-indexer; E23-2-indexer-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public unsafe int this
Into: public int this
*/
using System;
class Item { public int Last; public unsafe int this[int key] { get { int* p = &key; return *p + 2; } set { int* p = &value; Last = *p; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item item = new Item();
        Check(item[5] == 7, "unsafe-indexer-get-context");
        item[0] = 9;
        Check(item.Last == 9, "unsafe-indexer-set-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
