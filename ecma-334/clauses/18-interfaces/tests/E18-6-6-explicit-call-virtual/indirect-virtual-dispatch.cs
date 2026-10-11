/*
Rules: E18-6-6-explicit-call-virtual
Authority: ECMA-334 7th ed 18.6.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public override int ReadCore()
Into: public new int ReadCore()
*/
using System;
interface IRead { int Read(); }
class Root : IRead
{
    int IRead.Read() { return ReadCore(); }
    public virtual int ReadCore() { return 419; }
}
class Branch : Root { public override int ReadCore() { return 421; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((IRead)new Root()).Read() == 419, "explicit-calls-base-virtual");
        Check(((IRead)new Branch()).Read() == 421, "explicit-calls-derived-virtual");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
