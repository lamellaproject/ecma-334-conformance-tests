/*
Rules: E12-15-underlying-type; E12-15-underlying-nonnull; E12-15-underlying-null; E12-15-type-preference; E12-15-operator-name; E12-15-form-conditional-or; E12-15-form-coalescing; E12-15-nonnull-left; E12-15-null-left; E12-15-conditional-right; E12-15-left-first
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Left(7) ?? Right()
Into: Left(7)
*/
using System;
class Raw
{
    public static implicit operator int(Raw x) { Program.Trace += "C"; return 29; }
}
class Program
{
    public static string Trace = "";
    static int? Left(int? n) { Trace += "L"; return n; }
    static Raw Right() { Trace += "R"; return new Raw(); }
    static int Kind(int n) { return 1; } static int Kind(int? n) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var a = Left(7) ?? Right(); Check(a == 7 && Kind(a) == 1 && Trace == "L", "underlying-preferred-over-nullable");
        Trace = ""; var b = Left(null) ?? Right(); Check(b == 29 && Kind(b) == 1 && Trace == "LRC", "null-left-evaluates-and-converts-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
