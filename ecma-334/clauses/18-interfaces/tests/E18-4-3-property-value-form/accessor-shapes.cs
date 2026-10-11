/*
Rules: E18-4-3-property-value-form; E18-4-3-accessor-get; E18-4-3-accessor-set; E18-4-3-accessor-get-set; E18-4-3-accessor-set-get; E18-4-3-class-component-meaning; E18-4-3-class-accessor-meaning; E18-4-3-accessor-availability; E18-4-1-member-property
Authority: ECMA-334 7th ed 18.4.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int Forward { [Mark] get; [Mark] set; }
Into: int Forward { [Mark] get; }
*/
using System;
class MarkAttribute : Attribute { }
interface ICell
{
    [Mark] int ReadOnly { [Mark] get; }
    int WriteOnly { [Mark] set; }
    int Forward { [Mark] get; [Mark] set; }
    int Reverse { [Mark] set; [Mark] get; }
}
class Cell : ICell
{
    public int Stored;
    public int ReadOnly { get { return Stored; } }
    public int WriteOnly { set { Stored = value; } }
    public int Forward { get; set; }
    public int Reverse { get; set; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell();
        ICell view = cell;
        view.WriteOnly = 73;
        Check(view.ReadOnly == 73, "write-only-and-read-only");
        Check(cell.Stored == 73, "setter-value");
        view.Forward = 79;
        view.Reverse = 83;
        Check(view.Forward == 79, "get-set-order");
        Check(view.Reverse == 83, "set-get-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
