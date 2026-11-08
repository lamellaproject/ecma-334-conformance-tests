/*
Rules: E13-14-other-resource-disposal; E13-14-expression-resource-typed-expansion; E13-14-expression-disposable-conversion-required
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: using (item)
Into: if (true)
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
    static int disposed, entered;
    class Lease : IDisposable { public void Dispose() { disposed += 2; } }
    struct Stamp : IDisposable { public void Dispose() { disposed += 5; } }
    static void Use<T>(T item) where T : IDisposable
    {
        using (item) { entered++; }
    }
    static int Main()
    {
        Use(new Lease());
        Check(disposed == 2 && entered == 1, "class-expression-disposes");
        Use(new Stamp());
        Check(disposed == 7 && entered == 2, "value-expression-disposes");
        Use<Lease>(null);
        Check(disposed == 7 && entered == 3, "null-expression-skips-dispose");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
