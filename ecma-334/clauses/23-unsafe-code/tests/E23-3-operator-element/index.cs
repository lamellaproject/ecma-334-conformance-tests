/*
Rules: E23-3-operator-element; E23-3-operator-stackalloc
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int observed = p[1];
Into: int observed = p[0];
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
            int* p = stackalloc int[2];
            p[0] = 7; p[1] = 11;
            int observed = p[1];
            Check(observed == 11, "pointer-element-access");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
