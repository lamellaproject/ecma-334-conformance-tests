/*
Rules: P08-range-string-order; P08-range-string-slice; E12-4-1-operand-order
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: string slice = Receiver()[Start(out assigned)..^End()];
Into: string slice = Receiver()[Start(out assigned)..End()];
*/
using System;
class Test
{
    static int checks, failures;
    static string trace = "";
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static string Receiver() { trace += "r"; return "LAMPERA"; }
    static int Start(out int assigned) { trace += "s"; assigned = 31; return 1; }
    static int End() { trace += "e"; return 2; }
    static int Main()
    {
        int assigned;
        string slice = Receiver()[Start(out assigned)..^End()];
        Check(trace == "rse", "receiver-start-end-once-in-order");
        Check(slice == "AMPE", "bounds-use-original-receiver-length");
        Check(assigned == 31, "bound-out-argument-definitely-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
