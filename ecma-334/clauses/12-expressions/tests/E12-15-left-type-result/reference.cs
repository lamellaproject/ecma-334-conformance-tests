/*
Rules: E12-15-left-type-result; E12-15-left-type-nonnull; E12-15-left-type-null; E12-15-type-preference
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Left(saved) ?? Right()
Into: Right()
*/
using System;
class Value { public int N; public Value(int n) { N = n; } }
class Raw
{
    public int N = 29;
    public static implicit operator Value(Raw x) { Program.Trace += "C"; return new Value(x.N); }
}
class Program
{
    public static string Trace = "";
    static Value Left(Value v) { Trace += "L"; return v; }
    static Raw Right() { Trace += "R"; return new Raw(); }
    static int Kind(Value v) { return 1; } static int Kind(Raw v) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Value saved = new Value(7); var a = Left(saved) ?? Right();
        Check(object.ReferenceEquals(a, saved) && Kind(a) == 1 && Trace == "L", "left-reference-preserved-without-conversion");
        Trace = ""; var b = Left(null) ?? Right(); Check(b.N == 29 && Kind(b) == 1 && Trace == "LRC", "right-converted-to-left-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
