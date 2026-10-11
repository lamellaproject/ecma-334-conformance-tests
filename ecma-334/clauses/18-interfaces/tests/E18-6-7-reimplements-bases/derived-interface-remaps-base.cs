/*
Rules: E18-6-7-reimplements-bases
Authority: ECMA-334 7th ed 18.6.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Branch : Root, IDerived
Into: class Branch : Root
*/
using System;
interface IBase { int Read(); }
interface IDerived : IBase { }
class Root : IDerived { public int Read() { return 461; } }
class Branch : Root, IDerived { public new int Read() { return 463; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch branch = new Branch();
        Check(((IDerived)branch).Read() == 463, "reimplemented-derived-interface");
        Check(((IBase)branch).Read() == 463, "base-interface-implicitly-reimplemented");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
