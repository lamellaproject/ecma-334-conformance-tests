/*
Rules: E15-9-1-ref-indexer-variable-reference; E15-9-1-grammar-indexer-declaration-form-2; E15-9-1-grammar-ref-indexer-body-form-1; E15-9-1-ref-indexer-statement-get; E15-9-1-ref-indexer-get-execution
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return ref cells[index];
Into: return ref cells[index + 1];
*/
using System;
class Grid
{
    public int[] cells = { 4, 8, 12, 16 };
    public int Reads;
    public ref int this[int index] { get { Reads++; return ref cells[index]; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        ref int alias = ref grid[1];
        Check(alias == 8 && grid.Reads == 1, "ref-get-block");
        alias = 27;
        Check(grid.cells[1] == 27 && grid.Reads == 1, "alias-writes-storage");
        grid[2] = 39;
        Check(grid.cells[2] == 39 && grid.Reads == 2, "write-through-getter-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
