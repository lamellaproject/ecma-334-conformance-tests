/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: get => stored + index;
Into: get => stored - index;
*/
using System;
class Grid { int stored; public int this[int index] { get => stored + index; set => stored = value + index; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        grid[3] = 12;
        Check(grid[2] == 17, "expression-get-and-set-accessors");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
