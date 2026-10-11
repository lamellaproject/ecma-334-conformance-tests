/*
Rules: E12-18-value-condition-conversion; E12-18-condition-bool; E12-18-value-condition-first; E12-18-one-arm-only
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Make(true) ? Left() : Right()
Into: Make(true).Value ? Left() : Right()
*/
using System;
struct Gate
{
    public bool Value;
    public Gate(bool value) { Value = value; }
    public static implicit operator bool(Gate value) { Program.Trace += "C"; return value.Value; }
    public static bool operator true(Gate value) { Program.Trace += "T"; return !value.Value; }
    public static bool operator false(Gate value) { Program.Trace += "F"; return value.Value; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Gate Make(bool value) { Trace += "B"; return new Gate(value); }
    static int Left() { Trace += "L"; return 11; }
    static int Right() { Trace += "R"; return 23; }
    static void Main()
    {
        int first = Make(true) ? Left() : Right();
        Check(first == 11, "implicit-bool-wins-over-true");
        Check(Trace == "BCL", "condition-conversion-then-true-arm");
        Trace = "";
        int second = Make(false) ? Left() : Right();
        Check(second == 23, "false-conversion-value");
        Check(Trace == "BCR", "condition-conversion-then-false-arm");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
