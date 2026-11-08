/*
Rules: E13-14-expression-disposable-conversion-required
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E13-14-expression-disposable-conversion-required/pointer-expression.cs.part
Mutate: using (pointer)
Into: using (new Lease())
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
    class Lease : IDisposable { public void Dispose() { } }
    static unsafe int Main()
    {
        int value = 31;
        int* pointer = &value;
        using (pointer) { }
        Check(value == 31, "pointer-repair-preserves-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
