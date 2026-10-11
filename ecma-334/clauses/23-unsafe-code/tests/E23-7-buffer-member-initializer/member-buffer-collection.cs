/*
Rules: E23-7-buffer-member-initializer; E23-7-buffer-initializer-result; E23-7-buffer-initializer-pins
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: fixed (short* pointer = owner.Data.Values)
Into: fixed (short* pointer = other.Data.Values)
*/
using System;
unsafe struct Data { public fixed short Values[3]; }
class Item { public Data Data; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item owner = new Item(), other = new Item();
        owner.Data.Values[0] = 31; owner.Data.Values[2] = 43;
        fixed (short* pointer = owner.Data.Values)
        {
            Check(pointer[0] == 31 && pointer[2] == 43, "buffer-first-element-pointer");
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            fixed (short* after = owner.Data.Values) Check(pointer == after, "buffer-address-after-collection");
            pointer[2] = 61;
            Check(owner.Data.Values[2] == 61, "buffer-pinned-element-write");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
