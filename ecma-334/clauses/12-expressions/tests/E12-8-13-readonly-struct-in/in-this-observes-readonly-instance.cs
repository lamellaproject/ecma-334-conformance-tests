/*
Rules: E12-8-13-readonly-struct-in
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Observe(in this)
Into: Observe(in empty)
*/
using System;
readonly struct Cell
{
    public readonly int Value;
    public Cell(int value) { Value = value; }
    static int Observe(in Cell cell) { return cell.Value; }
    public int Read() { Cell empty = default(Cell); return Observe(in this); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell(28);
        Check(cell.Read() == 28, "readonly-this-is-readable-in-argument");
        Check(cell.Value == 28, "readonly-instance-remains-intact");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
