/*
Rules: E15-9-1-ref-indexer-readonly-reference
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: => ref cells[index];
Into: => ref cells[index + 1];
*/
using System;
class Grid { public int[] cells = { 3, 11, 19 }; public ref readonly int this[int index] => ref cells[index]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        ref readonly int alias = ref grid[1];
        Check(alias == 11, "readonly-reference-initial-value");
        grid.cells[1] = 23;
        Check(alias == 23, "readonly-reference-retains-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
