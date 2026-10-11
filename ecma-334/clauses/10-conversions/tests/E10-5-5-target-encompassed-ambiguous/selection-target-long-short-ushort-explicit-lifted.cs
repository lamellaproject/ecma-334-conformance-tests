/*
Rules: E10-5-5-target-encompassed-ambiguous
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static explicit operator short(Packet x) { Trace.Selected = "short"; Trace.Calls++; return (short)(61); }
    public static explicit operator ushort(Packet x) { Trace.Selected = "ushort"; Trace.Calls++; return (ushort)(62); }
}
class Program
{
    static void Main()
    {
        Packet? input = new Packet { Number = 61 };
        long? result = (long?)input;
    }
}
