/*
Rules: E12-8-16-5-dimension-conversion-target; E12-8-16-5-dimension-expression-type
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: implicit operator ulong
Into: explicit operator ulong
*/
using System;
struct Length
{
    public static implicit operator ulong(Length value) { Program.Trace += "v"; return 2; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new int[new Length()];
        Check(Trace == "v", "ulong-is-available-conversion");
        Check(cells.Length == 2, "ulong-conversion-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
