/*
Rules: E18-2-2-modifier-new; E18-2-2-new-hides
Authority: ECMA-334 7th ed 18.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new interface ILabel { int Derived(); }
Into: public new interface ILabel : Root.ILabel { int Derived(); }
*/
using System;
class Root { public interface ILabel { int Original(); } }
class Branch : Root { public new interface ILabel { int Derived(); } }
class Label : Branch.ILabel { public int Derived() { return 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch.ILabel label = new Label();
        Check(label.Derived() == 31, "lookup-selects-hidden-interface");
        Check(!(label is Root.ILabel), "new-interface-has-own-contract");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
