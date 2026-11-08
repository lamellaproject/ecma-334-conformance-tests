/*
Rules: P08-using-exit-disposal
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: using Lease? present = new Lease(13);
Into: Lease? present = new Lease(13);
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
    struct Lease : IDisposable
    {
        int marker;
        public Lease(int value) { marker = value; }
        public void Dispose() { disposed += marker; }
    }
    static int Main()
    {
        {
            using Lease? present = new Lease(13);
            using Nullable<Lease> absent = null;
            Check(disposed == 0, "nullable-declarations-live-in-scope");
        }
        Check(disposed == 13, "only-present-declaration-disposes");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
