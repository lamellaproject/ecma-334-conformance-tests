/*
Rules: E12-8-13-struct-constructor-out; E12-8-13-struct-constructor-classification; E12-8-13-struct-constructor-type; E12-8-13-struct-constructor-instance
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Initialize(out this, value);
Into: this = default(Cell);
*/
using System;
struct Cell
{
    public int Value, Mirror;
    static void Initialize(out Cell cell, int value) { cell.Value = value; cell.Mirror = value + 1; }
    public Cell(int value) { Initialize(out this, value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell(17);
        Check(cell.Value == 17, "out-this-initializes-created-struct");
        Check(cell.Mirror == 18, "out-this-reaches-all-instance-fields");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
