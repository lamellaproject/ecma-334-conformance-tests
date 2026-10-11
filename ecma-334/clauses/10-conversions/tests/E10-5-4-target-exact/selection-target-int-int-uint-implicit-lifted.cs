/*
Rules: E10-5-4-target-exact; E10-5-4-lifted; E10-6-2-null; E10-6-2-nonnull
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 2
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static implicit operator int(Packet x) { Trace.Selected = "int"; Trace.Calls++; return (int)(61); }
    public static implicit operator uint(Packet x) { Trace.Selected = "uint"; Trace.Calls++; return (uint)(62); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet? input = new Packet { Number = 61 };
        int? result = input;
        Check(result.HasValue && result.Value == 61 && Trace.Selected == "int" && Trace.Calls == 1, "selection-target-int-int-uint-implicit-lifted");
        input = null; int? absent = input;
        Check(!absent.HasValue && Trace.Calls == 1, "selection-target-int-int-uint-implicit-lifted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
