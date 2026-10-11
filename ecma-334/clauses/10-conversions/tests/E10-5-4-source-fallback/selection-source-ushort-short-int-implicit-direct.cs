/*
Rules: E10-5-4-source-fallback
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static implicit operator Packet(short x) { Trace.Selected = "short"; Trace.Calls++; return new Packet { Number = 61 }; }
    public static implicit operator Packet(int x) { Trace.Selected = "int"; Trace.Calls++; return new Packet { Number = 61 }; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ushort input = (ushort)(61);
        Packet result = input;
        Check(result.Number == 61 && Trace.Selected == "int" && Trace.Calls == 1, "selection-source-ushort-short-int-implicit-direct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
