/*
Rules: E12-12-11-equality-bool-conversion; E12-12-11-inequality-bool-conversion
Authority: ECMA-334 7th ed 12.12.11
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: left == right
Into: left != right
*/
using System;
struct Truth
{
    public bool Value; public Truth(bool v) { Value = v; }
    public static implicit operator bool(Truth x) { Program.Trace += "C"; return x.Value; }
    public static bool operator true(Truth x) { Program.Trace += "T"; return x.Value; }
    public static bool operator false(Truth x) { Program.Trace += "F"; return !x.Value; }
}
struct Number
{
    public int Value; public Number(int v) { Value = v; }
    public static Truth operator ==(Number x, Number y) { Program.Trace += "="; return new Truth(x.Value == y.Value); }
    public static Truth operator !=(Number x, Number y) { Program.Trace += "!"; return new Truth(x.Value != y.Value); }
    public override bool Equals(object x) { return false; }
    public override int GetHashCode() { return 0; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var left = (new Number(1), new Number(2)); var right = (new Number(1), new Number(2));
        bool result = left == right; Check(result, "equality-converted-to-bool");
        Check(Trace == "=C=C", "implicit-conversion-before-false-operator");
        Trace = ""; result = left != right; Check(!result, "inequality-converted-to-bool");
        Check(Trace == "!C!C", "implicit-conversion-before-true-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
