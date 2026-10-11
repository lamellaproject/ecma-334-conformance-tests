/*
Rules: E12-8-16-2-struct-temporary; E12-8-16-2-struct-constructor-call; E12-8-16-2-struct-constructor-this
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: current = new Cell(11);
Into: Cell.Replace(ref current, 11);
*/
using System;
struct Cell
{
    public int Value;
    public Cell(int value) { Program.Seen = Program.current.Value; this.Value = value; }
    public static void Replace(ref Cell target, int value)
    {
        target.Value = value;
        Program.Seen = Program.current.Value;
    }
}
class Program
{
    public static Cell current;
    public static int Seen;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        current.Value = 5;
        current = new Cell(11);
        Check(Seen == 5, "struct-constructor-uses-temporary");
        Check(current.Value == 11, "temporary-assigned-to-target-after-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
