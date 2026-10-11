/*
Rules: E23-4-fixed-pointer-member
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int* p = &item->Value;
Into: int* p = &other.Value;
*/
using System;
struct Item { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item(), other = new Item();
        value.Value = 61;
        Item* item = &value;
        int* p = &item->Value;
        Check(*p == 61, "pointer-member-fixed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
