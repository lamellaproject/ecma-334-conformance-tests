/*
Rules: E12-8-16-5-inferred-dimensions; E12-8-16-5-explicit-type-initializer-form
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new int[,] { { 6, 9, 12 } }
Into: new int[,] { { 6, 9 }, { 12, 15 } }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new int[,] { { 6, 9, 12 } };
        Check(cells.GetLength(0) == 1 && cells.GetLength(1) == 3, "lengths-from-nesting");
        Check(cells[0, 0] == 6 && cells[0, 1] == 9, "omitted-length-element-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
