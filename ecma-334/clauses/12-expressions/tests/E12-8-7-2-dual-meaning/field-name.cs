/*
Rules: E12-8-7-2-dual-meaning; E12-8-7-2-static-access
Authority: ECMA-334 7th ed 12.8.7.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return Cell.Value;
Into: return Cell.Read();
*/
using System;
class Cell { public static int Value = 3; public int Read() { return 8; } }
class Owner
{
    public Cell Cell = new Cell();
    public int Resolve() { return Cell.Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Owner().Resolve() == 3, "dual-field-name-allows-static-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
