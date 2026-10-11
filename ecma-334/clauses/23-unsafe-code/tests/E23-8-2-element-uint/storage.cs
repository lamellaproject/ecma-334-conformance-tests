/*
Rules: E23-8-2-element-uint
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public fixed uint Values[3];
Into: public fixed byte Values[3];
*/
using System;
unsafe struct Item { public fixed uint Values[3]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        uint* pointer = value.Values;
        pointer[0] = (uint)11; pointer[1] = (uint)19; pointer[2] = (uint)29;
        Check(value.Values[0] == (uint)11 && value.Values[1] == (uint)19 && value.Values[2] == (uint)29, "typed-buffer-element-values");
        Check((byte*)&pointer[2] - (byte*)&pointer[0] == 2 * sizeof(uint), "buffer-element-byte-stride");
        Check(sizeof(Item) >= 3 * sizeof(uint), "buffer-storage-extent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
