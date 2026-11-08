/*
Rules: E13-14-declaration-disposable-conversion-required
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E13-14-declaration-disposable-conversion-required/unconstrained-declaration.cs.part
Mutate: static void Use<T>(T item)
Into: static void Use<T>(T item) where T : IDisposable
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
    class Lease : IDisposable { public void Dispose() { disposed++; } }
    static void Use<T>(T item) { using (T acquired = item) { } }
    static int Main()
    {
        Use(new Lease());
        Check(disposed == 1, "constrained-repair-disposes");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
