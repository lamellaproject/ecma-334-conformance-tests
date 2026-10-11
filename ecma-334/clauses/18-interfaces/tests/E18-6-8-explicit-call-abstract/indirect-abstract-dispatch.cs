/*
Rules: E18-6-8-explicit-call-abstract
Authority: ECMA-334 7th ed 18.6.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int IRead.Read() { return ReadCore(); }
Into: int IRead.Read() { return 487; }
*/
using System;
interface IRead { int Read(); }
abstract class Root : IRead
{
    int IRead.Read() { return ReadCore(); }
    public abstract int ReadCore();
}
class Branch : Root { public override int ReadCore() { return 491; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((IRead)new Branch()).Read() == 491, "explicit-implementation-calls-abstract-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
