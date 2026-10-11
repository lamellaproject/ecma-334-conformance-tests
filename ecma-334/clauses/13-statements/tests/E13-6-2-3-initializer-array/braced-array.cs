/*
Rules: E13-6-2-3-initializer-array; E13-6-2-3-explicit-initial-value
Authority: ECMA-334 7th ed 13.6.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: { 3, 8 }
Into: { 8, 3 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] data = { 3, 8 };
        Check(data.Length == 2 && data[0] == 3 && data[1] == 8, "local-array-initializer-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
