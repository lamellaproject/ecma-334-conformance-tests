/*
Rules: E23-8-3-buffer-element-no-range-check
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: byte result = storage[0].Values[index];
Into: byte result = storage[0].Values[0];
*/
using System;
unsafe struct Item { public fixed byte Values[1]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item[] items = new Item[2];
        items[0].Values[0] = 7; items[1].Values[0] = 53;
        fixed (Item* storage = items)
        {
            // This index leaves the first buffer but stays in the allocated array and reaches the second buffer.
            // sizeof(Item) works for every permitted amount of struct padding.
            int index = sizeof(Item);
            byte result = storage[0].Values[index];
            Check(result == 53, "buffer-no-range-check-inside-allocation");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
