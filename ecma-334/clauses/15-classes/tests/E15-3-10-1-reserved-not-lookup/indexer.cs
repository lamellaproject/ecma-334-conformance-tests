/*
Rules: E15-3-10-1-reserved-not-lookup
Authority: ECMA-334 7th ed 15.3.10.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public int get_Item = 487;
Into: public int Other = 487;
*/
using System;
class Root { public int get_Item = 487; public int set_Item = 491; }
class Leaf : Root { public int this[int index] { get { return 499; } set { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(leaf.get_Item == 487, "reserved-indexer-get-name-does-not-hide-field-lookup");
        Check(leaf.set_Item == 491, "reserved-indexer-set-name-does-not-hide-field-lookup");
        Check(leaf[0] == 499, "declared-indexer-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
