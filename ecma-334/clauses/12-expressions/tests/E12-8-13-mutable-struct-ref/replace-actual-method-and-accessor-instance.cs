/*
Rules: E12-8-13-mutable-struct-ref; E12-8-13-struct-member-classification; E12-8-13-struct-member-type; E12-8-13-struct-direct-instance
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Replace(ref this, value);
Into: Replace(ref copy, value);
*/
using System;
struct Cell
{
    public int Value;
    public Cell(int value) { Value = value; }
    static void Replace(ref Cell cell, int value) { cell = new Cell(value); }
    public void Change(int value) { Cell copy = this; Replace(ref this, value); }
    public int Slot { get { Cell copy = this; return copy.Value; } set { Replace(ref this, value + 1); } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell(3);
        cell.Change(14);
        Check(cell.Value == 14, "method-ref-this-replaces-actual-receiver");
        cell.Slot = 20;
        Check(cell.Value == 21, "accessor-ref-this-replaces-actual-receiver");
        Check(cell.Slot == 21, "accessor-this-has-struct-instance-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
