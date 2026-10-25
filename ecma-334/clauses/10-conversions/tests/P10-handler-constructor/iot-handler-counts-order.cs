/*
Rules: P10-handler-constructor; P10-handler-literal; P10-handler-formatted
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 6
Mutate: Capture item = $"A{{{Read('u', 'a')}}}Z{Read('v', 'b')}";
Into: Capture item = $"A{{{Read('u', 'a')}}}ZZ{Read('v', 'b')}";
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public static int Constructions;
    public int Length, Holes;
    public string Text;
    public Capture(int length, int holes) { Constructions++; Length = length; Holes = holes; Text = ""; Program.Trace += "C"; }
    public void AppendLiteral(string text) { Program.Trace += "L"; Text += text; }
    public void AppendFormatted(char value) { Program.Trace += "F"; Text += value; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures, reads;
    static char Read(char value, char marker) { reads++; Trace += marker; return value; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Capture item = $"A{{{Read('u', 'a')}}}Z{Read('v', 'b')}";
        Check(item.Length == 4, "unescaped-literal-length");
        Check(item.Holes == 2, "hole-count");
        Check(Capture.Constructions == 1, "constructor-once");
        Check(reads == 2, "holes-once");
        Check(item.Text == "A{u}Zv", "unescaped-components");
        Check(Trace == "CLaFLbF", "construction-and-append-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
