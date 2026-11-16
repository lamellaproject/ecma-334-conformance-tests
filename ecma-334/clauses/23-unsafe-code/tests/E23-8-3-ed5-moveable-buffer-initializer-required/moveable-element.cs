/*
Rules: E23-8-3-ed5-moveable-buffer-initializer-required
Authority: ECMA-334 5th ed 23.8.3
Version: 5
Expected: reject
Version-Witness: version-witnesses/E23-8-3-ed5-moveable-buffer-initializer-required/moveable-element.cs.part
Mutate: short sample = owner.Payload.Items[Index()];
Into: short sample; fixed (short* pointer = owner.Payload.Items) { sample = pointer[Index()]; }
*/
// 23.8.3, p. 426 (PDF p. 448), permits a moveable buffer reference
// only as a fixed-pointer-initializer. Its elements are accessed through
// the resulting pointer while the fixed statement keeps the storage alive.
using System;
unsafe struct Buffer { public fixed short Items[2]; }
class Holder { public Buffer Payload; }
unsafe class Program
{
    static int checks, failures, indexCalls;
    static void Check(bool ok, string name) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Index() { indexCalls++; return 1; }
    static int Main()
    {
        Holder owner = new Holder();
        short sample = owner.Payload.Items[Index()];
        Check(sample == 0, "class-buffer-default");
        Check(indexCalls == 1, "element-index-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
