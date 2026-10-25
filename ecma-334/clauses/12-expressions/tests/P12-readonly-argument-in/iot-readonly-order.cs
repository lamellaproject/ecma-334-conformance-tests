/*
Rules: P12-readonly-argument-in; E12-6-2-3-argument-order; E12-6-2-3-by-reference-location
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 3
Mutate: int observed = Read(in Pick(out assigned, false), Next());
Into: int observed = Read(in Pick(out assigned, true), Next());
*/
using System;
class Test
{
    static int checks, failures, cell = 11, other = 11;
    static string trace = "";
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static ref int Pick(out int assigned, bool alternate)
    {
        trace += "a";
        assigned = 31;
        if (alternate) return ref other;
        return ref cell;
    }
    static int Next() { trace += "b"; cell = 29; return 5; }
    static int Read(ref readonly int value, int ignored) { trace += "c"; return value; }
    static int Main()
    {
        int assigned;
        int observed = Read(in Pick(out assigned, false), Next());
        Check(trace == "abc", "argument-locations-and-body-in-order-once");
        Check(observed == 29, "later-argument-update-visible-through-earlier-location");
        Check(assigned == 31, "nested-out-argument-definitely-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
