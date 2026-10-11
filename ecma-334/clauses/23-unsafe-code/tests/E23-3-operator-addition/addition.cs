/*
Rules: E23-3-operator-addition
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int* q = p + 2;
Into: int* q = p + 1;
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
            int* p = stackalloc int[3];
            p[1] = 7; p[2] = 11;
            int* q = p + 2;
            Check(*q == 11, "pointer-addition");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
