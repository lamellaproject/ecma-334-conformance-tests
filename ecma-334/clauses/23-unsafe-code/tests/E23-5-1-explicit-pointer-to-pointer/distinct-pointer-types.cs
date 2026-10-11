/*
Rules: E23-5-1-explicit-pointer-to-pointer
Authority: ECMA-334 7th ed 23.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: short* converted = (short*)original;
Into: short* converted = (short*)&other;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 71, other = 11;
        int* original = &value;
        short* converted = (short*)original;
        Check((void*)converted == (void*)original, "explicit-distinct-pointer-address");
        int* restored = (int*)converted;
        Check(*restored == 71, "explicit-distinct-pointer-roundtrip");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
