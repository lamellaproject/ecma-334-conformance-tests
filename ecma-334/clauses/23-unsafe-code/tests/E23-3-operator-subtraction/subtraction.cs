/*
Rules: E23-3-operator-subtraction
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int* q = last - 2;
Into: int* q = last - 1;
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
            p[0] = 7; p[1] = 11;
            int* last = p + 2;
            int* q = last - 2;
            Check(*q == 7, "pointer-subtraction");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
