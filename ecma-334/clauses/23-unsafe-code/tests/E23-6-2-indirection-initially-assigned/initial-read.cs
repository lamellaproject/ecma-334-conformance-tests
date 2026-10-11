/*
Rules: E23-6-2-indirection-initially-assigned
Authority: ECMA-334 7th ed 23.6.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: int result = *pointer;
Into: int result; int copy = result;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* pointer = stackalloc int[1];
        // Valid allocated storage can be read without a prior source-level assignment; its value is unrestricted.
        int result = *pointer;
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
