/*
Rules: E23-8-3-moveable-fixed-initializer-pointer
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: fixed (short* pointer = owner.Data.Values)
Into: fixed (short* pointer = other.Data.Values)
*/
using System;
unsafe struct Data { public fixed short Values[2]; }
class Item { public Data Data; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item owner = new Item(), other = new Item();
        owner.Data.Values[0] = 29;
        fixed (short* pointer = owner.Data.Values)
        {
            Check(*pointer == 29, "moveable-buffer-first-pointer");
            pointer[1] = 41;
        }
        Check(owner.Data.Values[1] == 41, "moveable-buffer-pointer-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
