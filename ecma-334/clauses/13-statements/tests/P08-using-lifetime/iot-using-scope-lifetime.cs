/*
Rules: P08-using-lifetime
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: using Lease resource = Acquire();
Into: Lease resource = Acquire();
*/
using System;

// using.md L52; both committee statements 13.14.2: disposal ends the scope.
class Lease : IDisposable
{
    public static int Disposals;
    public void Dispose() { Disposals++; }
}
class Program
{
    static int checks, failures, acquisitions;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static Lease Acquire() { acquisitions++; return new Lease(); }
    static void Exercise()
    {
        using Lease resource = Acquire();
        Check(acquisitions == 1, "acquisition-once");
        Check(Lease.Disposals == 0, "alive-after-declaration");
        int marker = 17;
        Check(marker == 17 && Lease.Disposals == 0, "alive-after-later-statement");
    }
    static int Main()
    {
        Exercise();
        Check(Lease.Disposals == 1, "disposed-at-scope-exit-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
