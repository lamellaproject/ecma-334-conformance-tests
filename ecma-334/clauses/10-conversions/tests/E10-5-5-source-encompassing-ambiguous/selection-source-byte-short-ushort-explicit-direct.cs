/*
Rules: E10-5-5-source-encompassing-ambiguous
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static explicit operator Packet(short x) { Trace.Selected = "short"; Trace.Calls++; return new Packet { Number = 61 }; }
    public static explicit operator Packet(ushort x) { Trace.Selected = "ushort"; Trace.Calls++; return new Packet { Number = 61 }; }
}
class Program
{
    static void Main()
    {
        byte input = (byte)(61);
        Packet result = (Packet)input;
    }
}
