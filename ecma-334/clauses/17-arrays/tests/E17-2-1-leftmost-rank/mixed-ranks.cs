/*
Rules: E17-2-1-leftmost-rank; E17-2-1-remove-leftmost; E17-2-1-type-form
Authority: ECMA-334 7th ed 17.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int[,][] values
Into: int[][,] values
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,][] values = new int[2, 1][];
        int[] element = new int[3];
        values[1, 0] = element;
        Check(values.Rank == 2, "leftmost-rank");
        Check(values[1, 0] == element, "remove-leftmost-gives-vector");
        Check(values[1, 0].Length == 3, "element-rank-independent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
