/*
Rules: E10-5-5-source-exact
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static explicit operator Packet(ushort x) { Trace.Selected = "ushort"; Trace.Calls++; return new Packet { Number = 61 }; }
    public static explicit operator Packet(int x) { Trace.Selected = "int"; Trace.Calls++; return new Packet { Number = 61 }; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ushort input = (ushort)(61);
        Packet result = (Packet)input;
        Check(result.Number == 61 && Trace.Selected == "ushort" && Trace.Calls == 1, "selection-source-ushort-ushort-int-explicit-direct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
