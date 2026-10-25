/*
Rules: P08-using-exit-disposal
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 5
Mutate: using Lease resource = new Lease(4);
Into: Lease resource = new Lease(4);
*/
using System;

// using.md L33; both committee statements 13.14.1/2: the equivalent finally runs.
class Signal : Exception { }
class Lease : IDisposable
{
    public static int Trace;
    int marker;
    public Lease(int marker) { this.marker = marker; }
    public void Dispose() { Trace = Trace * 10 + marker; }
}
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Leave()
    {
        using Lease resource = new Lease(4);
        return 19;
    }
    static void ThrowSignal()
    {
        using Lease resource = new Lease(5);
        throw new Signal();
    }
    static void NullResource() { using Lease resource = null; }
    static int Main()
    {
        Check(Leave() == 19, "return-value-preserved");
        Check(Lease.Trace == 4, "return-disposes-once");
        bool signalled = false;
        try { ThrowSignal(); }
        catch (Signal) { signalled = true; }
        Check(signalled, "exception-type-preserved");
        Check(Lease.Trace == 45, "exception-disposes-once");
        NullResource();
        Check(Lease.Trace == 45, "null-resource-has-no-disposal");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
