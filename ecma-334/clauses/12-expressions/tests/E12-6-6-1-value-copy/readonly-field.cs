/*
Rules: E12-6-6-1-value-copy; E12-6-6-1-value-copy-reclassification; E12-6-6-1-value-mutation-observable
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public readonly Cell cell
Into: public Cell cell
*/
using System;
struct Cell
{
    public int value;
    public int Advance(int amount) { value += amount; return value; }
}
class Owner
{
    public readonly Cell cell = new Cell { value = 3 };
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Owner owner = new Owner();
        int result = owner.cell.Advance(4);
        Check(result == 7, "readonly-field-copy-is-mutable-this");
        Check(owner.cell.value == 3, "readonly-field-retains-original-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
