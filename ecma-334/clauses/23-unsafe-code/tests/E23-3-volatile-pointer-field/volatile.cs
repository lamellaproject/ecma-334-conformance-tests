/*
Rules: E23-3-volatile-pointer-field
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile int* Pointer;
Into: public volatile object Pointer;
*/
using System;
unsafe class Item { public volatile int* Pointer; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            Item item = new Item();
            int value = 83;
            item.Pointer = &value;
            Check(item.Pointer == &value, "volatile-pointer-field");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
