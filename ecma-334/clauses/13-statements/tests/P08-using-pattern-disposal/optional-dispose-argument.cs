/*
Rules: P08-using-pattern-disposal
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: Dispose(int marker = 5)
Into: Dispose(int marker)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int disposed;
    ref struct Lease { public void Dispose(int marker = 5) { disposed = disposed * 10 + marker; } }
    static int Main()
    {
        Lease first = new Lease();
        using (first) { }
        Check(disposed == 5, "pattern-expression-default-argument");
        using (Lease second = new Lease()) { }
        Check(disposed == 55, "pattern-declaration-default-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
