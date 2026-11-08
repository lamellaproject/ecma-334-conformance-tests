/*
Rules: E23-7-no-captured-parameter-array
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E23-7-no-captured-parameter-array/captured-params.cs.part
Mutate: fixed (int* pointer = items)
Into: fixed (int* pointer = independent)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    delegate int ReadValue();
    static unsafe void Read(params int[] items)
    {
        int[] independent = items;
        ReadValue callback = delegate { return items[0]; };
        fixed (int* pointer = items) { *pointer = 37; }
        Check(callback() == 37, "captured-array-initializer");
    }
    static int Main()
    {
        Read(11, 13);
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
