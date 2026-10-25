/*
Rules: P10-handler-append-skips
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: return false;
Into: return true;
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public int Parts;
    public Capture(int length, int holes) { Program.Trace += "C"; Parts = 0; }
    public bool AppendLiteral(string text) { Program.Trace += "L"; Parts++; return false; }
    public bool AppendFormatted(int value) { Program.Trace += "F"; Parts++; return true; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures, holes, parts;
    static int Hole() { Trace += "H"; holes++; return 3; }
    static void Accept(Capture item) { Trace += "M"; parts = item.Parts; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Accept($"a{Hole()}b{Hole()}");
        Check(Trace == "CLM", "literal-false-stops-sequence");
        Check(holes == 0, "following-holes-not-evaluated");
        Check(parts == 1, "only-first-literal-appended");
        Check(Trace.EndsWith("M"), "method-still-called");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
