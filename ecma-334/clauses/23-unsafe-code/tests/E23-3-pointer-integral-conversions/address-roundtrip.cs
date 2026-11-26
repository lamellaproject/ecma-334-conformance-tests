/*
Rules: E23-3-pointer-integral-conversions
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Kind((int*)bits)
Into: Kind(bits)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static string Kind(ulong value) { return "integer"; }
    static unsafe string Kind(int* value) { return "pointer"; }
    static void Main()
    {
        unsafe
        {
            int value = 79;
            int* p = &value;
            ulong bits = (ulong)p;
            Check(Kind(bits) == "integer" && Kind((int*)bits) == "pointer", "explicit-pointer-integral-conversions");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
