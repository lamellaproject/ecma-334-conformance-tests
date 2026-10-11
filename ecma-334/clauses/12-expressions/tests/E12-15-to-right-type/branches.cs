/*
Rules: E12-15-to-right-type; E12-15-to-right-nonnull; E12-15-to-right-null; E12-15-type-preference
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Left(new Value(7)) ?? Right()
Into: Right()
*/
using System;
class Box { public int N; public Box(int n) { N = n; } }
class Value
{
    public int N; public Value(int n) { N = n; }
    public static implicit operator Box(Value v) { Program.Trace += "C"; return new Box(v.N); }
}
class Program
{
    public static string Trace = "";
    static Value Left(Value v) { Trace += "L"; return v; }
    static Box Right() { Trace += "R"; return new Box(29); }
    static int Kind(Box v) { return 1; } static int Kind(object v) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var a = Left(new Value(7)) ?? Right(); Check(a.N == 7 && Kind(a) == 1 && Trace == "LC", "nonnull-left-converted-to-right-type");
        Trace = ""; var b = Left(null) ?? Right(); Check(b.N == 29 && Kind(b) == 1 && Trace == "LR", "null-left-skips-user-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
