/*
Rules: E10-5-4-target-fallback; E10-5-4-lifted; E10-6-2-null; E10-6-2-nonnull
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static implicit operator short(Packet x) { Trace.Selected = "short"; Trace.Calls++; return (short)(61); }
    public static implicit operator long(Packet x) { Trace.Selected = "long"; Trace.Calls++; return (long)(62); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet? input = new Packet { Number = 61 };
        int? result = input;
        Check(result.HasValue && result.Value == 61 && Trace.Selected == "short" && Trace.Calls == 1, "selection-target-int-short-long-implicit-lifted");
        input = null; int? absent = input;
        Check(!absent.HasValue && Trace.Calls == 1, "selection-target-int-short-long-implicit-lifted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
