/*
Rules: E12-18-ref-condition-true-invocation; E12-18-ref-condition-first; E12-18-ref-true-arm; E12-18-ref-false-arm; E12-18-condition-true
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Make(true) ? ref Left() : ref Right()
Into: true ? ref Left() : ref Right()
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
    static int left = 19, right = 31;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Gate Make(bool value) { Trace += "B"; return new Gate(value); }
    static ref int Left() { Trace += "L"; return ref left; }
    static ref int Right() { Trace += "R"; return ref right; }
    static void Main()
    {
        ref int first = ref (Make(true) ? ref Left() : ref Right());
        Check(Trace == "BTL", "operator-true-before-left-reference");
        first = 43;
        Check(left == 43 && right == 31, "operator-true-true-alias");
        Trace = "";
        ref int second = ref (Make(false) ? ref Left() : ref Right());
        Check(Trace == "BTR", "operator-true-before-right-reference");
        second = 53;
        Check(left == 43 && right == 53, "operator-true-false-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
