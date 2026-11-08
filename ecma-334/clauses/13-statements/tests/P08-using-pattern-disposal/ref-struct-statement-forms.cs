/*
Rules: P08-using-pattern-disposal
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: void Dispose()
Into: void Release()
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
    static int disposed, used;
    ref struct Lease { public void Dispose() { disposed++; } }
    static int Main()
    {
        Lease first = new Lease();
        using (first) { used++; }
        Check(disposed == 1 && used == 1, "pattern-expression-exit");
        using (Lease second = new Lease()) { used++; }
        Check(disposed == 2 && used == 2, "pattern-declaration-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
