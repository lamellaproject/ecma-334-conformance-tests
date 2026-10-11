/*
Rules: E12-15-dynamic-right-type; E12-15-dynamic-right-nonnull; E12-15-dynamic-right-null; E12-15-type-preference; E12-15-left-first
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Left(saved) ?? Right()
Into: Right()
*/
using System;
public class Base { public int Value; public Base(int v) { Value = v; } }
public class Derived : Base { public Derived(int v) : base(v) { } public int Only() { return Value; } }
public class Program
{
    static string trace = "";
    static Base Left(Base b) { trace += "L"; return b; }
    static dynamic Right() { trace += "R"; return new Derived(29); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Base saved = new Derived(7); var a = Left(saved) ?? Right();
        Check(a.Only() == 7 && object.ReferenceEquals((object)a, saved) && trace == "L", "dynamic-preferred-and-nonnull-conversion");
        trace = ""; var b = Left(null) ?? Right(); Check(b.Only() == 29 && trace == "LR", "dynamic-right-null-left");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
