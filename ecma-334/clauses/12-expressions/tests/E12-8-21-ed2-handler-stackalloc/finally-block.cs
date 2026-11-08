/*
Rules: E12-8-21-ed2-handler-stackalloc
Authority: ECMA-334 2nd ed 25.7
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E12-8-21-ed2-handler-stackalloc/finally-block.cs.part
Mutate: int* cells = stackalloc int[1];
Into: int* cells = (int*)0;
*/
// ECMA-334 2nd ed 25.7, p. 331 (PDF p. 347).
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int* allowed = stackalloc int[2];
        allowed[0] = 13;
        try { }
        finally
        {
            int* cells = stackalloc int[1];
        }
        Check(allowed[0] == 13, "outside-allocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
