/*
Rules: E23-6-2-form-indirection; E23-6-2-indirection-variable
Authority: ECMA-334 7th ed 23.6.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: *pointer = 37;
Into: other = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 11, other = 5;
        int* pointer = &value;
        Check(*pointer == 11, "indirection-referent-value");
        *pointer = 37;
        Check(value == 37 && other == 5, "indirection-referent-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
