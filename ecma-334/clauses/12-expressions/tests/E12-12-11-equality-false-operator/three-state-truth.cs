/*
Rules: E12-12-11-equality-false-operator; E12-12-11-inequality-true-operator
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
    public int State; public Truth(int state) { State = state; }
    public static bool operator true(Truth x) { Program.Trace += "T"; return x.State == 1; }
    public static bool operator false(Truth x) { Program.Trace += "F"; return x.State == 0; }
}
struct Number
{
    public int State; public Number(int state) { State = state; }
    public static Truth operator ==(Number x, Number y) { Program.Trace += "="; return new Truth(x.State); }
    public static Truth operator !=(Number x, Number y) { Program.Trace += "!"; return new Truth(x.State); }
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
        var left = (new Number(2), new Number(2)); var right = (new Number(9), new Number(9));
        bool result = left == right; Check(result && Trace == "=F=F", "equality-negates-false-even-when-not-true");
        Trace = ""; result = left != right; Check(!result && Trace == "!T!T", "inequality-invokes-true-even-when-not-false");
        Trace = ""; result = (new Number(0), new Number(2)) == right;
        Check(!result && Trace == "=F", "converted-false-short-circuits");
        Trace = ""; result = (new Number(1), new Number(2)) != right;
        Check(result && Trace == "!T", "converted-true-short-circuits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
