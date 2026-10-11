/*
Rules: E12-8-14-indexer-form; E12-8-14-indexer-binding; E12-8-14-hidden-members
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: base[index: value]
Into: this[value]
*/
using System;
class Root { public int this[object index] { get { return 7; } } }
class Leaf : Root
{
    public int this[int index] { get { return 19; } }
    public int Read(int value) { return base[index: value]; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(leaf.Read(3) == 7, "base-indexer-uses-base-candidate-set");
        Check(leaf[3] == 19, "ordinary-indexer-selects-derived-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
