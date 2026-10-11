/*
Rules: E9-4-4-18-body-transfer
Authority: ECMA-334 7th ed 9.4.4.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Acquire(out cell)
Into: Acquire(out _)
*/
using System;
class Resource : IDisposable
{
    public static int Cleaned;
    public void Dispose() { Cleaned++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Resource Acquire(out int cell) { cell = 13; return new Resource(); }
    static void Main()
    {
        int cell;
        using (Resource resource = Acquire(out cell)) Check(cell == 13, "acquisition-assigns-before-body");
        Check(cell == 13 && Resource.Cleaned == 1, "acquisition-state-after-cleanup");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
