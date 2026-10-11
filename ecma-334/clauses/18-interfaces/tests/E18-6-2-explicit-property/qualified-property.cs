/*
Rules: E18-6-2-explicit-property
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int ICell.Value
Into: int IOther.Value
*/
using System;
interface ICell { int Value { get; set; } }
class Cell : ICell
{
    int value;
    int ICell.Value { get { return value; } set { this.value = value; } }
    public int Value { get { return 167; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell();
        ICell view = cell;
        view.Value = 173;
        Check(view.Value == 173, "explicit-property-accessors");
        Check(cell.Value == 167, "ordinary-property-independent");
        view.Value = 179;
        Check(view.Value == 179, "explicit-property-repeated-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
