/*
Rules: E10-5-5-target-exact; E10-5-5-lifted; E10-6-2-null; E10-6-2-nonnull
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static explicit operator short(Packet x) { Trace.Selected = "short"; Trace.Calls++; return (short)(61); }
    public static explicit operator uint(Packet x) { Trace.Selected = "uint"; Trace.Calls++; return (uint)(62); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet? input = new Packet { Number = 61 };
        short? result = (short?)input;
        Check(result.HasValue && result.Value == 61 && Trace.Selected == "short" && Trace.Calls == 1, "selection-target-short-short-uint-explicit-lifted");
        input = null; short? absent = (short?)input;
        Check(!absent.HasValue && Trace.Calls == 1, "selection-target-short-short-uint-explicit-lifted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
