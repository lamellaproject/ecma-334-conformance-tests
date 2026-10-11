/*
Rules: E9-2-6-struct-initialized-constructor-this-reference
Authority: ECMA-334 7th ed 9.2.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Edit(ref this, value);
Into: Edit(ref this, 0);
*/
using System;
struct Cell
{
    public int Value, Before;
    public Cell(int value) : this() { Before = Value; Edit(ref this, value); }
    static void Edit(ref Cell cell, int value) { cell.Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell(71);
        Check(cell.Before == 0, "initialized-this-readable-before-assignment");
        Check(cell.Value == 71, "this-is-assigned-ref-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
