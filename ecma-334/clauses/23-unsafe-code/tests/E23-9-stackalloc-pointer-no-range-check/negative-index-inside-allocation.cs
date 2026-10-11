/*
Rules: E23-9-stackalloc-pointer-no-range-check
Authority: ECMA-334 7th ed 23.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: byte* shifted = memory + 1;
Into: byte* shifted = memory + 2;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        // 23.9, p. 568: "to be beginning" appears to be a typo; follow the intent, the block's beginning.
        byte* memory = stackalloc byte[3] { 7, 19, 31 };
        byte* shifted = memory + 1;
        // A negative pointer index still addresses initialized storage inside this allocation.
        Check(shifted[-1] == 7, "negative-index-is-not-range-checked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
