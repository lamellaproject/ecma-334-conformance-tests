/*
Rules: E23-8-2-element-double
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public fixed double Values[3];
Into: public fixed byte Values[3];
*/
using System;
unsafe struct Item { public fixed double Values[3]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        double* pointer = value.Values;
        double first = 11, middle = 19, last = 29;
        pointer[0] = first; pointer[1] = middle; pointer[2] = last;
        bool bitsMatch = ((ulong*)pointer)[0] == *(ulong*)&first &&
                         ((ulong*)pointer)[1] == *(ulong*)&middle &&
                         ((ulong*)pointer)[2] == *(ulong*)&last;
        Check(bitsMatch, "floating-buffer-storage-bits");
        Check((byte*)&pointer[2] - (byte*)&pointer[0] == 2 * sizeof(double), "buffer-element-byte-stride");
        Check(sizeof(Item) >= 3 * sizeof(double), "buffer-storage-extent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
