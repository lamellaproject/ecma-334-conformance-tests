/*
Rules: E23-7-gc-no-disposal
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: fixed (int* pointer = &owner.Value)
Into: fixed (int* pointer = &other.Value)
*/
using System;
class Item { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item owner = new Item(), other = new Item();
        owner.Value = 29;
        // The weak reference observes survival without keeping the owner alive itself.
        WeakReference weak = new WeakReference(owner);
        fixed (int* pointer = &owner.Value)
        {
            owner = null;
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            Check(weak.IsAlive, "pinned-owner-survives-collection");
            if (weak.IsAlive) Check(*pointer == 29, "sole-pin-root-value");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
