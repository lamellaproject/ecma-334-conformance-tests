/*
Rules: E13-14-value-resource-disposal-no-boxing; E13-14-value-resource-disposal
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (Resource resource = new Resource()) { resource.Remember(); }
Into: Resource resource = new Resource(); resource.Remember(); ((IDisposable)resource).Dispose();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int disposed;
    static bool same;
    // Only the storage comparison needs clause 23 unsafe pointers.
    unsafe struct Resource : IDisposable
    {
        int marker;
        ulong address;
        public void Remember() { fixed (int* pointer = &marker) { address = (ulong)pointer; } }
        public void Dispose() { disposed++; fixed (int* pointer = &marker) { same = address == (ulong)pointer; } }
    }
    static void Main()
    {
        using (Resource resource = new Resource()) { resource.Remember(); }
        Check(disposed == 1, "value-resource-disposed");
        // Boxing copies the resource; no saved pointer is dereferenced.
        Check(same, "disposal-uses-original-resource-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
