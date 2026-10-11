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
    public static explicit operator byte(Packet x) { Trace.Selected = "byte"; Trace.Calls++; return (byte)(61); }
    public static explicit operator long(Packet x) { Trace.Selected = "long"; Trace.Calls++; return (long)(62); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet? input = new Packet { Number = 61 };
        long? result = (long?)input;
        Check(result.HasValue && result.Value == 62 && Trace.Selected == "long" && Trace.Calls == 1, "selection-target-long-byte-long-explicit-lifted");
        input = null; long? absent = (long?)input;
        Check(!absent.HasValue && Trace.Calls == 1, "selection-target-long-byte-long-explicit-lifted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
