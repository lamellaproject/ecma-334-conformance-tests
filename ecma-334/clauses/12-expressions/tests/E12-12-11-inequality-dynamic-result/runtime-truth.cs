/*
Rules: E12-12-11-inequality-dynamic-result
Authority: ECMA-334 7th ed 12.12.11
Version: 7.3
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/runtime-truth-4415eb14ff.cs.part
Mutate: left != right
Into: true
*/
using System;
public class Truth
{
    public int State; public Truth(int state) { State = state; }
    public static bool operator true(Truth x) { Program.Trace += "T"; return x.State == 1; }
    public static bool operator false(Truth x) { Program.Trace += "F"; return x.State == 0; }
}
public struct Number
{
    public int State; public Number(int state) { State = state; }
    public static dynamic operator ==(Number x, Number y) { Program.Trace += "="; return new Truth(x.State); }
    public static dynamic operator !=(Number x, Number y) { Program.Trace += "!"; return new Truth(x.State); }
    public override bool Equals(object x) { return false; }
    public override int GetHashCode() { return 0; }
}
public class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var left = (new Number(2), new Number(2)); var right = (new Number(9), new Number(9));
        bool result = left != right; Check(!result && Trace == "!T!T", "dynamic-true-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
