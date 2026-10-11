/*
Rules: E13-6-2-1-using-local-scope
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: item.Value = 9;
Into: item.Value = 8;
*/
using System;
class Program
{
    static int checks, failures, disposedValue;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Resource : IDisposable { public int Value; public void Dispose() { disposedValue = Value; } }
    static void Main()
    {
        using (Resource item = new Resource()) { item.Value = 9; }
        Check(disposedValue == 9, "resource-local-in-body-and-expansion-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
