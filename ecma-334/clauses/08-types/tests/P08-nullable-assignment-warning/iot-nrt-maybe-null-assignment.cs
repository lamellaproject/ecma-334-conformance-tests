/*
Rules: P08-nullable-assignment-warning
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: string storage = Read();
Into: string? storage = Read();
*/
#nullable enable
using System;

// Updated nullable specification L222; committee types 8.9.5.2.
// The compiler authority emits a warning without inserting a runtime check.
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static string? Read() { return null; }
    static int Main()
    {
        string storage = Read();
        Check(Object.ReferenceEquals(storage, null), "warning-assignment-remains-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
