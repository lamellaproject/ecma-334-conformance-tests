/*
Rules: E23-8-2-element-ulong
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public fixed ulong Values[3];
Into: public fixed byte Values[3];
*/
using System;
unsafe struct Item { public fixed ulong Values[3]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        ulong* pointer = value.Values;
        pointer[0] = (ulong)11; pointer[1] = (ulong)19; pointer[2] = (ulong)29;
        Check(value.Values[0] == (ulong)11 && value.Values[1] == (ulong)19 && value.Values[2] == (ulong)29, "typed-buffer-element-values");
        Check((byte*)&pointer[2] - (byte*)&pointer[0] == 2 * sizeof(ulong), "buffer-element-byte-stride");
        Check(sizeof(Item) >= 3 * sizeof(ulong), "buffer-storage-extent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
