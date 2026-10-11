/*
Rules: E12-8-16-5-array-instance; E12-8-16-1-array-form; E12-8-16-5-explicit-dimensions-form; E12-8-16-5-dimension-length; E12-8-16-5-array-reference; E12-8-16-5-allocation
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int[,] second = new int[2, 3];
Into: int[,] second = first;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int rows = 2, columns = 3;
        int[,] first = new int[rows, columns];
        int[,] second = new int[2, 3];
        Check(first != null && second != null, "array-references");
        Check(!object.ReferenceEquals(first, second), "fresh-array-instances");
        Check(first.GetLength(0) == rows && first.GetLength(1) == columns, "dimension-values");
        first[1, 2] = 17;
        Check(first[1, 2] == 17 && second[1, 2] == 0, "independent-array-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
