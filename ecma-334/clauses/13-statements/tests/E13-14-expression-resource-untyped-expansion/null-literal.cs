/*
Rules: E13-14-expression-resource-untyped-expansion; E13-14-null-resource-not-disposed; E13-14-null-resource-no-exception
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using (null)
Into: using (new Resource())
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int disposed;
    class Resource : IDisposable { public void Dispose() { disposed++; } }
    static void Main()
    {
        bool visited = false, completed = true;
        try { using (null) { visited = true; } }
        catch (Exception) { completed = false; }
        Check(visited && completed && disposed == 0, "untyped-null-resource-skips-dispose");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
