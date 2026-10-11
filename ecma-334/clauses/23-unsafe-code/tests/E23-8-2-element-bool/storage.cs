/*
Rules: E23-8-2-element-bool
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public fixed bool Values[3];
Into: public fixed byte Values[3];
*/
using System;
unsafe struct Item { public fixed bool Values[3]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        bool* pointer = value.Values;
        pointer[0] = true; pointer[1] = false; pointer[2] = true;
        Check(value.Values[0] == true && value.Values[1] == false && value.Values[2] == true, "typed-buffer-element-values");
        Check((byte*)&pointer[2] - (byte*)&pointer[0] == 2 * sizeof(bool), "buffer-element-byte-stride");
        Check(sizeof(Item) >= 3 * sizeof(bool), "buffer-storage-extent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
