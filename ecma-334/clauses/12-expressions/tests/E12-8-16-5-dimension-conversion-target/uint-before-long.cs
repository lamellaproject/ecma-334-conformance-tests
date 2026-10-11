/*
Rules: E12-8-16-5-dimension-conversion-target; E12-8-16-5-dimension-expression-type
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: implicit operator uint
Into: explicit operator uint
*/
using System;
struct Length
{
    public static implicit operator uint(Length value) { Program.Trace += "u"; return 2; }
    public static implicit operator long(Length value) { Program.Trace += "l"; return 3; }
    public static implicit operator ulong(Length value) { Program.Trace += "v"; return 4; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new int[new Length()];
        Check(Trace == "u", "uint-is-first-available-conversion");
        Check(cells.Length == 2, "uint-conversion-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
