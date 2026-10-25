/*
Rules: P10-handler-conversion; P10-handler-constructor; P10-handler-literal
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 5
Mutate: Capture full = $"ore";
Into: Capture full = new Capture(0, 0);
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public int Length, Holes;
    public string Text;
    public Capture(int length, int holes) { Length = length; Holes = holes; Text = ""; }
    public void AppendLiteral(string text) { Text += text; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        // Explicit custom targets construct handlers for constant, hole-free input.
        Capture full = $"ore";
        Capture empty = $"";
        Check(full.Length == 3, "literal-length");
        Check(full.Holes == 0, "literal-holes");
        Check(full.Text == "ore", "literal-appended");
        Check(empty.Length == 0 && empty.Holes == 0, "empty-counts");
        Check(empty.Text == "", "empty-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
