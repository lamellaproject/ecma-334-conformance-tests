/*
Rules: E13-9-5-array-multiple-dimension-order
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: foreach (int value in grid)
Into: foreach (int value in new int[] { 1, 4, 2, 5, 3, 6 })
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
        int trace = 0;
        foreach (int value in grid) { trace = trace * 10 + value; }
        Check(trace == 123456, "rightmost-index-varies-first");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
