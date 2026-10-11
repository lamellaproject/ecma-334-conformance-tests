/*
Rules: E12-13-1-dynamic-binding; E12-13-1-dynamic-result-type; E12-13-1-dynamic-runtime-resolution
Authority: ECMA-334 7th ed 12.13.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Number(4) | right
Into: new Number(4) | (object)right
*/
using System;
public class Box { public int Value; public Box(int v) { Value = v; } }
public class Number
{
    public int Value; public Number(int v) { Value = v; }
    public static object operator |(Number x, Number y) { Program.Trace += "N"; return new Box(x.Value * 3 + y.Value); }
    public static object operator |(Number x, object y) { Program.Trace += "O"; return new Box(-1); }
}
public class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic right = new Number(5); var result = new Number(4) | right;
        Check(result.Value == 17 && Trace == "N", "dynamic-or-runtime-overload-and-result-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
