/*
Rules: E23-6-9-struct-size-includes-padding
Authority: ECMA-334 7th ed 23.6.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int total = sizeof(Item);
Into: int total = sizeof(byte);
*/
using System;
struct Item { public byte Small; public int Wide; public short Tail; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item[] items = new Item[2];
        int total = sizeof(Item);
        fixed (Item* first = &items[0], second = &items[1])
        {
            long stride = (byte*)second - (byte*)first;
            Check(stride == total, "struct-size-is-complete-storage-stride");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
