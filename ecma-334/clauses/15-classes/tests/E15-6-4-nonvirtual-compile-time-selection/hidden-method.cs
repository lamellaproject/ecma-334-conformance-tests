/*
Rules: E15-6-4-nonvirtual-compile-time-selection; E15-6-4-nonvirtual-method-classification; E15-6-4-nonvirtual-invariant-implementation; E15-6-4-invocation-nonvirtual-target
Authority: ECMA-334 7th ed 15.6.4
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: asRoot.Read()
Into: ((Branch)asRoot).Read()
*/
using System;
class Root { public int Read() { return 5; } }
class Branch : Root { public new int Read() { return 13; } }
class Leaf : Branch { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch branch = new Branch();
        Root asRoot = branch;
        Leaf leaf = new Leaf();
        Check(new Root().Read() == 5, "declaring-instance-invokes-nonvirtual-implementation");
        Check(asRoot.Read() == 5, "base-compile-time-type-selects-base-method-on-derived-object");
        Check(branch.Read() == 13, "derived-compile-time-type-selects-hidden-method");
        Check(((Root)leaf).Read() == 5, "nonvirtual-base-implementation-invariant-on-leaf");
        Check(((Branch)leaf).Read() == 13, "inherited-hidden-method-selected-by-compile-time-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
