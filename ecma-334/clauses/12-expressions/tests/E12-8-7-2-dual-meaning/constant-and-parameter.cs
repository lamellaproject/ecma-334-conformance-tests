/*
Rules: E12-8-7-2-dual-meaning; E12-8-7-2-static-access
Authority: ECMA-334 7th ed 12.8.7.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static int Parameter(Cell Cell) { return Cell.Value; }
Into: static int Parameter(Cell Cell) { return Cell.Read(); }
*/
using System;
class Cell { public static int Value = 3; public int Read() { return 8; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Parameter(Cell Cell) { return Cell.Value; }
    static int Constant() { const Cell Cell = null; return Cell.Value; }
    static void Main()
    {
        Check(Parameter(null) == 3, "dual-parameter-name-allows-static-member-with-null-value");
        Check(Constant() == 3, "dual-constant-name-allows-static-member-with-null-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
