/*
Rules: E12-6-2-3-empty-array; E12-6-2-3-empty-array-identity
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int[] first = Read();
Into: int[] first = Read(7);
*/
using System;
class Program
{
    static int checks, failures;
    static int[] Read(params int[] values) { return values; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] first = Read(); int[] second = Read();
        // Allocation and reuse are both permitted; no reference-identity oracle is imposed.
        Check(first != null && first.Length == 0, "first-empty-parameter-array");
        Check(second != null && second.Length == 0, "second-empty-parameter-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
