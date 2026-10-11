/*
Rules: E12-8-11-3-exclude-inaccessible; E12-8-11-3-best-indexer
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private int this[int index]
Into: public int this[int index]
*/
using System;
class Cell
{
    private int this[int index] { get { return 1; } }
    public int this[object index] { get { return 2; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell receiver = new Cell();
        Check(receiver[5] == 2, "inaccessible-exact-match-excluded-before-overload-resolution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
