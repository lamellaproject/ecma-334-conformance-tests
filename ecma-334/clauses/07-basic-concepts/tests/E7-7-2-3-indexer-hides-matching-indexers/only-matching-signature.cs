/*
Rules: E7-7-2-3-indexer-hides-matching-indexers
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public new int this[int index] { get { return 107; } }
Into: public int Other(int index) { return 107; }
*/
using System;
class Root
{
    public int this[int index] { get { return 101; } }
    public int this[string index] { get { return 103; } }
}
class Branch : Root { public new int this[int index] { get { return 107; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch value = new Branch();
        Check(value[5] == 107, "matching-base-indexer-hidden");
        Check(value["ash"] == 103, "different-base-indexer-still-visible");
        Check(((Root)value)[5] == 101, "hidden-indexer-through-base-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
