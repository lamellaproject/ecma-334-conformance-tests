/*
Rules: E15-9-1-indexer-expression-equivalence; E15-9-1-grammar-indexer-body-form-2; E15-9-1-nonref-indexer-readable-writable
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: => Read(index);
Into: => Read(index + 1);
*/
using System;
class Grid
{
    public int Reads;
    int Read(int index) { Reads++; if (index < 0) throw new InvalidOperationException(); return index * 3 + 1; }
    public int this[int index] => Read(index);
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        Check(grid[4] == 13 && grid.Reads == 1, "expression-result-and-side-effect");
        bool expected = false;
        try { int ignored = grid[-1]; }
        catch (InvalidOperationException) { expected = true; }
        catch (Exception) { }
        Check(expected && grid.Reads == 2, "expression-exception-propagates");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
