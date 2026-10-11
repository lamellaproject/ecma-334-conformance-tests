/*
Rules: E23-7-array-initializer
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: fixed (int** pointer = items)
Into: fixed (int** pointer = other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 41, decoy = 5;
        int*[] items = { &value };
        int*[] other = { &decoy };
        fixed (int** pointer = items)
        {
            Check(*pointer == &value, "pinned-pointer-element-address");
            Check(**pointer == 41, "pinned-pointer-element-value");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
