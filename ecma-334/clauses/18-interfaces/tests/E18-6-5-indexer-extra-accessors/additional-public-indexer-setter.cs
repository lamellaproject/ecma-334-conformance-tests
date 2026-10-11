/*
Rules: E18-6-5-indexer-extra-accessors
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: get { return values[index]; } set { values[index] = value; }
Into: get { return values[index]; }
*/
using System;
interface IRead { int this[int index] { get; } }
class Cells : IRead
{
    int[] values = new int[2];
    public int this[int index] { get { return values[index]; } set { values[index] = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cells cells = new Cells();
        cells[1] = 367;
        IRead reader = cells;
        Check(reader[1] == 367, "extra-public-indexer-accessor");
        Check(reader[0] == 0, "extra-accessor-target-index");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
