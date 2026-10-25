/*
Rules: P08-nullable-dereference-warning
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: value.Length
Into: value!.Length
*/
#nullable enable
using System;

// Updated nullable specification L224; committee types 8.9.4.4.
// The nullable result is non-null on this execution; its declared state is maybe-null.
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static string? Read() { return "hinge"; }
    static int Main()
    {
        string? value = Read();
        int length = value.Length;
        Check(length == 5, "possible-null-warning-does-not-change-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
