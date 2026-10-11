/*
Rules: E23-4-fixed-pointer-element
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int* q = &p[1];
Into: int* q = &p[0];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* p = stackalloc int[2];
        p[0] = 13; p[1] = 47;
        int* q = &p[1];
        Check(q == p + 1 && *q == 47, "pointer-element-fixed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
