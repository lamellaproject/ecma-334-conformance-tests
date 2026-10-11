/*
Rules: E6-4-4-grammar-keyword-26
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: fixed (int* pointer = values)
Into: pin (int* pointer = values)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[] values = { 61 };
        fixed (int* pointer = values) { Check(*pointer == 61, "fixed-statement"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
