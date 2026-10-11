/*
Rules: E18-6-2-explicit-indexer
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int ICells.this[int index]
Into: int IOther.this[int index]
*/
using System;
interface ICells { int this[int index] { get; set; } }
class Cells : ICells
{
    int[] values = new int[2];
    int ICells.this[int index] { get { return values[index]; } set { values[index] = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ICells view = new Cells();
        view[1] = 181;
        Check(view[1] == 181, "explicit-indexer-write-read");
        Check(view[0] == 0, "explicit-indexer-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
