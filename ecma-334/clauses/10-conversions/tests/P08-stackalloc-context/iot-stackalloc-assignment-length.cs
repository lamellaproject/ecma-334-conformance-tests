/*
Rules: P08-stackalloc-context; E12-8-21-allocation-size
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: (stackalloc int[Length()])
Into: (stackalloc int[Length() + 1])
*/
using System;
class Program
{
    static int checks, failures, calls;
    static int Length() { calls++; return 3; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Span<int> area = stackalloc int[1];
        area = (stackalloc int[Length()]);
        Check(area.Length == 3, "parenthesized-assignment-length");
        Check(calls == 1, "length-evaluated-once");
        area[0] = 32;
        area[1] = 54;
        area[2] = 76;
        Span<int> alias = area;
        alias[1] = 87;
        Check(area[0] == 32 && area[1] == 87 && area[2] == 76, "span-shares-assigned-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
