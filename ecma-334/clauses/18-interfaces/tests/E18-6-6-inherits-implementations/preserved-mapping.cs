/*
Rules: E18-6-6-inherits-implementations; E18-6-6-inherited-mapping-preserved
Authority: ECMA-334 7th ed 18.6.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: class Branch : Root
Into: class Branch : Root, IRead
*/
using System;
interface IRead { int Read(); }
class Root : IRead { public int Read() { return 379; } }
class Branch : Root { public new int Read() { return 383; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch branch = new Branch();
        IRead reader = branch;
        Check(reader.Read() == 379, "inherited-interface-mapping-preserved");
        Check(branch.Read() == 383, "new-member-does-not-remap-interface");
        Check(((Root)branch).Read() == 379, "ordinary-base-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
