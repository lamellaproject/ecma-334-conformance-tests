/*
Rules: E15-6-4-multiple-virtual-signatures; E15-6-4-virtual-same-signature-hiding
Authority: ECMA-334 7th ed 15.6.4
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: public new virtual int Read()
Into: public override int Read()
*/
using System;
class Root { public virtual int Read() { return 31; } }
class Branch : Root { public new virtual int Read() { return 37; } }
class Leaf : Branch { public override int Read() { return 41; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(((Root)leaf).Read() == 31, "hidden-original-virtual-slot-remains-independent");
        Check(((Branch)leaf).Read() == 41, "new-virtual-slot-dispatches-its-own-override");
        Check(leaf.Read() == 41, "most-derived-visible-method-hides-original-signature");
        Branch branch = new Branch();
        Check(((Root)branch).Read() == 31, "base-view-selects-original-introducing-slot");
        Check(branch.Read() == 37, "derived-view-selects-new-introducing-slot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
