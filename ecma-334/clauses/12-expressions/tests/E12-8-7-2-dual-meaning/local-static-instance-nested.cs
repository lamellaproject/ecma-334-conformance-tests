/*
Rules: E12-8-7-2-dual-meaning; E12-8-7-2-static-access; E12-8-7-2-nested-type-access; E12-8-7-2-lookup-unambiguous
Authority: ECMA-334 7th ed 12.8.7.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Cell Cell = new Cell();
Into: Other Cell = new Other();
*/
using System;
class Cell
{
    public static int Value = 3;
    public int Read() { return 8; }
    public class Nested { public static int Value = 9; }
}
class Other
{
    public static int Value = 3;
    public int Read() { return 8; }
    public class Nested { public static int Value = 9; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell Cell = new Cell();
        int staticValue = Cell.Value;
        int instanceValue = Cell.Read();
        int nestedValue = Cell.Nested.Value;
        Check(staticValue == 3, "dual-local-name-allows-static-member");
        Check(instanceValue == 8, "dual-local-name-allows-instance-member");
        Check(nestedValue == 9, "dual-local-name-allows-nested-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
