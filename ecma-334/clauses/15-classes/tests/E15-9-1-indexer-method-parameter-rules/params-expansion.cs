/*
Rules: E15-9-1-indexer-method-parameter-rules
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: this[params int[] indices]
Into: this[int[] indices]
*/
using System;
class Grid { public int this[params int[] indices] { get { return indices.Length == 0 ? 0 : indices[0] + indices.Length; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        Check(grid[4] == 5, "expanded-single-index");
        Check(grid[4, 7, 9] == 7, "expanded-multiple-indices");
        Check(grid[new int[] { 6, 8 }] == 8, "normal-array-index");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
