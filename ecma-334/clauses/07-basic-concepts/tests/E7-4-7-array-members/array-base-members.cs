/*
Rules: E7-4-7-array-members
Authority: ECMA-334 7th ed 7.4.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int[] values = new int[] { 17, 23 };
Into: object values = new int[] { 17, 23 };
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[] { 17, 23 };
        Array basis = values;
        Check(values.GetLength(0) == 2 && values.Rank == 1, "inherited-array-dimensions");
        Check((int)basis.GetValue(1) == 23, "array-base-member-on-same-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
