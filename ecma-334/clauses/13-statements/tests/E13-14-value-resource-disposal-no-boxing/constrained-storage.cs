/*
Rules: E13-14-value-resource-disposal-no-boxing; E13-14-value-resource-disposal
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (T resource = default(T)) { resource.Remember(); }
Into: T resource = default(T); resource.Remember(); ((IDisposable)resource).Dispose();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int disposed;
    static bool same;
    interface Rememberable { void Remember(); }
    // Only the storage comparison needs clause 23 unsafe pointers.
    unsafe struct Resource : IDisposable, Rememberable
    {
        int marker;
        ulong address;
        public void Remember() { fixed (int* pointer = &marker) { address = (ulong)pointer; } }
        public void Dispose() { disposed++; fixed (int* pointer = &marker) { same = address == (ulong)pointer; } }
    }
    static void Use<T>() where T : struct, IDisposable, Rememberable
    {
        using (T resource = default(T)) { resource.Remember(); }
    }
    static void Main()
    {
        Use<Resource>();
        Check(disposed == 1, "constrained-value-resource-disposed");
        // Compare storage addresses without reading through a saved pointer.
        Check(same, "constrained-disposal-does-not-box-resource");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
