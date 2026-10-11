/*
Rules: E12-13-1-overload-resolution; E12-13-1-operand-conversions; E12-13-1-result-type
Authority: ECMA-334 7th ed 12.13.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Left() | Right()
Into: Left() & Right()
*/
using System;
class Operand
{
    public int Value; public Operand(int v) { Value = v; }
    public static implicit operator Number(Operand x) { Program.Trace += "C"; return new Number(x.Value); }
}
class Result { public int Value; public Result(int v) { Value = v; } }
class Number
{
    public int Value; public Number(int v) { Value = v; }
    public static Result operator |(Number x, Number y) { Program.Trace += "|"; return new Result(x.Value * 7 + y.Value); }
    public static Result operator |(Number x, object y) { Program.Trace += "W"; return new Result(-1); }
    public static Result operator &(Number x, Number y) { Program.Trace += "&"; return new Result(0); }
}
class Program
{
    public static string Trace = "";
    static Number Left() { Trace += "L"; return new Number(3); }
    static Operand Right() { Trace += "R"; return new Operand(5); }
    static int Kind(Result x) { return 1; } static int Kind(object x) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = Left() | Right();
        Check(result.Value == 26 && Kind(result) == 1 && Trace == "LRC|", "selected-operator-conversion-and-static-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
