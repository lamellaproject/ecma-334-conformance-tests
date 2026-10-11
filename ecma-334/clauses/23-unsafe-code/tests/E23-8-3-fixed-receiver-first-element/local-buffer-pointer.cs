/*
Rules: E23-8-3-fixed-receiver-first-element; E23-8-3-fixed-receiver-pointer-type; E23-8-3-subsequent-element-pointers
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: short* pointer = value.Values;
Into: short* pointer = other.Values;
*/
using System;
unsafe struct Item { public fixed short Values[3]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item(), other = new Item();
        value.Values[0] = 17; value.Values[2] = 43;
        other.Values[0] = 5; other.Values[2] = 11;
        short* pointer = value.Values;
        Check(*pointer == 17, "fixed-buffer-first-element");
        Check(*(pointer + 2) == 43, "fixed-buffer-later-pointer");
        pointer[1] = 37;
        Check(value.Values[1] == 37, "fixed-buffer-pointer-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
