/*
Rules: E17-7-zero-following-dimensions
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: { { }, { } }
Into: { { { 9 } }, { { 8 } } }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,,] middleEmpty = { { }, { } };
        int[,,] outerEmpty = { };
        Check(middleEmpty.GetLength(0) == 2, "nonzero-left");
        Check(middleEmpty.GetLength(1) == 0 && middleEmpty.GetLength(2) == 0, "empty-middle-implies-empty-right");
        Check(outerEmpty.GetLength(0) == 0 && outerEmpty.GetLength(1) == 0, "empty-left-implies-empty-middle");
        Check(outerEmpty.GetLength(2) == 0 && outerEmpty.Length == 0, "empty-left-implies-empty-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
