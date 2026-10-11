/*
Rules: E23-9-stackalloc-pointer-access-unsafe
Authority: ECMA-334 7th ed 23.9
Version: 7.3
Expected: reject
Mutate: static void Main()
Into: static unsafe void Main()
Csc: CS0214
*/
using System;
class Program
{
    static unsafe byte* Pointer;
    static void Main()
    {
        unsafe
        {
            // 23.9, p. 568: "to be beginning" appears to be a typo; follow the intent, the block's beginning.
            byte* memory = stackalloc byte[1];
            memory[0] = 17;
            Pointer = memory;
        }
        // The allocation is alive until this Main returns, including in the valid repair.
        Console.WriteLine(Pointer[0] == 17 ? "same-allocation" : "wrong-value");
    }
}
