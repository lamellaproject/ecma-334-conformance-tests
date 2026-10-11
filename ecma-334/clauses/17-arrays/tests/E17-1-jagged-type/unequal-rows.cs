/*
Rules: E17-1-jagged-type; E17-1-jagged-distinct; E17-2-1-type-form; E17-1-element-types
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: new int[3]
Into: new int[1]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[][] rows = new int[2][];
        rows[0] = new int[1]; rows[1] = new int[3];
        Check(rows.Rank == 1 && rows.Length == 2, "outer-vector");
        Check(rows[0].Length == 1, "short-row");
        Check(rows[1].Length == 3, "long-row");
        object erased = rows;
        Check(erased is int[][] && !(erased is int[,]), "jagged-distinct-from-rectangle");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
