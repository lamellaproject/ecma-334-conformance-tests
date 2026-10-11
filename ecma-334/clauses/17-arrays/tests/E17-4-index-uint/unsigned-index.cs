/*
Rules: E17-4-index-uint
Authority: ECMA-334 7th ed 17.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: uint index = 1
Into: uint index = 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[2]; uint index = 1;
        values[index] = 47;
        Check(values[1] == 47, "uint-selected-element");
        Check(values[0] == 0, "uint-other-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
