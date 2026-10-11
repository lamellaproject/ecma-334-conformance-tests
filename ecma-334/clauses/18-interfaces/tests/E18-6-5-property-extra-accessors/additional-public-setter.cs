/*
Rules: E18-6-5-property-extra-accessors
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: get { return stored; } set { stored = value; }
Into: get { return stored; }
*/
using System;
interface IRead { int Value { get; } }
class Cell : IRead
{
    int stored;
    public int Value { get { return stored; } set { stored = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell();
        cell.Value = 337;
        IRead reader = cell;
        Check(reader.Value == 337, "extra-public-property-accessor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
