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
    public static implicit operator Packet(short x) { Trace.Selected = "short"; Trace.Calls++; return new Packet { Number = 61 }; }
    public static implicit operator Packet(int x) { Trace.Selected = "int"; Trace.Calls++; return new Packet { Number = 61 }; }
}
class Program
{
    static void Main()
    {
        long input = 61L;
        Packet result = input;
    }
}
