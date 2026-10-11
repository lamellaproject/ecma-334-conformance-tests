/*
Rules: E13-9-5-value-disposal-no-boxing; E13-9-5-value-enumerator-disposal
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int item in new Source()) { }
Into: Cursor cursor = new Source().GetEnumerator(); cursor.MoveNext(); ((IDisposable)cursor).Dispose();
*/
using System;
class Program
{
    static int checks, failures, disposed;
    static bool same;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source { public Cursor GetEnumerator() { return new Cursor(); } }
    // Only the storage comparison needs clause 23 unsafe pointers.
    unsafe struct Cursor : IDisposable
    {
        int marker;
        ulong address;
        public int Current { get { return 0; } }
        public bool MoveNext() { fixed (int* pointer = &marker) { address = (ulong)pointer; } return false; }
        public void Dispose() { disposed++; fixed (int* pointer = &marker) { same = address == (ulong)pointer; } }
    }
    static void Main()
    {
        foreach (int item in new Source()) { }
        Check(disposed == 1, "empty-value-enumerator-disposed");
        // Boxing copies the value into distinct storage. No captured pointer is dereferenced.
        Check(same, "disposal-uses-original-enumerator-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
