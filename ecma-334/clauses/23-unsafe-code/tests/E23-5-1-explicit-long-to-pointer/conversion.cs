/*
Rules: E23-5-1-explicit-long-to-pointer
Authority: ECMA-334 7th ed 23.5.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: int* pointer = (int*)number;
Into: int* pointer = number;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        long number = 6;
        // The mapping is implementation-defined; successful conversion is the only permitted oracle.
        int* pointer = (int*)number;
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
