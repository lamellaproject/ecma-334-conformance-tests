/*
Rules: P08-nullable-null-test-flow
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: if (value == null) return 0;
Into: if (value != null) return 0;
*/
#nullable enable
using System;

// Updated nullable specification L286; draft-v8 and alpha-v13 types 8.9.5.2.
// A returning null branch leaves the continuing reference in the not-null state.
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Measure(string? value)
    {
        if (value == null) return 0;
        return value.Length;
    }
    static int Main()
    {
        Check(Measure(null) == 0, "null-branch-returns");
        Check(Measure("spindle") == 7, "continuing-branch-is-not-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
