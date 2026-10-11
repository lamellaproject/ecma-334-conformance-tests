/*
Rules: E10-5-5-target-exact
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static explicit operator short(Packet x) { Trace.Selected = "short"; Trace.Calls++; return (short)(61); }
    public static explicit operator long(Packet x) { Trace.Selected = "long"; Trace.Calls++; return (long)(62); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet input = new Packet { Number = 61 };
        short result = (short)input;
        Check(result == 61 && Trace.Selected == "short" && Trace.Calls == 1, "selection-target-short-short-long-explicit-direct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
