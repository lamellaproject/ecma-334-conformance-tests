/*
Rules: E23-3-pointer-integral-conversions
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ulong bits = (ulong)p;
Into: ulong bits = (ulong)(p + 1);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 79;
            int* p = &value;
            // The configured dotnet target has pointers no wider than ulong.
            ulong bits = (ulong)p;
            int* q = (int*)bits;
            Check(q == p, "pointer-integral-roundtrip");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
