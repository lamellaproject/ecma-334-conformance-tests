/*
Rules: E10-5-4-empty
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
static class Trace { public static string Selected = ""; public static int Calls; }
struct Packet { public int Number;
    public static implicit operator int(Packet x) { Trace.Selected = "int"; Trace.Calls++; return (int)(61); }
    public static implicit operator long(Packet x) { Trace.Selected = "long"; Trace.Calls++; return (long)(62); }
}
class Program
{
    static void Main()
    {
        Packet? input = new Packet { Number = 61 };
        ushort? result = input;
    }
}
