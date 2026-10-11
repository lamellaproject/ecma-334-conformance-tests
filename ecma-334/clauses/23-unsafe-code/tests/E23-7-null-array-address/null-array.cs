/*
Rules: E23-7-null-array-address
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int[] items = null;
Into: int[] items = new int[] { 7 };
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[] items = null;
        fixed (int* pointer = items) Check(pointer == null, "null-array-zero-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
