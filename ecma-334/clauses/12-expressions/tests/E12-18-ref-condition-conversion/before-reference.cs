/*
Rules: E12-18-ref-condition-conversion; E12-18-ref-condition-first; E12-18-ref-true-arm; E12-18-ref-false-arm; E12-18-condition-bool
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Make(true) ? ref Left() : ref Right()
Into: Make(true).Value ? ref Left() : ref Right()
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
    static int left = 13, right = 29;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Gate Make(bool value) { Trace += "B"; return new Gate(value); }
    static ref int Left() { Trace += "L"; return ref left; }
    static ref int Right() { Trace += "R"; return ref right; }
    static void Main()
    {
        ref int first = ref (Make(true) ? ref Left() : ref Right());
        Check(Trace == "BCL", "ref-condition-conversion-before-left");
        first = 37;
        Check(left == 37 && right == 29, "conversion-true-reference");
        Trace = "";
        ref int second = ref (Make(false) ? ref Left() : ref Right());
        Check(Trace == "BCR", "ref-condition-conversion-before-right");
        second = 41;
        Check(left == 37 && right == 41, "conversion-false-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
