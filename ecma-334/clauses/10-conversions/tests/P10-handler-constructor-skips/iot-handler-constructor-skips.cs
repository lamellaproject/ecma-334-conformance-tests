/*
Rules: P10-handler-constructor-skips; P10-handler-arguments; P10-handler-result
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 8
Mutate: shouldAppend = enabled;
Into: shouldAppend = true;
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public int Parts;
    public Capture(int length, int holes, bool enabled, out bool shouldAppend)
    {
        Program.Trace += "C"; Parts = 0; shouldAppend = enabled;
    }
    public void AppendLiteral(string text) { Program.Trace += "L"; Parts++; }
    public void AppendFormatted(int value) { Program.Trace += "F"; Parts++; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures, holes, calls, parts;
    static bool Enabled(bool value) { Trace += "E"; return value; }
    static int Hole() { Trace += "H"; holes++; return 4; }
    static int Tail() { Trace += "T"; return 7; }
    static void Accept(bool enabled, [InterpolatedStringHandlerArgument("enabled")] Capture item, int tail) { Trace += "M"; calls++; parts = item.Parts; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Accept(Enabled(false), $"k{Hole()}z", Tail());
        Check(Trace == "ECTM", "false-constructor-skips-content");
        Check(holes == 0, "false-no-hole-effects");
        Check(parts == 0, "false-no-append-calls");
        Check(calls == 1, "false-still-invokes-method");
        Trace = "";
        Accept(Enabled(true), $"k{Hole()}z", Tail());
        Check(Trace == "ECLHFLTM", "true-content-before-tail");
        Check(holes == 1, "true-hole-once");
        Check(parts == 3, "true-append-count");
        Check(calls == 2, "true-still-invokes-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
