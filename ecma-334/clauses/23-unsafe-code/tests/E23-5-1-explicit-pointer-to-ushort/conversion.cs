/*
Rules: E23-5-1-explicit-pointer-to-ushort
Authority: ECMA-334 7th ed 23.5.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: ushort number = (ushort)pointer;
Into: ushort number = pointer;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 6;
        int* pointer = &value;
        // Every integral result is allowed by the implementation-defined mapping.
        ushort number = (ushort)pointer;
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
