/*
Rules: E15-9-1-grammar-indexer-declarator-form-2
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int IGrid.this[int index]
Into: int this[int index]
*/
using System;
interface IGrid { int this[int index] { get; set; } }
class Grid : IGrid { int stored; int IGrid.this[int index] { get { return stored + index; } set { stored = value - index; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IGrid grid = new Grid();
        grid[3] = 17;
        Check(grid[3] == 17, "explicit-indexer-write-read");
        Check(grid[7] == 21, "explicit-indexer-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
