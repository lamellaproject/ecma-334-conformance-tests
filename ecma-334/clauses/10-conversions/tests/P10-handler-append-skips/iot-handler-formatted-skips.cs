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
    public int Number, Parts;
    public Capture(int length, int holes) { Program.Trace += "C"; Number = Parts = 0; }
    public bool AppendLiteral(string text) { Program.Trace += "L"; Parts++; return true; }
    public bool AppendFormatted(int value) { Program.Trace += "F"; Number = value; Parts++; return false; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures, holes;
    static Capture observed;
    static int Hole() { Trace += "H"; return ++holes; }
    static void Accept(Capture item) { Trace += "M"; observed = item; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Accept($"{Hole()}b{Hole()}");
        Check(Trace == "CHFM", "formatted-false-stops-sequence");
        Check(holes == 1, "only-current-hole-evaluated");
        Check(observed.Number == 1, "current-value-preserved");
        Check(observed.Parts == 1, "later-literal-and-hole-skipped");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
