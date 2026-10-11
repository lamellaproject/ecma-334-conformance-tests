/*
Rules: E12-8-16-5-dimension-conversion-target; E12-8-16-5-dimension-expression-type
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: implicit operator int
Into: explicit operator int
*/
using System;
struct Length
{
    public static implicit operator int(Length value) { Program.Trace += "i"; return 2; }
    public static implicit operator uint(Length value) { Program.Trace += "u"; return 3; }
    public static implicit operator long(Length value) { Program.Trace += "l"; return 4; }
    public static implicit operator ulong(Length value) { Program.Trace += "v"; return 5; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new int[new Length()];
        Check(Trace == "i", "int-is-first-conversion");
        Check(cells.Length == 2, "int-conversion-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
