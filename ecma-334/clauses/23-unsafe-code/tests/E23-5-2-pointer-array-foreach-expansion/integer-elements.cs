/*
Rules: E23-5-2-pointer-array-foreach-expansion; E23-5-2-foreach-iteration-value
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: foreach (int* current in items)
Into: foreach (bool current in items)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[] items = { 6, 10, 14 };
        int count = 0;
        // Each integer-to-pointer mapping is implementation-defined; no pointer is dereferenced.
        foreach (int* current in items) count++;
        Check(count == 3, "pointer-iteration-over-integral-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
