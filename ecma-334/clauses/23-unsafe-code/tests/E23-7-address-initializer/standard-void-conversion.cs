/*
Rules: E23-7-address-initializer
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: fixed (void* pointer = &owner.Value)
Into: fixed (void* pointer = &other.Value)
*/
using System;
class Item { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item owner = new Item(), other = new Item();
        owner.Value = 41;
        fixed (void* pointer = &owner.Value) Check(*(int*)pointer == 41, "address-initializer-void-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
