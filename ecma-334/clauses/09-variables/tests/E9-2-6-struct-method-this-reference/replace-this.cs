/*
Rules: E9-2-6-struct-method-this-reference
Authority: ECMA-334 7th ed 9.2.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: this = replacement;
Into: replacement = this;
*/
using System;
struct Cell
{
    public int Value;
    public void Replace(Cell replacement) { this = replacement; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell { Value = 5 };
        cell.Replace(new Cell { Value = 43 });
        Check(cell.Value == 43, "this-writes-caller-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
