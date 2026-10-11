/*
Rules: E10-5-4-source-fallback; E10-5-4-lifted; E10-6-2-null; E10-6-2-nonnull
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static implicit operator Packet(uint x) { Trace.Selected = "uint"; Trace.Calls++; return new Packet { Number = 61 }; }
    public static implicit operator Packet(long x) { Trace.Selected = "long"; Trace.Calls++; return new Packet { Number = 61 }; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte? input = (byte)(61);
        Packet? result = input;
        Check(result.HasValue && result.Value.Number == 61 && Trace.Selected == "uint" && Trace.Calls == 1, "selection-source-byte-uint-long-implicit-lifted");
        input = null; Packet? absent = input;
        Check(!absent.HasValue && Trace.Calls == 1, "selection-source-byte-uint-long-implicit-lifted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
