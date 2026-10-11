/*
Rules: E12-18-value-condition-true-invocation; E12-18-condition-true; E12-18-value-condition-first; E12-18-one-arm-only
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Make(true) ? Left() : Right()
Into: true ? Left() : Right()
*/
using System;
struct Gate
{
    public bool Value;
    public Gate(bool value) { Value = value; }
    public static bool operator true(Gate value) { Program.Trace += "T"; return value.Value; }
    public static bool operator false(Gate value) { Program.Trace += "F"; return !value.Value; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Gate Make(bool value) { Trace += "B"; return new Gate(value); }
    static int Left() { Trace += "L"; return 31; }
    static int Right() { Trace += "R"; return 47; }
    static void Main()
    {
        int first = Make(true) ? Left() : Right();
        Check(first == 31, "operator-true-selects-left");
        Check(Trace == "BTL", "true-invoked-once-before-left");
        Trace = "";
        int second = Make(false) ? Left() : Right();
        Check(second == 47, "operator-true-selects-right");
        Check(Trace == "BTR", "true-invoked-once-before-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
