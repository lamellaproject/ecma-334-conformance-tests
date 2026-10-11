/*
Rules: E15-6-2-6-array-parameter-rank; E15-6-2-6-array-expanded-arguments
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static int[][] Gather(params int[][] values)
Into: static int[][] Gather(int[][] values)
*/
using System;
class Program
{
    static int[][] Gather(params int[][] values) { return values; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] first = new int[] { 3, 7 };
        int[] second = new int[] { 11 };
        int[][] result = Gather(first, second);
        Check(result.Length == 2, "jagged-array-has-single-dimensional-outer-array");
        Check(result[0] == first && result[1] == second, "expanded-jagged-elements-retain-array-references");
        Check(result[0][1] == 7 && result[1][0] == 11, "jagged-elements-preserve-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
