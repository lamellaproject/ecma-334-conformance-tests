/*
Rules: E17-7-dimension-order; E17-7-dimension-lengths; E17-7-nested-form
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: { { 2, 5, 8 }, { 11, 14, 17 } }
Into: { { 2, 11 }, { 5, 14 }, { 8, 17 } }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] values = { { 2, 5, 8 }, { 11, 14, 17 } };
        Check(values.GetLength(0) == 2, "outer-is-left-dimension");
        Check(values.GetLength(1) == 3, "inner-is-right-dimension");
        Check(values[0, 2] == 8, "left-row-right-column");
        Check(values[1, 0] == 11, "next-row-first-column");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
