/*
Rules: P10-handler-concatenation; P10-handler-constructor; P10-handler-literal; P10-handler-formatted; P10-handler-result
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 5
Mutate: Capture item = $"x{Read('a')}" + $"y{Read('b')}";
Into: Capture item = $"x{Read('a')}" + $"yy{Read('b')}";
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public static int Constructions;
    public int Length, Holes;
    public string Text;
    public Capture(int length, int holes) { Constructions++; Length = length; Holes = holes; Text = ""; }
    public void AppendLiteral(string text) { Text += text; }
    public void AppendFormatted(char value) { Text += value; }
}
class Program
{
    static int checks, failures;
    static string reads = "";
    static char Read(char value) { reads += value; return value; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Capture item = $"x{Read('a')}" + $"y{Read('b')}";
        Check(Capture.Constructions == 1, "one-combined-instance");
        Check(item.Length == 2, "combined-literal-length");
        Check(item.Holes == 2, "combined-hole-count");
        Check(item.Text == "xayb", "combined-order");
        Check(reads == "ab", "hole-effects-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
