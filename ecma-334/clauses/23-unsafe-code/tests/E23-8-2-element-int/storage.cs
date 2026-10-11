/*
Rules: E23-8-2-element-int
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public fixed int Values[3];
Into: public fixed byte Values[3];
*/
using System;
unsafe struct Item { public fixed int Values[3]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        int* pointer = value.Values;
        pointer[0] = (int)11; pointer[1] = (int)19; pointer[2] = (int)29;
        Check(value.Values[0] == (int)11 && value.Values[1] == (int)19 && value.Values[2] == (int)29, "typed-buffer-element-values");
        Check((byte*)&pointer[2] - (byte*)&pointer[0] == 2 * sizeof(int), "buffer-element-byte-stride");
        Check(sizeof(Item) >= 3 * sizeof(int), "buffer-storage-extent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
