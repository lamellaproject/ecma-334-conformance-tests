/*
Rules: E23-9-explicit-pointer-stackalloc
Authority: ECMA-334 7th ed 23.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: short* memory = stackalloc short[2] { 17, 29 };
Into: short memory = stackalloc short[2] { 17, 29 };
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
        Check(memory[0] == 17, "explicit-pointer-first-element");
        Check(memory[1] == 29, "explicit-pointer-second-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
