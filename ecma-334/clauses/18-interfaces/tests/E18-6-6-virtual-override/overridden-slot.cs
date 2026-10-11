/*
Rules: E18-6-6-virtual-override
Authority: ECMA-334 7th ed 18.6.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public override int Read()
Into: public new int Read()
*/
using System;
interface IRead { int Read(); }
class Root : IRead { public virtual int Read() { return 389; } }
class Branch : Root { public override int Read() { return 397; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IRead reader = new Branch();
        Check(reader.Read() == 397, "interface-maps-to-virtual-override");
        Check(((IRead)new Root()).Read() == 389, "base-virtual-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
