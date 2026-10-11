/*
Rules: E9-2-9-declaration-in-using
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Resource { Value = 44 }
Into: new Resource { Value = 0 }
*/
using System;
class Resource : IDisposable
{
    public int Value;
    public static int Disposed;
    public void Dispose() { Disposed++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        using (Resource cell = new Resource { Value = 44 }) Check(cell.Value == 44, "using-declares-readable-local");
        Check(Resource.Disposed == 1, "using-local-scope-completed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
