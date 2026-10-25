/*
Rules: P08-switch-exhaustive-warning
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Diagnostic: warning
Mutate: { 0 => 31 }
Into: { 0 => 31, _ => 31 }
*/
using System;

// patterns.md L301 requires this warning; both committee texts permit it.
// Only the actually supplied input is executed; the mutation covers every input.
class Program
{
    static int checks, failures, inputs;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Read() { inputs++; return 0; }
    static int Main()
    {
        int result = Read() switch { 0 => 31 };
        Check(result == 31, "warning-does-not-alter-selected-value");
        Check(inputs == 1, "warning-does-not-duplicate-input");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
