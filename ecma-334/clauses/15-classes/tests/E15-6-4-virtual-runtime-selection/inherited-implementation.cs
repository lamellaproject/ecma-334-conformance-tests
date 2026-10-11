/*
Rules: E15-6-4-virtual-runtime-selection; E15-6-4-virtual-method-classification; E15-6-4-virtual-overriding; E15-6-4-invocation-virtual-most-derived; E15-6-4-most-derived-exists; E15-6-4-most-derived-introduction; E15-6-4-most-derived-override; E15-6-4-most-derived-inherited
Authority: ECMA-334 7th ed 15.6.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public override int Read()
Into: public new int Read()
*/
using System;
class Root { public virtual int Read() { return 3; } }
class Branch : Root { public override int Read() { return 11; } }
class Leaf : Branch { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root root = new Root(), branch = new Branch(), leaf = new Leaf();
        Check(root.Read() == 3, "introducing-class-selects-introducing-implementation");
        Check(branch.Read() == 11, "runtime-derived-class-selects-override");
        Check(leaf.Read() == 11, "leaf-without-override-inherits-most-derived-implementation");
        Check(((Branch)leaf).Read() == 11, "inherited-virtual-method-has-same-runtime-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
