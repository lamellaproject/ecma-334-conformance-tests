/*
Rules: E23-7-address-initializer; E23-7-form-address-initializer; E23-7-address-initializer-result; E23-7-address-initializer-pins; E23-7-fixed-address-duration; E23-7-gc-no-relocation
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 3
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
        owner.Value = 43;
        fixed (int* pointer = &owner.Value)
        {
            Check(*pointer == 43, "pinned-field-address");
            // A compacting collection is needed to observe the address guarantee.
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            fixed (int* after = &owner.Value) Check(pointer == after, "field-address-after-collection");
            Check(*pointer == 43, "field-value-after-collection");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
