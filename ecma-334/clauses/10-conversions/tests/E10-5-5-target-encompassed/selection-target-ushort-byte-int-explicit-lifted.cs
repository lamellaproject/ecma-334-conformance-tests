/*
Rules: E10-5-5-target-encompassed; E10-5-5-lifted; E10-6-2-null; E10-6-2-nonnull
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
    public static explicit operator int(Packet x) { Trace.Selected = "int"; Trace.Calls++; return (int)(62); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet? input = new Packet { Number = 61 };
        ushort? result = (ushort?)input;
        Check(result.HasValue && result.Value == 61 && Trace.Selected == "byte" && Trace.Calls == 1, "selection-target-ushort-byte-int-explicit-lifted");
        input = null; ushort? absent = (ushort?)input;
        Check(!absent.HasValue && Trace.Calls == 1, "selection-target-ushort-byte-int-explicit-lifted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
