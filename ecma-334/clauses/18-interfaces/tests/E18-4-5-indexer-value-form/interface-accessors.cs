/*
Rules: E18-4-5-indexer-value-form; E18-4-5-class-component-meaning; E18-4-5-class-accessor-meaning; E18-4-5-accessor-availability; E18-4-1-member-indexer; E18-4-6-indexer-access-form
Authority: ECMA-334 7th ed 18.4.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: [Mark] int this[int index] { get; set; }
Into: [Mark] int this[int index] { get; }
*/
using System;
class MarkAttribute : Attribute { }
interface ICells { [Mark] int this[int index] { get; set; } }
class Cells : ICells
{
    public int Reads, Writes, Index;
    int[] values = new int[3];
    public int this[int index]
    {
        get { Reads++; Index = index; return values[index]; }
        set { Writes++; Index = index; values[index] = value; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cells cells = new Cells();
        ICells view = cells;
        view[2] = 109;
        Check(cells.Writes == 1 && cells.Index == 2, "interface-indexer-write-parameter");
        Check(view[2] == 109, "interface-indexer-read");
        Check(cells.Reads == 1 && cells.Index == 2, "interface-indexer-read-parameter");
        Check(view[0] == 0, "independent-indexer-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
