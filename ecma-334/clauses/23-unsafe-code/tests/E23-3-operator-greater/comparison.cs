/*
Rules: E23-3-operator-greater
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: q > p
Into: q < p
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
            int* q = p + 1;
            bool actual = q > p;
            Check(actual, "pointer-greater");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
