/*
Rules: E23-9-stackalloc-pointer-address
Authority: ECMA-334 7th ed 23.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: short* memory = stackalloc short[2] { 17, 29 };
Into: short* storage = stackalloc short[2] { 17, 29 }; short* memory = storage + 1;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        // 23.9, p. 568: "to be beginning" appears to be a typo; follow the intent, the block's beginning.
        short* memory = stackalloc short[2] { 17, 29 };
        Check(*memory == 17, "pointer-addresses-initialized-block-beginning");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
