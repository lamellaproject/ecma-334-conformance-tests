/*
Rules: E23-3-dynamic-erasure
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick(int* p, dynamic unused)
Into: Pick(int p, dynamic unused)
*/
using System;
class Item
{
    public static unsafe int Pick(int* p, dynamic unused) { return 1; }
    public static int Pick(int p, object unused) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 89;
            Check(Item.Pick(&value, new object()) == 1, "pointer-survives-dynamic-erasure");
            Check(Item.Pick(value, new object()) == 2, "value-distinct-from-pointer");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
