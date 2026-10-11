/*
Rules: E15-9-1-ref-indexer-expression-equivalence; E15-9-1-grammar-ref-indexer-body-form-2
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: => ref cells[index];
Into: => ref cells[index + 1];
*/
using System;
class Grid { public int[] cells = { 6, 13, 20 }; public ref int this[int index] => ref cells[index]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        ref int alias = ref grid[1];
        Check(alias == 13, "ref-expression-read");
        alias = 44;
        Check(grid.cells[1] == 44, "ref-expression-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
