/*
Rules: E18-4-1-hides-inherited; E18-4-1-inherited-outside-space; E18-4-1-redeclare-inherited; E18-4-6-single-inheritance-lookup; E18-4-6-derived-hiding
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int IBase.Read() { return 19; }
Into: int IBase.Read() { return ((IDerived)this).Read(); }
*/
using System;
interface IBase { int Read(); }
// 18.4.1, pp. 491-492 prints a blanket modifier ban that conflicts with its grammar
// and hiding rules. This test follows those rules, which permit new.
interface IDerived : IBase { new int Read(); }
class Reader : IDerived
{
    int IBase.Read() { return 19; }
    int IDerived.Read() { return 47; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IDerived value = new Reader();
        Check(value.Read() == 47, "derived-member-hides-base");
        Check(((IBase)value).Read() == 19, "base-member-retains-own-slot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
