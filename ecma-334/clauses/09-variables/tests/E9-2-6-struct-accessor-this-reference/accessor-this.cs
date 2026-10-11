/*
Rules: E9-2-6-struct-accessor-this-reference
Authority: ECMA-334 7th ed 9.2.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this = new Cell { Value = value };
Into: this = new Cell { Value = 0 };
*/
using System;
struct Cell
{
    public int Value;
    public int Reading { get { return this.Value; } set { this = new Cell { Value = value }; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell { Value = 14 };
        Check(cell.Reading == 14, "getter-this-reads-caller");
        cell.Reading = 62;
        Check(cell.Value == 62, "setter-this-replaces-caller");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
