/*
Rules: E10-5-4-target-exact
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static implicit operator byte(Packet x) { Trace.Selected = "byte"; Trace.Calls++; return (byte)(61); }
    public static implicit operator int(Packet x) { Trace.Selected = "int"; Trace.Calls++; return (int)(62); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet input = new Packet { Number = 61 };
        int result = input;
        Check(result == 62 && Trace.Selected == "int" && Trace.Calls == 1, "selection-target-int-byte-int-implicit-direct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
