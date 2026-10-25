/*
Rules: P08-nrt-suppression
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Diagnostic: none
Mutate: Read()!
Into: Read()
*/
#nullable enable
using System;

// Updated nullable specification L153; committee expressions 12.8.9.
// Removing ! toggles nullable warnings. Runtime checks verify the original
// evaluates its operand once, preserves null, and performs no runtime null check.
class Program
{
    static int checks, failures, calls;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static string? Read() { calls++; return null; }
    static bool IsNull(object? value) { return Object.ReferenceEquals(value, null); }
    static int Main()
    {
        string value = Read()!;
        Check(calls == 1, "suppressed-operand-once");
        Check(IsNull(value), "suppression-preserves-null");
        bool dereferenceThrew = false;
        try { int length = value.Length; Console.WriteLine(length); }
        catch (NullReferenceException) { dereferenceThrew = true; }
        Check(dereferenceThrew, "later-dereference-throws-null-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
