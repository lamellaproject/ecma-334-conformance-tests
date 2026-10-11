/*
Rules: E15-6-5-overridden-base-search-order; E15-6-5-overridden-base-name; E15-6-5-virtual-introduces-method; E15-6-5-override-base-access
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public new virtual int Read()
Into: public override int Read()
*/
using System;
class Root { public virtual int Read() { return 3; } }
class Branch : Root { public new virtual int Read() { return 7; } }
class Leaf : Branch { public override int Read() { return base.Read() + 4; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf();
        Check(((Root)value).Read() == 3, "override-lookup-leaves-farther-hidden-slot-independent");
        Check(((Branch)value).Read() == 11, "first-accessible-direct-base-method-is-overridden");
        Check(value.Read() == 11, "base-access-invokes-selected-overridden-base-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
