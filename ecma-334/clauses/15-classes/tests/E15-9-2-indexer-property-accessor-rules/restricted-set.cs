/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private set { stored = value + index; }
Into: private set { stored = value - index; }
*/
using System;
class Grid
{
    int stored;
    public int this[int index] { get { return stored + index; } private set { stored = value + index; } }
    public void Assign() { this[3] = 11; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        grid.Assign();
        Check(grid[5] == 19, "private-set-public-get");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
