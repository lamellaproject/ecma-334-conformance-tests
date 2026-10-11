/*
Rules: E17-4-index-ulong
Authority: ECMA-334 7th ed 17.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ulong index = 1
Into: ulong index = 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[2]; ulong index = 1;
        values[index] = 59;
        Check(values[1] == 59, "ulong-selected-element");
        Check(values[0] == 0, "ulong-other-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
