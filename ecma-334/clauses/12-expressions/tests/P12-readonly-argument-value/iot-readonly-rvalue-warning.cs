/*
Rules: P12-readonly-argument-value; P12-readonly-argument-unannotated-warning; E12-6-2-3-argument-order
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 3
Diagnostic: warning
Mutate: long observed = Read(Produce(), Next());
Into: long observed = Read(in Location(), Next());
*/
using System;
class Test
{
    static int checks, failures, cell = 11;
    static long stored = 11;
    static string trace = "";
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static short Produce() { trace += "a"; return (short)cell; }
    static ref long Location() { trace += "a"; return ref stored; }
    static int Next() { trace += "b"; cell = 29; return 5; }
    static long Read(ref readonly long value, int ignored) { trace += "c"; return value; }
    static int Main()
    {
        long observed = Read(Produce(), Next());
        Check(observed == 11, "converted-rvalue-temporary-keeps-evaluated-value");
        Check(cell == 29, "later-argument-changes-source-storage");
        Check(trace == "abc", "rvalue-conversion-before-later-argument-and-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
