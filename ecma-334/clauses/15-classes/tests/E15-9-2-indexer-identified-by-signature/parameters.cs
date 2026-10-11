/*
Rules: E15-9-2-indexer-identified-by-signature; E15-9-2-indexer-element-access; E15-9-2-indexer-get-parameters; E15-9-2-indexer-set-index-parameters; E15-9-2-indexer-set-value-parameter
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Stored = value;
Into: Stored = value + 1;
*/
using System;
class Grid
{
    public int Row, Column, Stored;
    public int this[int row, int column]
    {
        get { Row = row; Column = column; return row * 10 + column; }
        set { Row = row; Column = column; Stored = value; row = 0; column = 0; value = 0; }
    }
    public int this[string index] => 37;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        int row = 2, column = 8, value = 41;
        grid[row, column] = value;
        Check(grid.Row == 2 && grid.Column == 8 && grid.Stored == 41, "setter-index-and-value-parameters");
        Check(row == 2 && column == 8 && value == 41, "setter-parameters-by-value");
        Check(grid[3, 7] == 37 && grid.Row == 3 && grid.Column == 7, "getter-index-parameters");
        Check(grid["east"] == 37, "signature-selects-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
