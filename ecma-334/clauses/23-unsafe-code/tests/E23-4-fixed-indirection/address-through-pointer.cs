/*
Rules: E23-4-fixed-indirection
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int* q = &*p;
Into: int* q = &other;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 31, other = 5;
        int* p = &value;
        int* q = &*p;
        Check(q == p, "dereferenced-variable-fixed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
