/*
Rules: E12-14-3-or-left-evaluation; E12-14-3-or-true-test; E12-14-3-or-short-result; E12-14-3-or-right-evaluation; E12-14-3-or-operator-result; E12-14-3-left-once; E12-14-3-right-at-most-once; E12-14-1-or-resolution; E12-14-1-user-defined-dispatch; E12-14-1-regular-overload-support; E12-14-1-or-short-circuit; E12-14-1-or-correspondence
Authority: ECMA-334 7th ed 12.14
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Take(left, "L") || Take(right, "R")
Into: Take(left, "L") | Take(right, "R")
*/
using System;
class Flag
{
    public int Value; public Flag(int v) { Value = v; }
    public static bool operator true(Flag x) { Program.Trace += "T"; return x.Value == 1; }
    public static bool operator false(Flag x) { Program.Trace += "F"; return x.Value == 0; }
    public static Flag operator |(Flag x, Flag y) { Program.Trace += "|"; return new Flag(x.Value * 10 + y.Value); }
    public static Flag operator |(Flag x, object y) { throw new Exception(); }
}
class Program
{
    public static string Trace = "";
    static Flag Take(Flag x, string id) { Trace += id; return x; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Flag left = new Flag(1), right = new Flag(0); Flag a = Take(left, "L") || Take(right, "R");
        Check(object.ReferenceEquals(a, left) && Trace == "LT", "definite-true-preserves-left-identity");
        Trace = ""; Flag b = Take(new Flag(0), "L") || Take(new Flag(1), "R");
        Check(b.Value == 1 && Trace == "LTR|", "not-true-evaluates-once-and-selects-or");
        Trace = ""; Flag c = Take(new Flag(2), "L") || Take(new Flag(1), "R");
        Check(c.Value == 21 && Trace == "LTR|", "neither-true-nor-false-does-not-short-circuit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
