/*
Rules: E23-4-fixed-address; E23-4-fixed-local-variable; E23-4-variable-categories
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int* p = &value;
Into: int* p = &other;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 19, other = 4;
        int* p = &value;
        Check(*p == 19, "local-address");
        *p = 23;
        Check(value == 23, "local-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
