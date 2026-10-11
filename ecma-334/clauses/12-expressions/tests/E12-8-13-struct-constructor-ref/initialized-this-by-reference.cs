/*
Rules: E12-8-13-struct-constructor-ref; E12-8-13-struct-constructor-initial-assignment
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Touch(ref this);
Into: Touch(ref copy);
*/
using System;
struct Cell
{
    public int Value, Mirror;
    static void Touch(ref Cell value) { value.Mirror = value.Value + 1; value.Value = 12; }
    public Cell(int ignored) : this() { Cell copy = this; Touch(ref this); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell(0);
        Check(cell.Value == 12, "ref-this-updates-created-instance");
        Check(cell.Mirror == 1, "constructor-initializer-assigns-before-body-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
