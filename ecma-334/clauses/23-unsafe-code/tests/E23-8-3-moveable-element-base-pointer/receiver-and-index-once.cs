/*
Rules: E23-8-3-moveable-element-base-pointer; E23-8-3-moveable-element-pointer-access
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Observe().Data.Values[Index()] = 47;
Into: Observe().Data.Values[0] = 47;
*/
using System;
unsafe struct Data { public fixed short Values[2]; }
class Item { public Data Data; }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Item owner = new Item();
    static string trace = "";
    static Item Observe() { trace += "o"; return owner; }
    static long Index() { trace += "i"; return 1; }
    static void Main()
    {
        owner.Data.Values[0] = 7; owner.Data.Values[1] = 19;
        Observe().Data.Values[Index()] = 47;
        Check(trace == "oi", "buffer-receiver-then-index-once");
        Check(owner.Data.Values[0] == 7 && owner.Data.Values[1] == 47, "moveable-buffer-element-write");
        fixed (short* pointer = owner.Data.Values) Check(pointer[1] == 47, "moveable-buffer-element-is-pointer-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
