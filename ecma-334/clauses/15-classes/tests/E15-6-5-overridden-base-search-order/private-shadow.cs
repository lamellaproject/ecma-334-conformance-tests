/*
Rules: E15-6-5-overridden-base-search-order
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: private new int Read()
Into: public new int Read()
*/
using System;
class Root { public virtual int Read() { return 13; } }
class Branch : Root { private new int Read() { return 17; } }
class Leaf : Branch { public override int Read() { return 19; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf();
        Check(((Root)value).Read() == 19, "override-lookup-skips-inaccessible-private-shadow");
        Check(value.Read() == 19, "override-binds-farther-accessible-virtual-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
