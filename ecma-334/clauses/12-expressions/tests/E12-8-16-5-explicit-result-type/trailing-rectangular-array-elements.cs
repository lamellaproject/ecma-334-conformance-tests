/*
Rules: E12-8-16-5-explicit-result-type; E12-8-16-5-explicit-dimensions-form; E12-8-16-5-array-element-arrays; E12-8-16-5-subarray-initialization
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int[][,] pages = new int[2][,];
Into: int[][,] pages = new int[][,] { new int[1, 1], new int[1, 1] };
*/
using System;
class Program
{
    static int Choose(int[][,] value) { return 1; }
    static int Choose(object value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[][,] pages = new int[2][,];
        Check(Choose(pages) == 1, "trailing-rank-result-type");
        Check(pages.Length == 2 && pages[0] == null && pages[1] == null, "subarrays-not-created");
        pages[0] = new int[1, 3];
        pages[0][0, 2] = 23;
        Check(pages[0][0, 2] == 23, "manual-subarray-initialization");
        Check(pages[1] == null, "other-subarray-stays-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
