/*
Rules: E18-6-8-abstract-method-mapping
Authority: ECMA-334 7th ed 18.6.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public override int Read()
Into: public new int Read()
*/
using System;
interface IRead { int Read(); }
abstract class Root : IRead { public abstract int Read(); }
class Branch : Root { public override int Read() { return 467; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((IRead)new Branch()).Read() == 467, "abstract-interface-slot-implemented-by-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
