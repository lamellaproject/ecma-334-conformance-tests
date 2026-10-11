/*
Rules: E15-9-1-nonref-indexer-readable-writable
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: set { Stored = index + value; }
Into: set { Stored = index - value; }
*/
using System;
class Grid { public int Stored; public int this[int index] { set { Stored = index + value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        grid[4] = 13;
        Check(grid.Stored == 17, "write-only-indexer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
