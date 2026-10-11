/*
Rules: E12-18-value-form; E12-18-name; E12-18-one-arm-only; E12-18-value-condition-first; E12-18-value-true-arm; E12-18-value-false-arm; E12-18-condition-bool; E12-22-conditional-form
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Pick(true) ? MakeSource() : MakeTarget()
Into: Pick(true) ? MakeTarget() : MakeTarget()
*/
using System;
class Target { public int Value; public Target(int value) { Value = value; } }
struct Source
{
    public static implicit operator Target(Source value)
    { Program.Trace += "C"; return Program.Converted; }
}
class Program
{
    public static string Trace = "";
    public static Target Converted = new Target(17);
    static Target Existing = new Target(29);
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Pick(bool value) { Trace += "B"; return value; }
    static Source MakeSource() { Trace += "S"; return new Source(); }
    static Target MakeTarget() { Trace += "Y"; return Existing; }
    static void Main()
    {
        Target first = Pick(true) ? MakeSource() : MakeTarget();
        Check(Trace == "BSC", "true-condition-arm-conversion-order");
        Check(object.ReferenceEquals(first, Converted) && first.Value == 17, "true-converted-result");
        Trace = "";
        Target second = Pick(false) ? MakeSource() : MakeTarget();
        Check(Trace == "BY", "false-only-selected-arm");
        Check(object.ReferenceEquals(second, Existing), "false-result-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
