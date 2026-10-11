/*
Rules: E15-3-10-1-reserved-hiding
Authority: ECMA-334 7th ed 15.3.10.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int get_Item(int index)
Into: public new int Read(int index)
*/
using System;
class Root { public int this[int index] { get { return 541; } } }
class Leaf : Root { public new int get_Item(int index) { return 547; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(leaf.get_Item(0) == 547, "new-method-hides-inherited-indexer-get-signature");
        Check(leaf[0] == 541, "base-indexer-still-accessible");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
