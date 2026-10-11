/*
Rules: E15-9-1-indexer-array-style; E15-9-1-grammar-indexer-declaration-form-1; E15-9-1-grammar-indexer-declarator-form-1; E15-9-1-grammar-indexer-body-form-1; E15-9-1-grammar-indexer-modifier-form-2; E15-9-1-nonref-indexer-value-type; E15-9-1-nonref-indexer-readable-writable; E15-9-1-indexer-element-type; E15-9-1-indexer-statement-accessors; E15-9-1-indexer-accessor-execution; E15-9-1-indexer-accessibility
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: cells[index] = value;
Into: cells[index] = value + 1;
*/
using System;
class Grid
{
    int[] cells = new int[4];
    public int Trace;
    public int this[int index]
    {
        get { Trace = Trace * 10 + 3; return cells[index]; }
        set { Trace = Trace * 10 + 7; cells[index] = value; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(int value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Grid grid = new Grid();
        grid[2] = 19;
        Check(grid.Trace == 7, "indexer-set-block");
        Check(grid[2] == 19 && grid.Trace == 73, "indexer-get-block");
        Check(Kind(grid[2]) == 1, "declared-int-element-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
