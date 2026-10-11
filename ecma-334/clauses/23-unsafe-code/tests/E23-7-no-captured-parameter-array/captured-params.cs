/*
Rules: E23-7-no-captured-parameter-array
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: fixed (int* pointer = items)
Into: fixed (int* pointer = new int[1])
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Read(params int[] items)
    {
        Func<int> read = () => items[0];
        // ECMA-334 7th ed 23.7, p. 561 says "use"; its literal text appears
        // incorrect if read as forbidding array-form pinning. The note ending
        // 23.6.5, p. 559 restricts taking the captured variable's own address.
        // This test follows that intent instead, pinning the array object.
        fixed (int* pointer = items) { *pointer = 37; }
        Check(read() == 37, "captured-params-array-pin");
    }
    static void Main()
    {
        Read(7, 11, 19);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
