/*
Rules: E13-14-other-resource-disposal-conversion; E13-14-other-resource-disposal
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (Resource? resource = new Resource(19))
Into: using (Resource? resource = null)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int disposed, value;
    struct Resource : IDisposable
    {
        int id;
        public Resource(int number) { id = number; }
        public void Dispose() { disposed++; value = id; }
    }
    static void Main()
    {
        using (Resource? resource = new Resource(19)) { }
        Check(disposed == 1 && value == 19, "nullable-present-resource-converts-to-disposable");
        using (Resource? resource = null) { }
        Check(disposed == 1, "nullable-absent-resource-skips-dispose");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
