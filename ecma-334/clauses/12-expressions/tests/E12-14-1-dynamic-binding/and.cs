/*
Rules: E12-14-1-dynamic-binding; E12-14-1-dynamic-result-type; E12-14-1-dynamic-runtime-resolution
Authority: ECMA-334 7th ed 12.14.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Take(left, "L") && Take(right, "R")
Into: Take(left, "L") & Take(right, "R")
*/
using System;
public class Flag
{
    public int Value; public Flag(int v) { Value = v; }
    public static bool operator true(Flag x) { return x.Value == 1; }
    public static bool operator false(Flag x) { return x.Value == 0; }
    public static Flag operator &(Flag x, Flag y) { Program.Trace += "&"; return new Specific(x.Value * 10 + y.Value); }
    public static Flag operator &(Flag x, object y) { throw new Exception(); }
}
public class Specific : Flag { public Specific(int v) : base(v) { } public int Only() { return Value; } }
public class Program
{
    public static string Trace = "";
    static dynamic Take(object x, string id) { Trace += id; return x; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Flag left = new Specific(0); object right = new Specific(1); var a = Take(left, "L") && Take(right, "R");
        Check(a.Only() == 0 && object.ReferenceEquals((object)a, left) && Trace == "L", "dynamic-short-result-type-and-identity");
        Trace = ""; var b = Take(new Specific(2), "L") && Take(new Specific(1), "R");
        Check(b.Only() == 21 && Trace == "LR&", "dynamic-runtime-types-and-conditional-and");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
