/*
Rules: E12-6-6-1-value-copy; E12-6-6-1-value-invoke
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: readonly struct Cell
Into: struct Cell
*/
using System;
unsafe readonly struct Cell
{
    public readonly int value;
    public Cell(int value) { this.value = value; }
    public bool Same(Cell* expected)
    {
        fixed (Cell* actual = &this) { return actual == expected; }
    }
}
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Invoke(in Cell receiver)
    {
        fixed (Cell* original = &receiver) { return receiver.Same(original); }
    }
    static void Main()
    {
        Cell original = new Cell(3);
        bool result = Invoke(in original);
        Check(result, "readonly-struct-input-receiver-is-not-defensively-copied");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
