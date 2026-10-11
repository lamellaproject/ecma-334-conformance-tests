/*
Rules: E23-6-4-element-ulong-index
Authority: ECMA-334 7th ed 23.6.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int result = pointer[index];
Into: int result = pointer[0];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* pointer = stackalloc int[2];
        pointer[0] = 11; pointer[1] = 31;
        ulong index = 1;
        int result = pointer[index];
        Check(result == 31, "typed-pointer-index");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
