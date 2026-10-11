/*
Rules: E23-7-empty-array-address
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int[] items = new int[0];
Into: int[] items = new int[1];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[] items = new int[0];
        int[,] rectangle = new int[2, 0];
        fixed (int* pointer = items) Check(pointer == null, "empty-vector-zero-address");
        fixed (int* pointer = rectangle) Check(pointer == null, "empty-rectangle-zero-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
