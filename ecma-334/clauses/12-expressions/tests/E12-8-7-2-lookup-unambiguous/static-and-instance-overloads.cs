/*
Rules: E12-8-7-2-lookup-unambiguous; E12-8-7-2-dual-meaning; E12-8-7-2-static-access
Authority: ECMA-334 7th ed 12.8.7.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Cell.Pick(3)
Into: Cell.Pick("label")
*/
using System;
class Cell
{
    public static int Pick(int value) { return 3; }
    public int Pick(string value) { return 8; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell Cell = new Cell();
        int staticValue = Cell.Pick(3);
        int instanceValue = Cell.Pick("label");
        Check(staticValue == 3, "dual-meaning-lookup-selects-static-overload");
        Check(instanceValue == 8, "dual-meaning-lookup-selects-instance-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
