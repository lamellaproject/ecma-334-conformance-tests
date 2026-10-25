/*
Rules: P08-using-disposal-order
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: using Lease first = new Lease(1);
Into: Lease first = new Lease(1);
*/
using System;

// using.md L53; both committee statements 13.14.2: reverse declaration order.
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
    static void Exercise()
    {
        using Lease first = new Lease(1);
        using Lease second = new Lease(2);
        using Lease third = new Lease(3);
        Check(Lease.Trace == 0, "none-disposed-within-scope");
    }
    static int Main()
    {
        Exercise();
        Check(Lease.Trace == 321, "reverse-declaration-order-once-each");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
